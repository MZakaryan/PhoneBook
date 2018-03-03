using System;

namespace PhoneBook_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PhoneBook v2.0";
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.SelectOption();
        }
    }
}