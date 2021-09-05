using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCSharp
{
    class Player
    {
        private List<KeyValuePair<Cards, CardType>> holdingCards = new List<KeyValuePair<Cards, CardType>>();
        int sumCards = 0;
        public void AddACard(KeyValuePair<Cards, CardType> cards)
        {
            holdingCards.Add(cards);
        }
        public void InitialDraw() {
            SumCards();
            Console.WriteLine("Your initial draw is \"{0} of {1}\" and \"{2} of {3}\". Your current SOFT total is {4}", holdingCards[0].Key, holdingCards[0].Value, holdingCards[1].Key, holdingCards[1].Value, sumCards);
            Console.Write("Would you like to hit or stay? (h/s) ");
        }

        private void SumCards() {
            sumCards = 0;
            for (int i = 0; i < holdingCards.Count; i++) {
                sumCards += Deck.CardNumberConverter(holdingCards[i].Key);
            }
        }
        public void GetHoldingCards(){
            SumCards();
            Console.WriteLine("\nYou pulled \"{0} of {1}\" from the deck. Your current total is {2}", holdingCards[holdingCards.Count-1].Key, holdingCards[holdingCards.Count - 1].Value, sumCards);
            Console.Write("Would you like to hit or stay? (y/n)");
        }

        public void Reset()
        {
            sumCards = 0;
            for(int i = holdingCards.Count-1; i >= 0 ; i--){
                holdingCards.Remove(holdingCards[i]);
            }

            Deck deck = new Deck();
            holdingCards.Add(deck.GetOneCard());
            holdingCards.Add(deck.GetOneCard());

            GetHoldingCards();
        }
        public int GetSumCards(){
            return sumCards;
        }
    }
}
