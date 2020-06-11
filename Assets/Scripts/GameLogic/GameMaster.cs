using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameLogic
{
    public class GameMaster
    {
        private enum State
        {
            PreFlop,
            Flop,
            Tern,
            River
        }

        private int _bigBlindIndex;
        private int _smallBlindIndex;
        private State _state;
        private int _currentBet;
        private int _bank;
        private CardDeck _cardDeck;
        private readonly Dictionary<int, IPlayer> _players;    
        private readonly List<Card> _desk;

        public GameMaster(Dictionary<int, IPlayer> players)
        {
            _bigBlindIndex = 0;
            _smallBlindIndex = 0;
            _bank = 0;
            _cardDeck = new CardDeck();
            _players = players;
            _desk = new List<Card>();
            _state = State.River;
        }
        public bool DoMove(ref IPlayer player, Action action)
        {
            switch (action.ActionType)
            {
                case ActionType.Bet:
                    if (action.Money > player.Money)
                        return false;
                    player.Bet += action.Money;
                    player.Money -= action.Money;
                    _currentBet += action.Money;
                    break;
                case ActionType.Call:
                    var difference = _currentBet - player.Bet;
                    player.Money -= difference;
                    if (player.Money < 0)
                    {
                        player.Credit = -player.Money;
                        player.Money = 0;
                        player.Bet = difference - player.Credit;
                    }
                    else
                    {
                        player.Bet += difference;
                    }
                    break;
                case ActionType.Raise:
                    if (action.Money > player.Money)
                        return false;
                    player.Bet += action.Money;
                    player.Money -= action.Money;
                    _currentBet += action.Money;
                    break;
                case ActionType.Fold:
                    player.Cards = null;
                    break;
                case ActionType.Check:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }
        public void NextRound()
        {
            switch (_state)
            {
                case State.PreFlop:
                    StartNewGame();
                    break;
                case State.Flop:
                    Flop();
                    break;
                case State.Tern:
                    Tern();
                    break;
                case State.River:
                    River();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void StartNewGame()
        {
            _state = State.Flop;
            _desk.Clear();
            _cardDeck = new CardDeck();
            _cardDeck.ReshuffleDeck();
            foreach (var player in _players)
            {
                player.Value.Cards = new Card[2] {_cardDeck.GetTopCard(), _cardDeck.GetTopCard()};
            }
        }
        private void Flop()
        {
            _state = State.Tern;
            _desk.Add(_cardDeck.GetTopCard());
            _desk.Add(_cardDeck.GetTopCard());
            _desk.Add(_cardDeck.GetTopCard());
            
        }
        private void Tern()
        {
            _state = State.River;
            _desk.Add(_cardDeck.GetTopCard());
        }
        private void River()
        {
            _state = State.PreFlop;
            ++_bigBlindIndex;
            ++_smallBlindIndex;
            _desk.Add(_cardDeck.GetTopCard());
        }
    }
}