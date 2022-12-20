using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число: ");
            string numberString = Console.ReadLine();
            int number = int.Parse(numberString);

            if (number % 2 == 0) Console.WriteLine("Число чётное");
            else Console.WriteLine("Число нечётное");
        }
    }
}
