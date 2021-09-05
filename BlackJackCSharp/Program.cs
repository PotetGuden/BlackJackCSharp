using System;
namespace BlackJackCSharp {
    namespace GameHandler {
        class Program {
            static void Main(string[] args){
                Console.WriteLine("This Is BlackJack!\n");

                Deck deck = new Deck();
                Dealer dealer = new Dealer();
                Player player = new Player();
                
                deck.NewDeck(); // "opens" a new deck

                // Give 2 cards for dealer and player, then show their values
                dealer.AddACard(deck.GetOneCard());
                dealer.AddACard(deck.GetOneCard());

                dealer.InitialDraw();

                player.AddACard(deck.GetOneCard());
                player.AddACard(deck.GetOneCard());

                player.InitialDraw(); ;

                // Gameloop
                while (true){
                    if(player.GetSumCards() > 21) {
                        Console.WriteLine("You Lost! (Your total was {0} which is over 21)", player.GetSumCards());
                        Console.Write("Would you like to play again? (y/n)"); 
                    }
                    
                    string userInput = Console.ReadLine();

                    if (userInput == "quit") {
                        break;
                    } else if (userInput == "stay") {
                        dealer.DealersTurn();

                        if (dealer.GetSumCards() <= 21 && player.GetSumCards() < dealer.GetSumCards()) {
                            Console.WriteLine("\n\nYou Lost! (Your total was {0}, The dealer's total was {1}.)", player.GetSumCards(), dealer.GetSumCards());
                        } else {
                            Console.WriteLine("\nYou Won! (Your total was {0}, The dealer's total was {1}.)", player.GetSumCards(), dealer.GetSumCards());
                        }
                        Console.Write("\nWould you like to start again? (y/n)?");
                        string userRestartInput = Console.ReadLine();

                        if (userRestartInput == "y") {
                            dealer.Reset();
                            player.Reset();
                            continue;
                        } else {
                            break;
                        }
                    } else if (userInput == "reset") {
                        dealer.Reset();
                        player.Reset();
                    } else if (userInput == "cardsleft") {
                        deck.GetCardsLeft();
                    } else if (userInput == "hit") {
                        player.AddACard(deck.GetOneCard());
                        player.GetHoldingCards();

                    } else if (userInput == "y") {
                        dealer.Reset();
                        player.Reset();
                        continue;
                    } else {
                        Console.WriteLine("\nYou have to choose a valid input \n");
                    }
                }
                //deck.GetCardsLeft();
            }
        }
    }
}
