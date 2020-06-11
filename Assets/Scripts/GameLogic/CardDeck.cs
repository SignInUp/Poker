namespace GameLogic
{
    public class CardDeck
    {
        private int _topCard;
        private readonly Card[] _deck;

        private const int CardsInDeck = 52;
        
        public CardDeck()
        {
            _deck = new Card[CardsInDeck];
            _topCard = CardsInDeck - 1;

            var index = 0;
            const int suitsCount = 4;
            const int ranksCountPlusTwo = 15;
            
            for (var i = 2; i < ranksCountPlusTwo; ++i)
            {
                for (var j = 0; j < suitsCount; ++j)
                {
                    _deck[index++] = new Card((Rank)i, (Suit)j);
                }
            }
        }

        public Card GetTopCard() => _deck[_topCard--];
        
        // Fisher-Yates shuffle
        public void ReshuffleDeck()
        {
            var rnd = new System.Random();
            for (var i = CardsInDeck - 1; i > 0; --i)
            {
                var index = rnd.Next(i + 1);
                var temp = _deck[i];
                _deck[i] = _deck[index];
                _deck[index] = temp;
            }
        }
        
    }
}