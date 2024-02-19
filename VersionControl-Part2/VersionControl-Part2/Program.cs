using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionControl_Part2
{
    internal class Program
    {
        private static Random _rand = new Random();

        static void Main(string[] args)
        {
            var active = true;
            while (active)
            {
                PrintMenu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RandomInteger();
                        break;
                    case "2":
                        TodaysDate();
                        break;
                    case "3":
                        RandomDinosaur();
                        break;
                    case "4":
                        RandomStringMod();
                        break;
                    case "q":
                    case "Q":
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry, please try again");
                        break;
                }
            }
        }

        static void PrintMenu()
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

        static void RandomInteger()
        {
            Console.WriteLine($"Your random number is: {_rand.Next(1,11)}");
        }

        static void TodaysDate()
        {
            Console.WriteLine($"Today's date is: {DateTime.Now.ToShortDateString()}");
        }

        static void RandomDinosaur()
        {
            var dinos = new List<string> { "Austrosaurus", "Changyuraptor", "Dilophosaurus", "Koreaceratops", "Pararhabdodon",
            "Nanosaurus", "Dongyangopelta", "Vespersaurus", "Normanniasaurus", "Chromogisaurus"};
            var orderedDinos = dinos.OrderBy(d => d).ToList();

            Console.WriteLine($"Random dinosaur: {orderedDinos[_rand.Next(0,10)]}");
        }

        static void RandomStringMod()
        {
            Console.Write("Enter a random string: ");
            var entry = Console.ReadLine();
            
            switch(_rand.Next(0, 10))
            {
                case 0: 
                    Console.WriteLine($"ToUpper: {entry.ToUpper()}");
                    break;
                case 1:
                    Console.WriteLine($"ToLower: {entry.ToLower()}");
                    break;
                case 2:
                    Console.WriteLine($"Reverse: {string.Concat(Enumerable.Reverse(entry))}");
                    break;
                case 3:
                    if(entry.Length > 2)
                    {
                        Console.WriteLine($"Substrting - 2: {entry.Substring(entry.Length - 2)}");
                    }
                    else
                    {
                        Console.WriteLine("To short of string to substring");
                    }
                    break;
                case 4:
                    Console.WriteLine($"Length: {entry.Length}");
                    break;
                case 5:
                    Console.WriteLine($"Append an A: {entry.Append('A')}");
                    break;
                case 6:
                    Console.WriteLine($"Hash code: {entry.GetHashCode()}");
                    break;
                case 7:
                    Console.WriteLine($"Contains an e: {entry.Contains('e')}");
                    break;
                case 8:
                    Console.WriteLine($"First index of an e: {entry.IndexOf('e')}");
                    break;
                case 9:
                    Console.WriteLine($"All E replaced with 3: {entry.Replace("e", "3")}");
                    break;
            }
        }
    }
}
