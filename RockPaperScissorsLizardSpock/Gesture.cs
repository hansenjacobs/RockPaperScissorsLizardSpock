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
        List<string> verbs = new List<string>();
        List<string> winAgainstGestures = new List<string>();

        public Gesture(string name, List<string> verbs2, List<string> winAgainstGestures)
        {
            this.name = name;
            if(verbs2.Count == winAgainstGestures.Count)
            {
                this.verbs.AddRange(verbs2);
                this.winAgainstGestures.AddRange(winAgainstGestures);
            }
            else
            {
                this.verbs.Add("ERROR");
                this.winAgainstGestures.Add("ERROR");
                Console.WriteLine("Unable to create the " + name + " gesture object.");
                Console.WriteLine("Incorrect number of verbs provided for the number of win against gestures.");
                throw new Exception();
            }
            
        }

        public string GetName()
        {
            return name;
        }

        public string GetVerb(int index)
        {
            return verbs[index];
        }

        public List<string> GetVerbs()
        {
            return verbs;
        }

        public string GetWinAgainstGesture(int index)
        {
            return winAgainstGestures[index];
        }

        public List<string> GetWinAgainstGestures()
        {
            return winAgainstGestures;
        }
    }
}
