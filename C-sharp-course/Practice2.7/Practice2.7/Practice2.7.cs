using System;

class Program
{
    static void Main(string[] args)
    {
        string initials = "Иванов Иван Иванович";
        int age = 24;
        string email = "ivanov@gmail.com";
        decimal programmingPoints = 88;
        decimal mathPoints = 98;
        decimal physicsPoints = 78;

        Console.Write($"Имя: {initials} \nВозраст: {age} \nEmail: {email} \nБаллы по программированию: {programmingPoints} \nБаллы по математике: {mathPoints} \nБаллы по физике: {physicsPoints}\n");
        Console.ReadKey();

        decimal sumPoints = programmingPoints + mathPoints + physicsPoints;
        decimal averagePoint = sumPoints / 3;

        Console.Write($"\nСумма баллов: {sumPoints} \nСредний балл: {averagePoint}");
        Console.ReadKey();

    }
}


