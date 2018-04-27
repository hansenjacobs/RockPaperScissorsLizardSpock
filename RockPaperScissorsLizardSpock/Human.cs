using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Human : Player
    {
        UI ui;
        public Human(string name, UI ui) : base(name)
        {
            this.ui = ui;
        }

        public override Gesture GetRPSLSChoice(List<Gesture> gestures)
        {
            string input = ui.GetUserInput(base.GetName() + ", what gesture would you like to execute?\n", "RPSLS").ToLower();
            return gestures.Where(gesture => gesture.name == input).FirstOrDefault();
        }
    }
}
