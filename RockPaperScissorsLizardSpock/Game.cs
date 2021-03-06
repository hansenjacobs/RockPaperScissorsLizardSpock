﻿using System;
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
        List<Gesture> gestures = new List<Gesture>();
        int winningScore;
        Random random;

        public Game()
        {
            ui = new UI();
            random = new Random();
        }

        private void InitializeGestures()
        {
            if(gestures.Count == 0)
            {
                gestures.Add(new Gesture("paper", new List<string> { "covers", "disproves" }, new List<string> { "rock", "spock" }));
                gestures.Add(new Gesture("scissors", new List<string> { "cuts", "decapitates" }, new List<string> { "paper", "lizard" }));
                gestures.Add(new Gesture("lizard", new List<string> { "poisions", "eats" }, new List<string> { "spock", "paper" }));
                gestures.Add(new Gesture("spock", new List<string> { "smashes", "vaporizes" }, new List<string> { "scissors", "rock" }));
                gestures.Add(new Gesture("rock", new List<string> { "crushes", "crushes" }, new List<string> { "lizard", "scissors" }));
            }
        }

        public void DisplayWelcome()
        {

            ui.AlertUser("ROCK PAPER SCISSORS LIZARD SPOCK");
            ui.AlertUser("- - - - - - - - - - - - - - - - -");
            ui.AlertUser("If you are familar with the traditional game Rock Paper Scissors,");
            ui.AlertUser("the RPSLS will seem familiar.  Each player privately chooses their");
            ui.AlertUser("gesture and then they compare to find the winner.  However, with");
            ui.AlertUser("two more possible gestures come more potential to lose.");
            ui.AlertUser("Use the 'quit' command to exit the application at anytime.\n");
            DisplayGestures();           

        }

        public void DisplayGestures()
        {
            ui.AlertUser("RPSLS Gestures:");
            ui.AlertUser(GetGesturesStringList() + "\n");

            ui.AlertUser("Winning Combinations:");

            foreach (Gesture gesture in gestures)
            {
                List<string> winAgainstGestures = gesture.GetWinAgainstGestures();
                List<string> verbs = gesture.GetVerbs();

                for (int i = 0; i < winAgainstGestures.Count; i++)
                {
                    if(gesture.GetName() == "rock" && winAgainstGestures[i] == "scissors")
                    {
                        Console.Write("And as it alaways has, ");
                    }
                    ui.AlertUser(gesture.GetName().ToUpper() + " " + verbs[i] + " " + winAgainstGestures[i].ToUpper());
                }
            }
        }

        private string GetGesturesStringList()
        {
            string output = "";
            foreach(Gesture gesture in gestures)
            {
                output += gesture.GetName().ToUpper() + ", ";
            }

            return output.Substring(0, output.Length - 2);
        }

        public void RunGame()
        {
            string input;

            InitializeGestures();

            DisplayWelcome();
            do
            {
                input = ui.GetUserInput("How many players are there? (max 2)", "string");

            } while (input != "0" && input != "1" && input != "2");

            ui.AlertUser("The winner is determined by the best out of X rounds, typically 3 rounds are played.");

            winningScore = Convert.ToInt32(Math.Floor(double.Parse(ui.GetUserInput("How many rounds would you like to play?", "int"))/2) + 1);

            switch (input)
            {
                case "0":
                    player1 = new Computer("CPU 1", random);
                    player2 = new Computer("CPU 2", random);
                    break;

                case "1":
                    input = ui.GetUserInput("What is your name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 1";
                    }

                    player1 = new Human(input, ui);
                    player2 = new Computer("CPU", random);
                    break;

                case "2":
                    input = ui.GetUserInput("What is player 1's name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 1";
                    }
                    player1 = new Human(input, ui);

                    input = ui.GetUserInput("What is player 2's name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 2";
                    }
                    player2 = new Human(input, ui);
                    break;

                default:
                    throw new Exception();
            }

            int roundNumber = 0;

            do
            {
                roundNumber++;

                Console.Clear();
                ui.AlertUser("Round " + roundNumber);
                Gesture player1Gesture = player1.GetRPSLSChoice(gestures);

                Console.Clear();
                ui.AlertUser("Round " + roundNumber);
                Gesture player2Gesture = player2.GetRPSLSChoice(gestures);

                Console.Clear();
                ui.AlertUser("Round " + roundNumber.ToString() + " Results");
                ui.AlertUser(" - - - - - - - - - - - - - - - - - - - - - - -");

                if (player1Gesture.GetWinAgainstGestures().Contains(player2Gesture.GetName()))
                {
                    player1.IncreaseRoundsWon(1);
                    int index = player1Gesture.GetWinAgainstGestures().IndexOf(player2Gesture.GetName());
                    ui.AlertUser(player1Gesture.GetName().ToUpper() + " " + player1Gesture.GetVerb(index) + " " + player1Gesture.GetWinAgainstGesture(index).ToUpper() + "\n");
                    ui.AlertUser(player1.Name + " wins this round!");
                }
                else if (player2Gesture.GetWinAgainstGestures().Contains(player1Gesture.GetName()))
                {
                    player2.IncreaseRoundsWon(1);
                    int index = player2Gesture.GetWinAgainstGestures().IndexOf(player1Gesture.GetName());
                    ui.AlertUser(player2Gesture.GetName().ToUpper() + " " + player2Gesture.GetVerb(index) + " " + player2Gesture.GetWinAgainstGesture(index).ToUpper() + "\n");
                    ui.AlertUser(player2.Name + " wins this round!");
                }
                else
                {
                    ui.AlertUser(player1Gesture.GetName().ToUpper() + " ties " + player2Gesture.GetName().ToUpper());
                    ui.AlertUser("Round ends in a draw.");
                }

                ui.AlertUser("\nCurrent Standings");
                ui.AlertUser("- - - - - - - - - - -");
                ui.AlertUser(player1.Name + " " + player1.RoundsWon);
                ui.AlertUser(player2.Name + " " + player2.RoundsWon + "\n");
                ui.GetUserInput("Press enter to continue...", "string");

            } while (player1.RoundsWon < winningScore && player2.RoundsWon < winningScore);

            Player winner = player1.RoundsWon > player2.RoundsWon ? player1 : player2;

            Console.Clear();

            ui.AlertUser("G A M E  O V E R\n");
            ui.AlertUser(winner.Name.ToUpper() + " WINS!\n");
            ui.AlertUser("Final Results");
            ui.AlertUser("- - - - - - - - - - -");
            ui.AlertUser(player1.Name + " " + player1.RoundsWon);
            ui.AlertUser(player2.Name + " " + player2.RoundsWon + "\n");
            if(ui.GetUserInput("Would you like to play again? (yes/no)", "yesNo").ToLower() == "yes")
            {
                RunGame();
            }
        }
    }
}
