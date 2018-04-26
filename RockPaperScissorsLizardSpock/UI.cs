using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class UI
    {

        public void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        public string GetUserInput(string message, string type)
        {
            string input;

            Console.WriteLine("\n" + message);
            input = Console.ReadLine();
            Console.Write("\n");

            switch (type)
            {
                case "int":
                    if (!IsValidInt(input))
                    {
                        return GetUserInput(message, type);
                    }
                    break;

                default:
                    // Is valid.
                    break;

            }

            return input;
        }

        private bool IsValidInt(string str)
        {
            int trash = 0;
            if(Int32.TryParse(str, out trash))
            {
                return true;
            }
            Console.WriteLine("Invalid input. Please enter a whole number.");
            return false;
        }
    }
}
