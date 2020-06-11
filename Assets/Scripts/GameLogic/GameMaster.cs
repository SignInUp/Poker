using System.Collections.Generic;

namespace GameLogic
{
    public class GameMaster
    {
        private CardDeck _cardDeck;
        private List<IPlayer> _players;
        public GameMaster(int humansPlayersCount, int botPlayersCount)
        {
            _cardDeck = new CardDeck();
            _cardDeck.ReshuffleDeck();
            
        } 
    }
}