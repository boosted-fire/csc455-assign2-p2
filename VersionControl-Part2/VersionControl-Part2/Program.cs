using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VersionControl_Part2
{
    public class Program
    {
        private static Random _rand = new Random();

        public static void Main(string[] args)
        {
            var active = true;
            while (active)
            {
                PrintMenu();
                var input = Console.ReadLine();

                if(input == "q" || input == "Q")
                {
                    active = false;
                    Console.WriteLine("GOODBYE");
                    break;
                }
                else
                {
                    Input(input);
                }
            }
        }

        public static bool Input(string input)
        {
            var valid = false;

            switch (input)
            {
                case "1":
                    valid = true;
                    Console.WriteLine($"Your random number is: {RandomInteger()}");
                    break;
                case "2":
                    valid = true;
                    Console.WriteLine(TodaysDate());
                    break;
                case "3":
                    valid = true;
                    Console.WriteLine(RandomDinosaur());
                    break;
                case "4":
                    valid = true;
                    Console.WriteLine(RandomStringMod());
                    break;
                default:
                    valid = false;
                    Console.WriteLine("Invalid entry, please try again");
                    break;
            }
            return valid;
        }

        public static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Random Integer 1-10");
            Console.WriteLine("2. Today's Date");
            Console.WriteLine("3. Display Random Dinosaur");
            Console.WriteLine("4. Random String Modification");
            Console.WriteLine("Enter q to Quit");
            Console.WriteLine("-------------------------");
        }

        public static int RandomInteger()
        {
           return _rand.Next(1,11);
        }

        public static string TodaysDate()
        {
            return $"Today's date is: {DateTime.Now.ToShortDateString()}";
        }

        public static string RandomDinosaur()
        {
            var dinos = new List<string> { "Austrosaurus", "Changyuraptor", "Dilophosaurus", "Koreaceratops", "Pararhabdodon",
            "Nanosaurus", "Dongyangopelta", "Vespersaurus", "Normanniasaurus", "Chromogisaurus"};
            var orderedDinos = dinos.OrderBy(d => d).ToList();

            return $"Random dinosaur: {orderedDinos[_rand.Next(0,10)]}";
        }

        public static string RandomStringMod()
        {
            try
            {
                Console.Write("Enter a random string: ");
                var entry = Console.ReadLine();

                switch (_rand.Next(0, 10))
                {
                    case 0:
                        return $"ToUpper: {entry.ToUpper()}";
                    case 1:
                        return $"ToLower: {entry.ToLower()}";
                    case 2:
                        return $"Reverse: {string.Concat(Enumerable.Reverse(entry))}";
                    case 3:
                        if (entry.Length > 2)
                        {
                            return $"Substrting - 2: {entry.Substring(entry.Length - 2)}";
                        }
                        else
                        {
                            return "To short of string to substring";
                        }
                    case 4:
                        return $"Length: {entry.Length}";
                    case 5:
                        return $"Append an A: {entry.Append('A')}";
                    case 6:
                        return $"Hash code: {entry.GetHashCode()}";
                    case 7:
                        return $"Contains an e: {entry.Contains('e')}";
                    case 8:
                        return $"First index of an e: {entry.IndexOf('e')}";
                    case 9:
                        return $"All E replaced with 3: {entry.Replace("e", "3")}";
                    default:
                        return "ERROR";
                }
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.ToString());
                
                return null;
            }
        }
    }
}
