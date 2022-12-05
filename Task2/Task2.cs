using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.WriteLine("Введите количество карт: ");
            string numberString = Console.ReadLine();
            int number = int.Parse(numberString);
            Console.WriteLine("Введите номиналы карт:\n" +
                    "В случае карт с числовым номиналом, вводите их номинал\n" +
                    "J - валет\n" +
                    "Q - дама\n" +
                    "K - король\n" +
                    "T - туз");

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Введите номинал следующей карты\n");
                string nominal = Console.ReadLine();
                switch (nominal)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        sum += int.Parse(nominal);
                        break;
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        sum += 10;
                        break;

                }
                Console.WriteLine($"Сумма равна: {sum}");
            }
        }
    }
}