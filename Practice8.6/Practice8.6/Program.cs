using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Practice8._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t TASK #1");

            List<int> range = new List<int>();
            Random rng = new Random();
            ListMethods ls = new ListMethods();
            
            ls.ListFill(range, rng);
            ls.ListPrint(range);
            ls.ListRemove(range);
            ls.ListPrint(range);

            Console.WriteLine("Press any button to continue");
            Console.ReadKey();

            Console.WriteLine("\t TASK #2");

            Dictionary<long, string> phoneNumbers = new Dictionary<long, string>();
            while (true) 
            {
                Console.WriteLine("Enter the phone number. " +
                    "Enter the empty string to quit and go next");
                string number = Console.ReadLine();
                if (number == "") break;
                long numberLong = Convert.ToInt64(number);
                
                Console.WriteLine("Enter the initials");
                string initials = Console.ReadLine();
                
                phoneNumbers.Add(numberLong, initials);
            }

            Console.WriteLine("Enter the number you want to check");
            long numberCheck = Convert.ToInt64(Console.ReadLine());
            string value = "";
            if (phoneNumbers.TryGetValue(numberCheck, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("This number doesn't exist");
            }

            Console.WriteLine("Press any button to continue");
            Console.ReadKey();

            Console.WriteLine("\t TASK #3");

            HashSet<int> repeatCheck = new HashSet<int>();

            while (true)
            {
                Console.WriteLine("Enter the number. " +
                    "If you want to continue press q");
                string input = Console.ReadLine();
                if (input == "q") break;
                int choiseInt = Convert.ToInt32(input);
                if (repeatCheck.Add(choiseInt))
                {
                    Console.WriteLine($"Element {choiseInt} added successfully");
                }
                else
                {
                    Console.WriteLine($"{choiseInt} in the set already");
                }
            }

            Console.WriteLine("\t TASK #4");

            Person person = new Person();

            XElement xmlPerson = new XElement("Person");
            
            Console.WriteLine("Please enter your contact details");
            Console.WriteLine("Enter your initials:");
            person.initials = Console.ReadLine();
            XAttribute initialsAttribute = new XAttribute("name" ,$"{person.initials}");
            xmlPerson.Add(initialsAttribute);
            XElement xmlAdress = new XElement("Address");
            xmlPerson.Add(xmlAdress);

            Console.WriteLine("Enter the street:");
            person.street = Console.ReadLine();
            XElement xmlStreet = new XElement("Street", person.street);
            xmlAdress.Add(xmlStreet);

            Console.WriteLine("Enter the house number:");
            person.house = Console.ReadLine();
            XElement xmlHouse = new XElement("HouseNumber", person.house);
            xmlAdress.Add(xmlHouse);

            Console.WriteLine("Enter the flat number:");
            person.apartments = Console.ReadLine();
            XElement xmlFlat = new XElement("FlatNumber", person.apartments);
            xmlAdress.Add(xmlFlat);
            XElement xmlPhones = new XElement("Phones");
            xmlPerson.Add(xmlPhones);

            Console.WriteLine("Enter the mobile phone number");
            person.mobilePhone = Console.ReadLine();
            XElement xmlMobile = new XElement("MobilePhone", person.mobilePhone);
            xmlPhones.Add(xmlMobile);

            Console.WriteLine("Enter the flat phone number");
            person.apartmentPhone = Console.ReadLine();
            XElement xmlFlatPhone = new XElement("FlatPhone", person.apartmentPhone);
            xmlPhones.Add(xmlFlatPhone);

            xmlPerson.Save("_contactDetails.xml");
        }

       
    }
}