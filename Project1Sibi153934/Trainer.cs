using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Sibi153934
{
    class Trainer
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

        private const int MAX = 10;
        List<PokemonRegInfo> pokedex;
        MyPokemon[] party;
        private int numparty;
        private int numCandy;
        private static readonly Random RNG = new Random();

        public Trainer()
        {
            pokedex = new List<PokemonRegInfo>();
            party = new MyPokemon[MAX];
            numCandy = 0;
            numparty = 0;
        }

        public void Register()
        {
            Console.WriteLine("=====REGISTER=====");

            string a;
            string b = null;
            string c = null;
            string d = null;
            string e = null;
            string f = null;
            string g = null;
            string h = null;

            PokemonRegInfo.pkmntype bb;
            int dd, ee, ff, gg, hh;
            bool RegEvo = false;
            bool EvoInDex = false;

            //entering the name
            do
            {
                Console.Write("Name: ");
                a = Console.ReadLine();
                //error message
                if (String.IsNullOrWhiteSpace(a) == true)
                    Console.WriteLine("Enter something.");
            } while (String.IsNullOrWhiteSpace(a) == true);


            if (this.FindInPokedex(a) == null)
            {
                do
                {
                    if (RegEvo == true)
                    {
                        Console.WriteLine("You must register the evolution of {0} too.", a);
                        a = c;
                        Console.WriteLine("Name: {0}", a);
                    }
                    //entering the type
                    bool TypeValid = Enum.TryParse<PokemonRegInfo.pkmntype>(b, true, out bb);
                    do
                    {
                        Console.Write("Type: ");
                        b = Console.ReadLine();
                        TypeValid = Enum.TryParse<PokemonRegInfo.pkmntype>(b, true, out bb);
                        //error messages
                        if (String.IsNullOrWhiteSpace(b) == true)
                            Console.WriteLine("Enter something.");
                        else if (TypeValid == false || b.All(Char.IsDigit))
                            Console.WriteLine("Enter a valid Pokemon type.");
                        else if (b.Contains(","))
                            Console.WriteLine("Enter only one type.");
                    } while (String.IsNullOrWhiteSpace(b) == true || TypeValid == false || b.All(Char.IsDigit) || b.Contains(","));
                    //entering the evolution
                    do
                    {
                        Console.Write("Evolution: ");
                        c = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(c) == true)
                            Console.WriteLine("Enter something. If Pokemon does not evolve, enter 'none'");
                        else if (c.Equals(a, StringComparison.OrdinalIgnoreCase))
                            Console.WriteLine("Evolution cannot be itself.");
                    } while (String.IsNullOrWhiteSpace(c) == true || c.Equals(a, StringComparison.OrdinalIgnoreCase));
                    if (c == "none")
                    {
                        c = null;
                        RegEvo = false;
                    }
                    else if (this.FindInPokedex(c) != null)
                    {
                        EvoInDex = true;
                        RegEvo = false;
                    }
                    else
                        RegEvo = true;

                    if (c == null)
                    {
                        dd = -1;
                        ee = -1;
                    }
                    else
                    {
                        //entering the cost
                        bool costValid = int.TryParse(d, out dd);
                        do
                        {
                            Console.Write("Cost: ");
                            d = Console.ReadLine();
                            costValid = int.TryParse(d, out dd);

                            if (costValid == false || dd <= 0)
                                Console.WriteLine("Invalid response. Try again.");

                        } while (costValid == false || dd <= 0);
                        //entering the multiplier
                        bool multiplierValid = int.TryParse(e, out ee);
                        do
                        {
                            Console.Write("Multiplier: ");
                            e = Console.ReadLine();
                            multiplierValid = int.TryParse(e, out ee);

                            if (multiplierValid == false || ee <= 1)
                                Console.WriteLine("Invalid response. Try again.");

                        } while (multiplierValid == false || ee <= 1);
                    }
                    //entering capture difficulty
                    bool diffValid = int.TryParse(f, out ff);
                    do
                    {
                        Console.Write("Capture Difficulty. Enter a value (1-6). 1 = hardest, 6 = easiest: ");
                        f = Console.ReadLine();
                        diffValid = int.TryParse(f, out ff);

                        if (diffValid == false || ff <= 0 || ff > 6)
                            Console.WriteLine("Invalid response. Try again.");

                    } while (diffValid == false || ff <= 0 || ff > 6);
                    //entering fleerate
                    bool fleeValid = int.TryParse(g, out gg);
                    do
                    {
                        Console.Write("Flee rate. Enter a value (1-6). 1 = least likely to flee, 6 = most likely to flee: ");
                        g = Console.ReadLine();
                        fleeValid = int.TryParse(g, out gg);

                        if (fleeValid == false || gg <= 0 || gg > 6)
                            Console.WriteLine("Invalid response. Try again.");

                    } while (fleeValid == false || gg <= 0 || gg > 6);
                    //entering tier
                    bool TierValid = int.TryParse(h, out hh);
                    do
                    {
                        Console.Write("Tier. (1-4). 1 = highest, 4 = lowest: ");
                        h = Console.ReadLine();
                        TierValid = int.TryParse(h, out hh);
                        if (TierValid == false || hh <= 0 || hh > 4)
                            Console.WriteLine("Invalid response. Try again.");
                    } while (TierValid == false || hh <= 0 || hh > 4);

                    pokedex.Add(new PokemonRegInfo(a, bb, c, dd, ee, ff, gg, hh));
                    Console.WriteLine("{0} SUCCESSFULLY REGISTERED TO POKEDEX.", a);
                    //Console.WriteLine("Catch rate: {0}", pokedex[pokedex.Count - 1].getCatchRate());
                    //Console.WriteLine("Flee rate: {0}\n", pokedex[pokedex.Count - 1].getFleeRate());
                    if (EvoInDex == true)
                        Console.WriteLine("Since {0}'s evolution, {1}, is already registered in the Pokedex. You do not need to register {1}.\n", a, c);
                } while (RegEvo == true);
            }
            else
            {
                Console.WriteLine("THAT POKEMON HAS ALREADY BEEN REGISTERED.\n");
            }
        }

        public void Catch()
        {
            if (this.pokedex.Count == 0) //IF POKEDEX IS EMPTY
            {
                Console.WriteLine("POKEDEX IS EMPTY. UNABLE TO CATCH ANY POKEMON.\n");
            }
            else if (numparty < 10) //IF POKEDEX IS NOT EMPTY AND BAG IS NOT FULL
            {
                Console.WriteLine("=====CATCH=====");

                string a;
                int b = 0;
                int c = 0;

                do
                {
                    Console.Write("Name: ");
                    a = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(a) == true)
                        Console.WriteLine("Enter something.");
                } while (String.IsNullOrWhiteSpace(a) == true);

                if (this.FindInPokedex(a) != null)
                {
                    a = this.FindInPokedex(a).getPkmnname();
                    //randomly generating HP based on tier
                    if (this.FindInPokedex(a).getTier() == 4)
                    {
                        b = RNG.Next(20, 100);
                    }
                    else if (this.FindInPokedex(a).getTier() == 3)
                    {
                        b = RNG.Next(100, 300);
                    }
                    else if (this.FindInPokedex(a).getTier() == 2)
                    {
                        b = RNG.Next(300, 500);
                    }
                    else if (this.FindInPokedex(a).getTier() == 1)
                    {
                        b = RNG.Next(500, 880);
                    }
                    //randomly generating CP based on tier
                    if (this.FindInPokedex(a).getTier() == 4)
                    {
                        c = RNG.Next(100, 400);
                    }
                    else if (this.FindInPokedex(a).getTier() == 3)
                    {
                        c = RNG.Next(400, 700);
                    }
                    else if (this.FindInPokedex(a).getTier() == 2)
                    {
                        c = RNG.Next(700, 1000);
                    }
                    else if (this.FindInPokedex(a).getTier() == 1)
                    {
                        c = RNG.Next(1000, 10000);
                    }

                    int[] Catch = new int[4]; //create array of 4 randomly generated integers
                    int Flee;
                    int CatchRate = this.FindInPokedex(a).getCatchRate();
                    int FleeRate = this.FindInPokedex(a).getFleeRate();
                    bool EndBattle = false;
                    do
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Catch[i] = RNG.Next(255); //generating four random numbers
                            //Console.WriteLine("Catch Rate: {0}/{1}", Catch[i], CatchRate);
                        }
                        //if all numbers are lesser than its catch rate, it will be caught
                        if (Catch[0] <= CatchRate && Catch[1] <= CatchRate && Catch[2] <= CatchRate && Catch[3] <= CatchRate) // successful capture
                        {
                            party[numparty] = new MyPokemon(a, b, c);
                            numparty++;
                            numCandy += 3;
                            EndBattle = true;
                            Console.WriteLine("{0} HAS BEEN CAUGHT!\n", a);
                        }
                        else //escaped from ball
                        {
                            Console.WriteLine("{0} ESCAPED FROM THE POKEBALL.\n", a);
                            string TryAgain;
                            bool ValidResponse = true;
                            Flee = RNG.Next(255);
                            //Console.WriteLine("Flee Rate: {0}/{1}", Flee, FleeRate);

                            if (Flee >= FleeRate) //if pkmn didn't run away
                            {
                                do
                                {
                                    Console.Write("Try again? (y/n): ");
                                    TryAgain = Console.ReadLine();
                                    if (TryAgain == "y" || TryAgain == "Y") //try again
                                    {
                                        break;
                                    }
                                    else if (TryAgain == "N" || TryAgain == "n") //don't try again
                                    {
                                        Console.Write("YOU RAN AWAY.");
                                        EndBattle = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid response.");
                                        ValidResponse = false;
                                    }
                                } while (ValidResponse == false);
                            }
                            else //if it ran away
                            {
                                Console.WriteLine("{0} GOT AWAY.\n", a);
                                EndBattle = true;
                            }
                        }
                    } while (EndBattle == false);
                }
                else
                {
                    Console.WriteLine("{0} DOES NOT EXIST IN POKEDEX.\n", a);
                }
            }
            else
            {
                Console.WriteLine("YOUR BAG IS FULL.\n");
            }
        }

        public void Transfer()
        {
            Console.WriteLine("===== TRANSFER =====");
            this.ViewBag();

            if (numparty != 0)
            {
                string a = null;
                uint aa;
                bool IDValid = uint.TryParse(a, out aa);
                Console.Write("Enter ID: ");
                a = Console.ReadLine();
                IDValid = uint.TryParse(a, out aa);

                if (IDValid == false || aa > 10 || aa == 0)
                    Console.WriteLine("Invalid ID.\n");
                else
                {
                    numCandy++;
                    numparty--;
                    Console.WriteLine("{0} SUCCESSFULLY TRANSFERRED. YOU RECEIVED 1 CANDY\n.", party[aa - 1].Name);
                    party[aa - 1] = null;
                    for (uint j = aa - 1; j < numparty; j++)
                    {
                        party[j] = party[j + 1];
                    }
                    party[numparty] = null;
                }
            }
            else
            {
                Console.WriteLine("UNABLE TO USE THIS FUNCTION.\n");
            }
        }

        public void Evolve()
        {
            Console.WriteLine("===== EVOLVE =====");
            this.ViewBag();

            if (numparty != 0)
            {
                string a = null;
                uint aa;
                bool IDValid = uint.TryParse(a, out aa);
                Console.Write("Enter ID: ");
                a = Console.ReadLine();
                IDValid = uint.TryParse(a, out aa);

                if (IDValid == false || aa > 10 || aa == 0)
                    Console.WriteLine("Invalid ID.");
                else
                {
                    PokemonRegInfo RegInfo = this.FindInPokedex(party[aa - 1].Name);

                    if (RegInfo.getCost() > numCandy)
                    {
                        Console.WriteLine("YOU DO NOT HAVE ENOUGH CANDY. ({0}/{1})", numCandy, RegInfo.getCost());
                    }
                    else if (RegInfo.getEvo() == null)
                    {
                        Console.WriteLine("{0} CANNOT BE EVOLVED FURTHER.", party[aa - 1].Name);
                    }
                    else
                    {
                        numCandy -= RegInfo.getCost();
                        Console.WriteLine("{0} HAS EVOLVED INTO {1}!\n", party[aa - 1].Name, RegInfo.getEvo());
                        party[aa - 1].Name = RegInfo.getEvo();
                        party[aa - 1].HP *= RegInfo.getMultiplier();
                        party[aa - 1].CP *= RegInfo.getMultiplier();
                    }
                }
            }
            else
            {
                Console.WriteLine("UNABLE TO USE THIS FUNCTION.\n");
            }
        }

        public void ViewBag()
        {
            if (numparty != 0)
            {
                Console.WriteLine("ID  NAME         HP   CP");
                for (int i = 0; i < numparty; i++)
                {
                    Console.WriteLine(String.Format("{0,-4}{1,-13}{2,-5}{3}", i + 1, party[i].Name, party[i].HP, party[i].CP));
                }
            }
            else
            {
                Console.WriteLine("Your bag is empty");
            }
            Console.WriteLine("==================");
            Console.WriteLine("Bag Capacity: {0}/{1}", numparty, MAX);
            Console.WriteLine("Candy: {0}\n", numCandy);
        }

        public void ViewPokedex()
        {
            Console.WriteLine("=====VIEW POKEDEX=====");

            if (pokedex.Count == 0)
            {
                Console.WriteLine("YOUR POKEDEX IS EMPTY.\n");
            }
            else
            {
                Console.WriteLine("ID  NAME         TYPE        EVOLUTION");
                string evolution = null;

                for (int i = 0; i < pokedex.Count; i++)
                {
                    if (pokedex[i].getEvo() == null)
                    {
                        evolution = "---";
                    }
                    else
                    {
                        evolution = pokedex[i].getEvo();
                    }
                    Console.WriteLine(String.Format("{0,-4}{1,-13}{2,-12}{3}", i + 1, pokedex[i].getPkmnname(), pokedex[i].getType(), evolution));
                }
                Console.WriteLine("======================");
                Console.WriteLine("TOTAL REGISTERED: {0}\n", pokedex.Count);
            }
        }

        public PokemonRegInfo FindInPokedex(string name)
        {
            for (int i = 0; i < pokedex.Count; i++)
            {
                if (name.Equals(pokedex[i].getPkmnname(), StringComparison.OrdinalIgnoreCase))
                {
                    return pokedex[i];
                }
            }
            return null;
        }
    }
}