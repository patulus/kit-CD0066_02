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

    // 족보 정보를 View에 넘깁니다.
    private string _cardRanking;
    public string CardRanking { get { return _cardRanking; } }

    static string[] suits = ["spades", "diamonds", "hearts", "clubs",];
    static string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

    // 통계 정보를 View에 넘깁니다.
    public int Iter { get; set; }
    private int[] _statistics;
    public int[] Statistics { get { return _statistics; } }

    public CardViewModel(CardModel cardModel)
    {
        this.cardModel = cardModel;

        _cardResources = new ObservableCollection<string>();
        _cardRanking = "카드를 분배하세요.";
        Iter = 10000;
        _statistics = new int[CardModel.NUMBER_OF_HANDRAKING + 1];

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

    // 족보 정보를 판별해 족보 정보를 변경합니다.
    private void ChangeHandRanking(List<Card> cards)
    {
        int[] suits = new int[Card.NUMBER_OF_SUITS];
        int[] values = new int[Card.NUMBER_OF_VALUES + 1];
        
        // 카드를 하나씩 읽어 카운트합니다.
        foreach (Card card in cards)
        {
            ++suits[card.Suit];
            ++values[card.Value];
            // Royal Straight 판별을 위해 에이스 셈을 뒷 공간에도 추가합니다.
            if (card.Value == 0)
            {
                ++values[Card.NUMBER_OF_VALUES];
            }
        }

        int i, j;
        // Straight: 숫자 5개가 연속해 존재하는지 확인합니다.
        Boolean isStraight = false;
        // Royal Straight: ace, 10, jack, queen, king 카드로 이루어진 스트레이트인지 확인합니다.
        Boolean isRoyalStraight = false;
        for (i = 0; i <= Card.NUMBER_OF_VALUES + 1 - 5; ++i)
        {
            int cntForStraight = 0;
            
            for (j = i; j < i + 5; ++j)
            {
                // 연속해 존재하지 않으면 탐색을 그만 둡니다.
                if (values[j] != 1)
                {
                    break;
                }

                ++cntForStraight;

                if (cntForStraight == 5)
                {
                    isStraight = true;
                    if (i == Card.NUMBER_OF_VALUES + 1 - 5)
                    {
                        isRoyalStraight = true;
                    }

                    break;
                }
            }
        }

        // Flush: 같은 무늬의 카드가 5장 존재하는지 확인합니다.
        Boolean isFlush = false;
        for (i = 0; i < Card.NUMBER_OF_SUITS; ++i)
        {
            if (suits[i] == 5)
            {
                isFlush = true;
                break;
            }
        }

        // Straight Flush: 같은 무늬의 연속된 숫자 5개가 존재하는지 확인합니다.
        Boolean isStraightFlush = (isStraight && isFlush);

        // One Pair: 숫자가 같은 카드가 2장 존재하는지 확인합니다.
        int cntPair = 0;
        Boolean isOnePair = false;
        // Two Pair: 숫자가 같은 카드가 2장인 것이 2개 존재하는지 확인합니다.
        Boolean isTwoPair = false;
        // Three of a Kind: 숫자가 같은 카드가 3장 존재하는지 확인합니다.
        Boolean isThreeOfAKind = false;
        // Four of a Kind: 숫자가 같은 카드가 4장 존재하는지 확인합니다.
        Boolean isFourOfAKind = false;
        for (i = 0; i < Card.NUMBER_OF_VALUES; ++i)
        {
            if (values[i] == 2)
            {
                ++cntPair;
            }
            else if (values[i] == 3)
            {
                isThreeOfAKind = true;
            }
            else if (values[i] == 4)
            {
                isFourOfAKind = true;
            }
        }
        isOnePair = (cntPair == 1);
        isTwoPair = (cntPair == 2);
        // Full House: 숫자가 같은 카드 3장과 다른 수의 숫자가 같은 카드 2장이 존재하는지 확인합니다.
        Boolean isFullHouse = (isThreeOfAKind && isOnePair);

        if (isRoyalStraight)
        {
            _cardRanking = "Royal Straight";
            ++_statistics[9];
        }
        else if (isStraightFlush)
        {
            _cardRanking = "Straight Flush";
            ++_statistics[8];
        }
        else if (isFourOfAKind)
        {
            _cardRanking = "Four of a Kind";
            ++_statistics[7];
        }
        else if (isFullHouse)
        {
            _cardRanking = "Full House";
            ++_statistics[6];
        }
        else if (isFlush)
        {
            _cardRanking = "Flush";
            ++_statistics[5];
        }
        else if (isStraight)
        {
            _cardRanking = "Straight";
            ++_statistics[4];
        }
        else if (isThreeOfAKind)
        {
            _cardRanking = "Three of a Kind";
            ++_statistics[3];
        }
        else if (isTwoPair)
        {
            _cardRanking = "Two Pair";
            ++_statistics[2];
        }
        else if (isOnePair)
        {
            _cardRanking = "One Pair";
            ++_statistics[1];
        }
        else
        {
            _cardRanking = "High Card";
            ++_statistics[0];
        }
        ++_statistics[CardModel.NUMBER_OF_HANDRAKING];

        OnPropertyChanged(nameof(Statistics));
        OnPropertyChanged(nameof(CardRanking));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
