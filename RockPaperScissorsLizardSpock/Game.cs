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

        public Game()
        {
            ui = new UI();
        }

        private void InitializeGestures()
        {
            gestures.Add(new Gesture("paper", new List<string> { "covers", "disproves" }, new List<string> { "rock", "spock" }));
            gestures.Add(new Gesture("scissors", new List<string> { "cuts", "decapitates" }, new List<string> { "paper", "lizard" }));
            gestures.Add(new Gesture("lizard", new List<string> { "poisions", "eats" }, new List<string> { "spock", "paper" }));
            gestures.Add(new Gesture("spock", new List<string> { "smashes", "vaporizes" }, new List<string> { "scissors", "rock" }));
            gestures.Add(new Gesture("rock", new List<string> { "crushes", "crushes" }, new List<string> { "lizard", "scissors" }));
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
            } while (input != "0" || input != "1" || input != "2");

            switch (input)
            {
                case "0":
                    player1 = new Computer("CPU 1");
                    player2 = new Computer("CPU 2");
                    break;

                case "1":
                    input = ui.GetUserInput("What is your name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 1";
                    }

                    player1 = new Human(input);
                    player2 = new Computer("CPU");
                    break;

                case "2":
                    input = ui.GetUserInput("What is player 1's name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 1";
                    }
                    player1 = new Human(input);

                    input = ui.GetUserInput("What is player 2's name?", "string");
                    if(input == null || input == "")
                    {
                        input = "Player 2"
                    }
                    player2 = new Human(input);
                    break;

                default:
                    throw new Exception();
            }

            // Do
            // Create round - store in list for history review?
            // Update player scores
            // Display round results
            // While (player1.score < 2 && player2.score < 2)

        }
    }
}
