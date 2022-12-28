using System.Text;
using System.Xml.Serialization;

namespace Practice6._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = FileCheck(); // file checking + returns path
            while (true)
            {
                Console.WriteLine("Press 1 if you want to read the file.\n" +
                    "Press 2 if you want to add some information.\n" +
                    "Press q to quit.");
                string choice = Console.ReadLine();
                if (choice == "q") break;
                try
                {
                    int choiseInt = Convert.ToInt32(choice);
                    if (choiseInt == 1)
                    {
                        try { ReadFile(path); }
                        catch { Console.WriteLine("File created recently and still empty"); }
                    }
                    else if (choiseInt == 2)
                    {
                        WriteToFile(path);
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }

        public static void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] splittedLines = line.Split('#');
                string outputLine = string.Join(" " ,splittedLines);
                Console.WriteLine(outputLine);
            }
        }

        public static void WriteToFile(string path)
        {
            StringBuilder outputLine = new StringBuilder();

            Console.WriteLine("Enter ID:");
            outputLine.Append(Console.ReadLine() + "#");
            
            DateTime changeDate = new DateTime();
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            outputLine.Append(date + "#");
            
            Console.WriteLine("Enter initials:");
            outputLine.Append(Console.ReadLine() + "#");
            Console.WriteLine("Enter age:");
            outputLine.Append(Console.ReadLine() + "#");
            Console.WriteLine("Enter height:");
            outputLine.Append(Console.ReadLine() + "#");
            Console.WriteLine("Enter birthday (in format dd.mm.yyyy):");
            outputLine.Append(Console.ReadLine() + "#");
            Console.WriteLine("Enter place of birth:");
            outputLine.Append(Console.ReadLine() + "#");

            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(outputLine);
            }

        }

        public static string FileCheck()
        {
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            path = path.Parent.Parent.Parent;
            if (!File.Exists(path + @"\staff.txt"))
            {
                FileStream fs = File.Create(path + @"\staff.txt");
                fs.Close();
                Console.WriteLine($"staff.txt successfully created at {path}.");   
            }
            return (path + @"\staff.txt");
        }
    }
}