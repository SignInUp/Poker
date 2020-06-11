namespace GameLogic
{
    public interface IPlayer
    {
        int Bet { get; set; }
        int Credit { get; set; }
        int Money { get; set; }
        Card[] Cards { get; set; }
    }    
}

