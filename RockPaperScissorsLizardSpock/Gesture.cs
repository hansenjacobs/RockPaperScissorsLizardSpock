using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Gesture
    {
        string name;
        string verb;
        List<string> winAgainstGestures;

        public Gesture(string name, string verb, List<string> winAgainstGestures)
        {
            this.name = name;
            this.verb = verb;
            this.winAgainstGestures.AddRange(winAgainstGestures);
        }
    }
}
