using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Project1Sibi153934
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sibi, Lance Justin
            // 153934
            // November 11, 2016
            // I have not discussed the C# language code in my program
            // with anyone other than my instructor or the teaching assistants assigned to this
            // course. I have not used C# language code obtained from
            // another person, or any other unauthorized source, either modified or unmodified.
            // Any C# language code or documentation used in my program
            // that was obtained from another source, such as a text book, a web page,
            // or another person, have been clearly noted with proper citation in the
            // comments of my program.

            //References
            //http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c random number generator
            //https://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx accessors
            //https://msdn.microsoft.com/en-us/library/system.string.isnullorwhitespace(v=vs.110).aspx isnullorwhitespace
            //https://msdn.microsoft.com/en-us/library/f02979c7(v=vs.110).aspx int.tryparse
            //http://stackoverflow.com/questions/10804102/how-to-check-if-string-value-is-in-the-enum-list check if string value is in enum
            //https://msdn.microsoft.com/en-us/library/cc138362.aspx enums
            //https://msdn.microsoft.com/en-us/library/dd991317(v=vs.110).aspx enum.tryparse
            //http://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp check if all char values in a string are digits

            //program begins here
            Trainer me = new Trainer();
            string ch = null;
            do
            {
                #region Main Menu
                Console.WriteLine("=====POKEMON CO MENU=====");
                Console.WriteLine("1 for Register");
                Console.WriteLine("2 for Catch");
                Console.WriteLine("3 for Transfer");
                Console.WriteLine("4 for Evolve");
                Console.WriteLine("5 for View Bag");
                Console.WriteLine("6 for View Pokedex");
                Console.WriteLine("0 to QUIT");
                Console.Write("Enter choice: ");
                #endregion

                ch = Console.ReadLine();
                Console.WriteLine();
                if (ch == "1") //Register DONE
                {
                    me.Register();
                }
                else if (ch == "2") //Catch DONE
                {
                    me.Catch();
                }
                else if (ch == "3") //Transfer DONE
                {
                    me.Transfer();
                }
                else if (ch == "4") //Evolve DONE
                {
                    me.Evolve();
                }
                else if (ch == "5") //View Bag DONE
                {
                    Console.WriteLine("===== VIEW BAG =====");
                    me.ViewBag();
                }
                else if (ch == "6") //View Pokedex DONE
                {
                    me.ViewPokedex();
                }
                else if (ch == "0") //Exit DONE
                {
                }
                else
                    Console.WriteLine("Please enter a valid response.\n");
            } while (ch != "0");
        }
    }
}

