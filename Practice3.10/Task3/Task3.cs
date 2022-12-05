namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine("Вы ввели один из делителей единицы, это число не является ни простым, ни составным");
            } 
            else
            {
                // Вообще говоря, достаточно считать до корня из N
                // При факторизации хотя бы один из делителей всегда меньше корня
                for (int i = 2; i <= number; i++) 
                {
                    if (i == number - 1)
                    {
                        Console.WriteLine("Число простое");
                        break;
                    }
                    if (number % i == 0) 
                    {
                        Console.WriteLine($"Число делится на {i}");
                        break;
                    }
                    
                }
            }

            
        }
    }
}