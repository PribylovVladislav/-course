using System.Net.NetworkInformation;

namespace ArrayTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
            string arrayStr = ArrayToString(array);
            Console.WriteLine($"Initial array:\n {arrayStr}");
            for (int i = 0; i < array.Length; i++)
            {
                int min = int.MaxValue;
                int pos = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        pos = j;
                    }
                }
                if (min < array[i])
                {
                    int temp = array[i];
                    array[i] = min;
                    array[pos] = temp;
                }
            }
            arrayStr = ArrayToString(array);
            Console.WriteLine($"Sorted array:\n {arrayStr}");
        }

        public static string ArrayToString(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].ToString();
            }
            return string.Join(", ", array);
        }
       
    }
}