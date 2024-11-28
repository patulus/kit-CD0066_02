using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace G24W12WPFCardDealer;

class CardViewModel : INotifyPropertyChanged
{
    // 보통 _를 앞에 붙이는 것은 private이긴한데 getter로 넘겨야 할 때 _를 씀
    private CardModel cardModel;

    private ObservableCollection<string> _cardResources; // 데이터 바인딩을 위해 string으로 ObservableCollection 생성
    public ObservableCollection<string> CardResources { get { return _cardResources; } }

    private string _cardRanking;
    public string CardRanking { get { return _cardRanking; } }

    static string[] suits = ["spades", "diamonds", "hearts", "clubs",];
    static string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

    public CardViewModel(CardModel cardModel)
    {
        this.cardModel = cardModel;
        _cardResources = new ObservableCollection<string>();
        _cardRanking = "카드를 분배하세요.";
        ChangeResource(cardModel.Cards);
    }

    public void DealCards()
    {
        var newCards = cardModel.DealCards(); // List<Card>가 알아서...

        ChangeResource(newCards);
        ChangeHandRanking(newCards);
    }

    private void ChangeResource(List<Card> cards)
    {
        _cardResources.Clear();

        foreach (Card card in cards)
        {
            _cardResources.Add(GetCardImageName(card));
        }

        // 호출한 녀석이 GetResourceName이므로 CallerMemberName을 사용하면 안 된다!
        // 만약 CardResources의 setter에서 호출했다면 사용할 수 있긴 함
        // 똑같으니 nameof를 쓰는 것이 좋다: string은 오타나 변경에도 컴파일 시 에러가 나지 않고 런타임 시에 나므로 컴파일 시 에러를 방지위해
        // nameof로 string을 받아서 사용하자.
        OnPropertyChanged(nameof(CardResources)); // OnPropertyChanged("CardResources");
    }

    private string GetCardImageName(Card card)
    {
        if (card.Suit < 0 || card.Value < 0)
            return "Images/black_joker.png";

        string suit = suits[card.Suit];
        string value = values[card.Value];

        return (value == "jack" || value == "queen" || value == "king")
            ? $"Images/{value}_of_{suit}2.png"
            : $"Images/{value}_of_{suit}.png";
    }

    private void ChangeHandRanking(List<Card> cards)
    {
        _cardRanking = "One Pair";

        OnPropertyChanged(nameof(CardRanking));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
