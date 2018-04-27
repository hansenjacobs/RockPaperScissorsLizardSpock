using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Computer : Player
    {
        public Computer(string name) : base(name)
        {

        }

        public override Gesture GetRPSLSChoice(List<Gesture> gestures)
        {
            return gestures[new Random().Next(0, gestures.Count)];
        }
    }
}
