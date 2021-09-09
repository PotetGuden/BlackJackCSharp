using System;
namespace BlackJackCSharp {
    namespace GameHandler {
        class Program {
            enum GameState {
                Winner,
                Looser
            }

            static void Main(string[] args){
                GameState status;
                status = GameState.Winner;

                int statusNumber = (int) GameState.Winner;
                // Console.ReadKey().
                
                Console.WriteLine("This Is BlackJack!\n");

                var deck = new Deck();
                var dealer = new Dealer();
                var player = new Player();
                var gm = new GameManager();
                Console.Write("How many players are playing? ");
                int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                
                gm.GenerateDeck();
                gm.GeneratePlayers(numberOfPlayers);
                gm.DealCards();
                gm.InitialDraws();
                
                //deck.NewDeck(); // "opens" a new deck

                // Give 2 cards for dealer and player, then show their values
                /*dealer.AddACard(deck.GetOneCard());
                dealer.AddACard(deck.GetOneCard());

                dealer.InitialDraw();

                player.AddACard(deck.GetOneCard());
                player.AddACard(deck.GetOneCard());

                player.InitialDraw(); ;*/

                // Gameloop
               
                gm.PlayerTurns();
                gm.DealerTurn();
                gm.DisplayResults();
                
            }
        }
    }
}
