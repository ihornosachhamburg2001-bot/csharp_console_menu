using System;
using System.Collections.Generic;

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

        static void DrawMenu(MenuOption selectedOption, 
            Dictionary<MenuOption, string> menuItems,
            MenuOption[] menuOrder)
        {
            Console.WriteLine("MAIN MENU");

            foreach(var option in menuOrder)
            {
                if (option == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("> " + menuItems[option]);
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  " + menuItems[option]);                  
                }
                Console.ResetColor();
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

        static MenuOption NavigateMenu(MenuOption selectedOption, ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                switch (selectedOption)
                {
                    case MenuOption.Start:
                        selectedOption = MenuOption.Settings;
                        break;

                    case MenuOption.Settings:
                        selectedOption = MenuOption.Exit;
                        break;
                }
            }

            if (key == ConsoleKey.UpArrow)
            {
                switch (selectedOption)
                {
                    case MenuOption.Exit:
                        selectedOption = MenuOption.Settings;
                        break;
                    case MenuOption.Settings:
                        selectedOption = MenuOption.Start;
                        break;
                }
            }

            return selectedOption;
        }

        static void Main(string[] args)
        {
            MenuOption[] menuOrder =
            {
                MenuOption.Start,
                MenuOption.Settings,
                MenuOption.Exit
            };

            Dictionary<MenuOption, string> menuItems = new Dictionary<MenuOption, string>();

            menuItems.Add(MenuOption.Start, "Start");
            menuItems.Add(MenuOption.Settings, "Settings");
            menuItems.Add(MenuOption.Exit, "Exit");

            MenuOption selectedOption = MenuOption.Start;

            while (true)
            {
                Console.Clear();

                DrawMenu(selectedOption, menuItems, menuOrder);

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                selectedOption = NavigateMenu(selectedOption, consoleKeyInfo.Key);

                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case MenuOption.Start:                           
                            Start();                         
                            break;
                        case MenuOption.Settings:
                            OpenSettings();
                            break;
                        case MenuOption.Exit:
                            return;                     
                    }
                }
            }     
        }
    }
}
