using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tMenu \n");
                Console.WriteLine("1. Start\n2. Settings\n3. Exit");
                Console.Write("Enter a number: ");

                string input = Console.ReadLine();
                bool result = int.TryParse(input, out int selectedNumber);
                
                if (result == true)
                {
                    switch (selectedNumber)
                    {
                        case 1:
                            Console.WriteLine("You selected 1.");
                            break;
                        case 2:
                            Console.WriteLine("You selected 2.");
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Wrong number!");
                            break;
                    }
                }
            }
        }
    }
}
