namespace GameLogic
{
    public enum Rank
    {
        Two = 2, Three, Four, Five,
        Six, Seven, Eight, Nine,
        Ten, Jack, Queen, King, Ace
    }

    public enum Suit
    {
        Hearts,
        Tiles,
        Clovers,
        Pikes
    }
    
    public struct Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
    
}