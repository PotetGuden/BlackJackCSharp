using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCSharp
{
    public enum Cards{
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10, 
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11
    }
    public enum CardType{
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }
    class Deck{
        private static Cards[] cards = { Cards.Ace, Cards.Two, Cards.Three, Cards.Four, Cards.Five, Cards.Six, Cards.Seven, Cards.Eight, Cards.Nine, Cards.Ten, Cards.Jack, Cards.Queen, Cards.King };
        private static CardType[] cardType = { CardType.Clubs, CardType.Hearts, CardType.Diamonds, CardType.Spades };

        static List<KeyValuePair<Cards, CardType>> deck = new List<KeyValuePair<Cards, CardType>>();

        public void NewDeck(){ // Adding 52 new cards
            for (int i = 0; i < 4; i++){
                for(int j = 0; j < 13; j++){
                    deck.Add(new KeyValuePair<Cards, CardType>(cards[j], cardType[i]));
                }
            }
        }
        public KeyValuePair<Cards, CardType> GetOneCard(){
            // Feilsjekke at ikke kortstokken er tom
            int randomNumber = new Random().Next(deck.Count);
            KeyValuePair<Cards, CardType> aRandomCard = new KeyValuePair<Cards, CardType>(deck[randomNumber].Key, deck[randomNumber].Value);
            
            deck.Remove(deck[randomNumber]);      
            return aRandomCard;
        }

        public void GetCardsLeft(){
            for(int i = 0; i < deck.Count; i++)
            {
                Console.WriteLine("{0} {1}",deck[i].Key, deck[i].Value);
            }
        }
    }
}
