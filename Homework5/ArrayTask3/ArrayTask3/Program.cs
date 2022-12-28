namespace ArrayTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            Console.WriteLine("Enter the number you want to find:");
            string value = Console.ReadLine();
            if (int.TryParse(value, out int intValue))
            {
                int output = -1;
                for (int i = 0; i < array.Length; i++ )
                {
                    if (array[i] == intValue)
                    {
                        output = i;
                        break;
                    }
                }
                if (output != -1) Console.WriteLine($"Needed number in {output} position.");
                else Console.WriteLine($"{output}. Needed number not found.");
            }
            
        }
    }
}