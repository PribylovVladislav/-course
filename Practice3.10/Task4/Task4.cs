namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minValue = int.MaxValue;
            Console.WriteLine("Введите количество чисел:\n");
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Введите число:\n");
                int number = int.Parse(Console.ReadLine());
                if (number < minValue) minValue = number;
            }
            Console.WriteLine($"Наименьшее значение: {minValue}");
        }
    }
}