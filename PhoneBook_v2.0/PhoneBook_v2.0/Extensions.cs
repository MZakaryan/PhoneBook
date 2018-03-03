using System;
using System.Collections.Generic;

namespace PhoneBook_v2._0
{
    static class Extensions
    {
        public static void ShowOnConsole(this Record record)
        {
            Console.WriteLine(record.ToString());
        }

        public static void SelectOption(this PhoneBook phoneBook)
        {
            while (true)
            {
                Utilities.DisplayMenu();
                switch (Utilities.GetValidNumberFromConsole())
                {
                    case 1:
                        Utilities.EnterName(out string name);
                        Utilities.EnterPhone(out string phone);
                        phoneBook.Add(new Record(name, phone));
                        break;
                    case 2:
                        Utilities.EnterName(out name);
                        phoneBook
                            .Search(name,
                            (Record Record, string Name) =>
                            Record.Name.ToLower() == name.ToLower())
                            .Move(ShowOnConsole, Console.WriteLine);
                        break;
                    case 3:
                        Utilities.EnterName(out phone);
                        phoneBook
                            .Search(phone,
                            (Record Record, string Phone) =>
                            Record.Phone.ToLower() == phone.ToLower())
                            .Move(ShowOnConsole, Console.WriteLine);
                        break;
                    case 4:
                        Console.Write("First letter: ");
                        name = Console.ReadLine();
                        phoneBook
                            .Search(name,
                            (Record record, string firstLetter) =>
                            record.Name.ToLower()[0] == name.ToLower()[0])
                            .Move(ShowOnConsole, Console.WriteLine);
                        break;
                    case 5:
                        phoneBook
                            .Move(ShowOnConsole, Console.WriteLine);
                        break;
                    case 6:
                        Utilities.EnterName(out name);
                        Utilities.EnterPhone(out phone);
                        phoneBook.RemoveAll(new Record(name, phone));
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static IEnumerable<T> Search<T>(this IEnumerable<T> array, string str,
            Func<T, string, bool> func)
        {
            foreach (T item in array)
            {
                if (func(item, str))
                {
                    yield return item;
                }
            }
        }

        public static void Move<T>(this IEnumerable<T> array,
            Action<T> action, Action<string> move)
        {
            move($"{"Name",-12}{"Phone",-5}\n");
            foreach (T item in array)
            {
                action(item);
            }
        }
    }
}