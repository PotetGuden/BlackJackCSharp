using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCSharp
{
    public enum Cards{
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten, 
        Knight,
        Queen,
        King,
        Ace
    }
    public enum CardType{
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }
    class Deck{
        private static Cards[] cards = { Cards.Ace, Cards.Two, Cards.Three, Cards.Four, Cards.Five, Cards.Six, Cards.Seven, Cards.Eight, Cards.Nine, Cards.Ten, Cards.Knight, Cards.Queen, Cards.King };
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
        public static int CardNumberConverter(Cards card)
        {
            switch (card)
            {
                case Cards.Ace:
                    return 11;
                case Cards.Two:
                    return 2;
                case Cards.Three:
                    return 3;
                case Cards.Four:
                    return 4;
                case Cards.Five:
                    return 5;
                case Cards.Six:
                    return 6;
                case Cards.Seven:
                    return 7;
                case Cards.Eight:
                    return 8;
                case Cards.Nine:
                    return 9;
                case Cards.Ten:
                case Cards.Knight:
                case Cards.Queen:
                case Cards.King:
                    return 10;
                default: return -1;
            }
        }

        
    }
}
