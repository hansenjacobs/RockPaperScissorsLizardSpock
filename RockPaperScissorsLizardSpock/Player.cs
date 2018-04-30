using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    abstract class Player
    {
        string _name;
        int _roundsWon;

        public Player(string name)
        {
            _name = name;
            _roundsWon = 0;
        }

        public string Name
        {
            get{
                return _name;
            }
        }

        public int RoundsWon
        {
            get { return _roundsWon; }
        }

        public abstract Gesture GetRPSLSChoice(List<Gesture> gestures);

        public void IncreaseRoundsWon(int incrementBy)
        {
            _roundsWon += incrementBy;
        }
    }
}
