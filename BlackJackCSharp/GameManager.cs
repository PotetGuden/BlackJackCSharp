using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCSharp {
    class GameManager{
        private Dealer dealer = new();
        private List<Player> players = new();
        private Deck deck = new();
        
        
        public void GeneratePlayers(int n){
            for (int i = 0; i < n; i++){
                players.Add(new Player());
            }
        }
        public void DealCards() {
            dealer.AddACard(deck.GetOneCard());
            dealer.AddACard(deck.GetOneCard());
            
            foreach(Player player in players){
                player.AddACard(deck.GetOneCard());
                player.AddACard(deck.GetOneCard());
            }
        }

        public void GenerateDeck(){
            deck.NewDeck();
        }

        public void InitialDraws(){
            dealer.InitialDraw();
            for(int i = 0; i < players.Count; i++){
                players[i].InitialDraw(i+1);
            }
            Console.WriteLine();
        }

        public void PlayerTurns(){
            for(int i = 0; i < players.Count; i++){
                while (true){
                    Console.Write("Would Player {0} like to hit or stay? (h/s) ", i+1);
                    
                    string userInput = Console.ReadLine();
                    if (userInput == "h"){
                        players[i].AddACard(deck.GetOneCard());
                        players[i].GetHoldingCards();
                    } else if (userInput == "s"){
                        break;
                    } else if (players[i].GetSumCards() > 21){
                        Console.WriteLine("You got an score above 21");
                        break;
                    } else{
                        Console.WriteLine("Please type in 'h' or 's' ");
                    }
                }
            }
        }

        public void DisplayResults(){
            for(int i = 0; i < players.Count; i++){
                if (dealer.GetSumCards() <= 21 && players[i].GetSumCards() < dealer.GetSumCards() || players[i].GetSumCards() > 21) {
                    Console.WriteLine("\n\nPlayer {0} Lost! (Your total was {1}, The dealer's total was {2}.)", i+1, players[i].GetSumCards(), dealer.GetSumCards());
                } else {
                    Console.WriteLine("\nPlayer {0} Won! (Your total was {1}, The dealer's total was {2}.)", i+1, players[i].GetSumCards(), dealer.GetSumCards());
                }    
            }
        }

        public void DealerTurn(){
            dealer.DealersTurn();
        }
    }
}
