namespace ArraysTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 7; i < 22; i++)
            {
                if (i % 2 == 0) sum += i;
            }
            Console.WriteLine($"Sum is {sum}");
        }
    }
}