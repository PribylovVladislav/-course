namespace Practice5._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence: ");
            string text = Console.ReadLine();
            string[] splitted = SplitText(text);
            NewLines(splitted);
        }

        static string[] SplitText(string text)
        {  
            string[] splitted = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return splitted;
        }

        static void NewLines(string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
        }
    }
}