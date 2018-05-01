using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Computer : Player
    {
        Random random;
        public Computer(string name, Random random) : base(name)
        {
            this.random = random;
        }

        public override Gesture GetRPSLSChoice(List<Gesture> gestures)
        {
            return gestures[random.Next(0, gestures.Count)];
        }
    }
}
