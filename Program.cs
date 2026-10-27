using System;

namespace ConsoleMenu
{
    internal class Program
    {
        enum MenuOption
        {
            Start,
            Settings,
            Exit
        }

        static void DrawMenu(int selectedIndex, string[] menuItems)
        {
            Console.WriteLine("MAIN MENU");

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.WriteLine("> " + menuItems[i]);
                }
                else { Console.WriteLine("  " + menuItems[i]); }
            }
        }

        static void Start()
        {
            Console.Clear();
            Console.WriteLine("Starting...");
            ConsoleKeyInfo consoleKeyInfo;
            Console.WriteLine("Press Escape to return in Menu.");
            do
            {
                consoleKeyInfo = Console.ReadKey(true);
            }
            while (consoleKeyInfo.Key != ConsoleKey.Escape);                
        }

        static void OpenSettings()
        {       
            Console.Clear();
            Console.WriteLine("Open settings...");
            ConsoleKeyInfo consoleKeyInfo;
            Console.WriteLine("Press Escape to return in Menu.");
            do
            {
                consoleKeyInfo = Console.ReadKey(true);
            }
            while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }

        static void Main(string[] args)
        {
            string[] menuItems = { "Start", "Settings", "Exit" };
            
            int selectedIndex = 0;
            int firstElementOfItems = 0;

            while (true)
            {
                Console.Clear();

                DrawMenu(selectedIndex, menuItems);

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.UpArrow
                    && selectedIndex > firstElementOfItems)
                {
                    selectedIndex--;                   
                }
                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow
                    && selectedIndex < (menuItems.Length - 1))
                {
                    selectedIndex++;                    
                }

                if(consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedIndex)
                    {
                        case (int)MenuOption.Start:                           
                            Start();                         
                            break;
                        case (int)MenuOption.Settings:
                            OpenSettings();
                            break;
                        case (int)MenuOption.Exit:
                            return;                     
                    }
                }
            }     
        }
    }
}
