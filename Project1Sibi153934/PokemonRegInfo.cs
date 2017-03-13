using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Sibi153934
{
    class PokemonRegInfo
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

        private string pkmnname;
        private pkmntype type;
        private string evo;
        private int cost;
        private int multiplier;
        private int catchrate;
        private int fleerate;
        private int tier;
        private static readonly Random RateRand = new Random();
        public enum pkmntype { Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel, Fire, Grass, Water, Electric, Psychic, Ice, Dragon, Dark, Fairy };

        public PokemonRegInfo(string pkmnname, pkmntype type, string evo, int cost, int multiplier, int difficulty, int fleerate, int tier)
        {
            this.pkmnname = pkmnname;
            this.type = type;
            this.evo = evo;
            this.cost = cost;
            this.multiplier = multiplier;

            //generating random catch rate between 4-255
            int a = difficulty;
            int x = 4 + 42 * (a - 1);
            this.catchrate = RateRand.Next(x, 3 + 42 * a);

            //generating random flee rate between 4-255
            int b = fleerate;
            int y = 4 + 42 * (b - 1);
            this.fleerate = RateRand.Next(y, 3 + 42 * b);

            this.tier = tier;
        }

        public string getPkmnname()
        {
            return pkmnname;
        }

        public pkmntype getType()
        {
            return type;
        }

        public string getEvo()
        {
            return evo;
        }

        public int getCost()
        {
            return cost;
        }

        public int getMultiplier()
        {
            return multiplier;
        }

        public int getCatchRate()
        {
            return catchrate;
        }

        public int getFleeRate()
        {
            return fleerate;
        }

        public int getTier()
        {
            return tier;
        }
    }
}
