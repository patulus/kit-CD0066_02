using System.Security.Policy;

namespace G24W12WPFCardDealer;

class Card
{
    // static으로 인스턴스 생성 없이 사용이 가능
    public static readonly int NUMBER_OF_SUITS = 4;
    public static readonly int NUMBER_OF_VALUES = 13;

    public Card(int suit, int value)
    {
        Suit = suit;
        Value = value;
    }

    public Card(int number)
    {
        Suit = number / NUMBER_OF_VALUES; // 0 ~ 3
        Value = number % NUMBER_OF_VALUES; // 0 ~ 12
    }

    public int Suit { get; set; }
    public int Value { get; set; }
}

class CardModel
{
    public static readonly int NUMBER_OF_CARDS = 5;
    public static readonly int NUMBER_OF_HANDRAKING = 10;

    private List<Card> _cards = new List<Card>();

    public List<Card> Cards { get { return _cards; } }

    public CardModel()
    {
        for (int i = 0; i < NUMBER_OF_CARDS; ++i)
        {
            _cards.Add(new Card(-1, -1)); // 조커 출력용
        }
    }

    public List<Card> DealCards()
    {
        Random random = new Random();

        HashSet<int> cardSet = new HashSet<int>();
        while (cardSet.Count < NUMBER_OF_CARDS)
        {
            cardSet.Add(random.Next(Card.NUMBER_OF_SUITS * Card.NUMBER_OF_VALUES));
        }

        List<int> cardList = cardSet.ToList();
        cardList.Sort();
        _cards.Clear();

        foreach (int card in cardList)
        {
            _cards.Add(new Card(card));
        }

        return Cards; // return _cards;
    }
}
