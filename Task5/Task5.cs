namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomize = new Random();

            Console.WriteLine("Введите максимальное число диапазона\n");
            int border = int.Parse(Console.ReadLine());

            int randomNumber = randomize.Next(0, border + 1);
            Console.WriteLine("Число загадно. Вводите числа и попытайтесь угадать его." +
                " Чтобы выйти, введите пустую строку");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "") break;
                int inputNumber = int.Parse(input);
                if (inputNumber < randomNumber) Console.WriteLine("Число меньше задуманного");
                else if (inputNumber > randomNumber) Console.WriteLine("Число больше задуманного");
                else
                {
                    Console.WriteLine("Вы угадали!");
                    break;
                }
            }
        }
    }
}