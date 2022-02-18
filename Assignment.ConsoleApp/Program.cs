using System;

namespace Assignment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name:");
            string name = Console.ReadLine();
            Console.Write("Enter last name:");
            string lastName = Console.ReadLine();

            var list = ListProcessor.PrepareList(1, 100, name, lastName);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
