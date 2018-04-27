using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    abstract class Player
    {
        string name;
        int roundsWon;

        public Player(string name)
        {
            this.name = name;
            roundsWon = 0;
        }

        public string GetName()
        {
            return name;
        }

        public int GetRoundsWon()
        {
            return roundsWon;
        }

        public abstract Gesture GetRPSLSChoice(List<Gesture> gestures);
    }
}
