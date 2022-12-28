namespace ArrayTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] array = new int[10] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
            foreach (int i in array)
            {
                if (i % 2 == 0) sum += i;
            }
            Console.WriteLine($"Sum is {sum}");
        }
    }
}