using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Game
    {
        Player player1;
        Player player2;
        UI ui;
        List<Gesture> gestures;

        public Game()
        {
            ui = new UI();
        }

        private void InitializeGestures()
        {
            gestures.Add(new Gesture("rock", new List<string> { "crushes", "crushes" }, new List<string> { "scissors", "lizard" }));
            gestures.Add(new Gesture("paper", new List<string> { "covers", "disproves" }, new List<string> { "rock", "spock" }));
            gestures.Add(new Gesture("scissors", new List<string> { "cuts", "decapitates" }, new List<string> { "paper", "lizard" }));
            gestures.Add(new Gesture("lizard", new List<string> { "poisions", "eats" }, new List<string> { "spock", "paper" }));
            gestures.Add(new Gesture("spock", new List<string> { "smashes", "vaporizes" }, new List<string> { "scissors", "rock" }));
        }

        public void DisplayWelcome()
        {

            ui.AlertUser("ROCK PAPER SCISSORS LIZARD SPOCK");
            ui.AlertUser("- - - - - - - - - - - - - - - - -");
            ui.AlertUser("If you are familar with the traditional game Rock Paper Scissors,");
            ui.AlertUser("the RPSLS will seem familiar.  Each player privately chooses their");
            ui.AlertUser("gesture and then they compare to find the winner.  However, with");
            ui.AlertUser("two more possible gestures come more potential to lose.\n");
            DisplayGestures();           

        }

        public void DisplayGestures()
        {
            ui.AlertUser("RPSLS Gestures:");
            ui.AlertUser("ROCK, PAPER, SCISSORS, LIZARD, SPOCK\n");
            ui.AlertUser("Winning Combinations:");
            ui.AlertUser("SCISSORS cuts PAPER");
            ui.AlertUser("PAPER covers ROCK");
            ui.AlertUser("ROCK crushes LIZARD");
            ui.AlertUser("LIZARD poisons SPOCK");
            ui.AlertUser("SPOCK smashes SCISSORS");
            ui.AlertUser("SCISSORS decapitates LIZARD");
            ui.AlertUser("LIZARD eats PAPER");
            ui.AlertUser("PAPER disproves SPOCK");
            ui.AlertUser("SPOCK vaporizes ROCK");
            ui.AlertUser("ROCK crushes SCISSORS\n");
        }

        public void RunGame()
        {
            string input;

            DisplayWelcome();
            do
            {
                input = ui.GetUserInput("How many players are there? (max 2)", "string");
            } while (input != "1" || input != "2");

            if (input == "1")
            {
                // Setup one human and one computer player.
            }
            else
            {
                // Setup two human players.
            }

            // Setup gestures.


            // Do
            // Create round - store in list for history review?
            // Update player scores
            // Display round results
            // While (player1.score < 2 && player2.score < 2)

        }
    }
}
