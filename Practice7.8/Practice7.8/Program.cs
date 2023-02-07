using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Enumeration;
using System.Text;

namespace Practice7._8
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Repository rep = new Repository();
            while (true)
            {
                Console.WriteLine("Press 1 if you want to read the file.\n" +
                    "Press 2 if you want to add some information.\n" +
                    "Press 3 if you want to read the information about any worker. \n" +
                    "Press 4 if you want to delete some data. \n" +
                    "Press 5 if you want to check the workers by some range of dates. \n" +
                    "Press q to quit.");
                string choice = Console.ReadLine();
                if (choice == "q") break;
                try
                {
                    int choiseInt = Convert.ToInt32(choice);
                    if (choiseInt == 1)
                    {
                        try
                        {
                            Worker[] workers = rep.GetAllWorkers();
                            foreach (Worker worker in workers)
                            {
                                Console.WriteLine(worker.ConvertWorkerToString(worker));
                            }
                        }
                        catch { Console.WriteLine("File created recently and still empty"); }
                    }
                    else if (choiseInt == 2)
                    {
                        Worker newWorker = new Worker();
                        Console.WriteLine("Enter ID:");
                        newWorker.id = Convert.ToInt32(Console.ReadLine());
                        newWorker.writeTime = DateTime.Now;
                        Console.WriteLine("Enter initials:");
                        newWorker.initials = Console.ReadLine();
                        Console.WriteLine("Enter age:");
                        newWorker.age = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("Enter height:");
                        newWorker.height = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("Enter birthday (in format dd.mm.yyyy):");
                        newWorker.birthday = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter place of birth:");
                        newWorker.birthPlace = Console.ReadLine();

                        rep.AddWorker(newWorker);
                    }
                    else if (choiseInt == 3)
                    {
                        Worker worker = new Worker();
                        Console.WriteLine("Enter ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        worker = rep.GetWorkerById(id);
                        Console.WriteLine(worker.ConvertWorkerToString(worker));
                    }
                    else if (choiseInt == 4)
                    {
                        Worker worker = new Worker();
                        Console.WriteLine("Enter ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        rep.RemoveWorker(id);
                        Console.WriteLine("Worker removed successfully.");
                    }
                    else if (choiseInt == 5)
                    {
                        Console.WriteLine("Enter date from:");
                        DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter date to:");
                        DateTime dateTo = DateTime.Parse(Console.ReadLine());
                        Worker[] workerList = rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        workerList = workerList.OrderBy(worker => worker.writeTime).ToArray();

                        foreach (Worker worker in workerList)
                        {
                            Console.WriteLine(worker.ConvertWorkerToString(worker));
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input");
                    throw;
                }
            }
        }

        class Repository
        {
            private Worker[] workers;

            private string fileName = "staff.txt"; 
            public string FileName
            {
                get { return fileName; }
                set { fileName = value; }
            }

            public Worker[] GetAllWorkers()
            {
                string path = FileCheck(); // file checking + returns path

                string[] lines = File.ReadAllLines(path);
                Worker[] workers = new Worker[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string linesId = lines[i].Split('#')[0];
                    int linesIdInt = Convert.ToInt32(linesId); 

                    workers[i].id = linesIdInt;

                    string writeTimeString = lines[i].Split('#')[1];
                    DateTime writeTimeDateTime = Convert.ToDateTime(writeTimeString);

                    workers[i].writeTime = writeTimeDateTime;

                    string initialsString = lines[i].Split('#')[2];

                    workers[i].initials = initialsString;

                    string ageString = lines[i].Split('#')[3];
                    byte ageByte = Convert.ToByte(ageString);

                    workers[i].age = ageByte;

                    string heightString = lines[i].Split('#')[4];
                    byte heightByte = Convert.ToByte(heightString);

                    workers[i].height = heightByte;

                    string birthdayString = lines[i].Split('#')[5];
                    DateTime birthdayDate = Convert.ToDateTime(birthdayString);

                    workers[i].birthday = birthdayDate;

                    string birthPlaceString = lines[i].Split('#')[6];

                    workers[i].birthPlace = birthPlaceString;
                }
                return workers;
                
                
            }

            public Worker GetWorkerById(int id)
            {
                string path = FileCheck(); // file checking + returns path
                string[] lines = File.ReadAllLines(path);

                int index = IndexRecieving(id, lines);
                Worker worker = new Worker(
                    Convert.ToInt32(lines[index].Split('#')[0]),
                    Convert.ToDateTime(lines[index].Split('#')[1]),
                    lines[index].Split('#')[2],
                    Convert.ToByte(lines[index].Split('#')[3]),
                    Convert.ToByte(lines[index].Split('#')[4]),
                    Convert.ToDateTime(lines[index].Split('#')[5]),
                    lines[index].Split('#')[6]
                );
                return worker;
            }

            public void AddWorker(Worker worker)
            {
                string path = FileCheck(); // file checking + returns path
                string[] lines = File.ReadAllLines(path);

                if (IndexRecieving(worker.id, lines ) == -1) 
                    {
                        StringBuilder outputLine = new StringBuilder();
                        outputLine.Append( 
                            Convert.ToString(worker.id) + "#" +
                            Convert.ToString(worker.writeTime) + "#" +
                            worker.initials + "#" +
                            Convert.ToString(worker.age) + "#" +
                            Convert.ToString(worker.height) + "#" +
                            Convert.ToString(worker.birthday) + "#" +
                            worker.birthPlace
                            );
                        using (StreamWriter streamWriter = File.AppendText(path))
                        {
                            streamWriter.WriteLine(outputLine);
                        }
                }
            }

            public void RemoveWorker(int id)
            {
                string path = FileCheck(); // file checking + returns path
                string[] lines = File.ReadAllLines(path);

                int findingID = IndexRecieving(id, lines);
                if (findingID != -1)
                {
                    for(int i = findingID; i < lines.Length - 1; i++)
                    {
                        lines[i] = lines[i + 1];
                    }
                    Array.Resize(ref lines, lines.Length - 1);

                    using (StreamWriter streamWriter = new StreamWriter(path, false))
                    {
                        foreach (string line in lines)
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
            }

            public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
            {
                Worker[] workers = GetAllWorkers();
                workers = workers.Where(worker => (dateFrom <= worker.writeTime) && (dateTo >= worker.writeTime)).ToArray();
                return workers;
            }

            public string FileCheck()
            {
                DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
                path = path.Parent.Parent.Parent;
                if (!File.Exists(path + @"\" + FileName))
                {
                    FileStream fs = File.Create(path + @"\" + FileName);
                    fs.Close();
                    Console.WriteLine($"{FileName} successfully created at {path}.");
                }
                return (path + @"\" + FileName);
            }

            public int IndexRecieving(int id, string[] lines)
            {
                int index;
                int[] indexArray = new int[lines.Length];
                for(int i=0; i < lines.Length; i++)
                {
                    indexArray[i] = Convert.ToInt32(lines[i].Split('#')[0]);
                }
                try
                {
                    index = Array.IndexOf(indexArray, id);
                }
                catch 
                {
                    index = - 1;
                    Console.WriteLine("Invalid ID");
                }
                return index;
            }
        }
    }
}