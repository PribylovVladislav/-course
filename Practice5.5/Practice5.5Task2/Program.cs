namespace Practice5._5Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence: ");
            string inputPhrase = Console.ReadLine();
            string[] wordsArray = ReverseWords(inputPhrase);

            string resultString = "";
            for (int i = 0; i < wordsArray.Length; i++)
            {
                resultString += wordsArray[i] + " ";
            }
            Console.WriteLine(resultString);
        }
        static string[] SplitText(string text)
        {
            string[] splitted = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return splitted;
        }

        static string[] ReverseWords(string inputPhrase)
        {
            string[] text = SplitText(inputPhrase);
            Array.Reverse(text);
            return text;
        }
    }
}