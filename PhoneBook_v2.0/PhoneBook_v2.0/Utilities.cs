using System;

namespace PhoneBook_v2._0
{
    enum MenuOption
    {
        Add = 1,
        Search_By_Name,
        Search_By_Phone,
        Search_By_First_Letter,
        Display,
        Delete,
        Exit,
    }
    static class Utilities
    {
        public static int GetValidNumberFromConsole()
        {
            while (true)
            {
                string number = Console.ReadLine();
                int length = Enum.GetValues(typeof(MenuOption)).Length;
                if (Int32.TryParse(number, out int validNumber))
                {
                    if (validNumber < 1 || validNumber > length)
                    {
                        Console.Write($"Enter valid number[{1},{length}]: ");
                        continue;
                    }
                    return validNumber;
                }
                else
                {
                    Console.Write($"Enter valid number[{1},{length}]: ");
                }
            }
        }
       
        public static void DisplayMenu()
        {
            Console.WriteLine("Menu");
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine("{0,-3}{1,-15}", (int)option, option.ToString());
            }
            Console.Write("Select options: ");
        }

        public static void EnterName(out string name)
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        public static void EnterPhone(out string phone)
        {
            Console.Write("Phone: ");
            phone = Console.ReadLine();
        }

    }
}
