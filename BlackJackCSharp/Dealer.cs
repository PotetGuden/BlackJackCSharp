using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCSharp {
    class Dealer {
        private List<KeyValuePair<Cards, CardType>> holdingCards = new();
        int sumCards = 0;
        public void AddACard(KeyValuePair<Cards, CardType> cards){
            holdingCards.Add(cards);
        }

        public void DealersTurn() {
            for(int i = 0; i < holdingCards.Count; i++){
                sumCards += (int)holdingCards[i].Key;
            }
            Console.WriteLine("The Dealers sum is: {0}", sumCards);

            Deck deck = new Deck();
            while(sumCards < 17)
            {
                holdingCards.Add(deck.GetOneCard());
                sumCards += (int)holdingCards[holdingCards.Count-1].Key;
                Console.WriteLine("Dealer picked {0} of {1} the sum is now {2}", holdingCards[holdingCards.Count - 1].Key, holdingCards[holdingCards.Count - 1].Value, sumCards);
            }

            Console.WriteLine("Dealer got {0} as a total value", sumCards);
            
        }

        public void InitialDraw() {
            Console.WriteLine("Dealer's initial draw is the hidden hole card and \"{0} of {1}\"", holdingCards[0].Key, holdingCards[0].Value);
        }
        public int GetSumCards()
        {
            return sumCards;
        }
        public void Reset()
        {
            sumCards = 0;
            for (int i = holdingCards.Count - 1; i >= 0; i--)
            {
                holdingCards.Remove(holdingCards[i]);
            }

            Deck deck = new Deck();
            holdingCards.Add(deck.GetOneCard());
            holdingCards.Add(deck.GetOneCard());

            InitialDraw();
        }
    }
}
