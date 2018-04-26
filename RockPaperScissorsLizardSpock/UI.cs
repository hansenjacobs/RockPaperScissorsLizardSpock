using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public static class UI
    {
        static string GetUserInput(string message, string type)
        {
            string input;

            Console.WriteLine("\n" + message);
            input = Console.ReadLine();

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

        static bool IsValidInt(string str)
        {
            int trash = 0;
            if(Int32.TryParse(str, out trash))
            {
                return true;
            }
            return false;
        }
    }
}
