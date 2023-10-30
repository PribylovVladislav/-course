using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice10._6_Task3
{
    internal class Client : IComparable
    {
        public Client(string surname, string name, string patronymic,
           string passportSeries, string passportNumber, string phone, string id)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
            this.phone = phone;
            this.id = id;
        }
 
        public Client(string surname, string name, string patronymic,
           string passportSeries, string passportNumber, string phone) 
            : this(surname, name, patronymic, passportSeries, passportNumber, phone, "0")
        {

        }


        private string surname;
        public string Surname { get { return surname; } set { surname = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string patronymic;
        public string Patronymic { get { return patronymic; } set { patronymic = value; } }

        private string passportSeries;
        public string PassportSeries { get { return passportSeries; } set { passportSeries = value; } }

        private string passportNumber;
        public string PassportNumber { get { return passportNumber; } set { passportNumber = value; } }

        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }

        private string id;
        public string Id { get { return id; } set { id = value; } }
        private string dateTimeEdit = "";
        public string DateTimeEdit { get; set; }
        private string personEdit = "";
        public string PersonEdit { get; set; }
        private string dataEdit = "";
        public string DataEdit { get; set; }

        public string ClientToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(surname + '#');
            sb.Append(name + '#');
            sb.Append(patronymic + '#');
            sb.Append(passportSeries + '#');
            sb.Append(passportNumber + '#');
            sb.Append(Phone + '#');
            sb.Append(id);
            return sb.ToString();
        }

        public static bool operator >(Client client1, Client client2)
        {
            char[] clientCharArray1 = client1.ClientToString().ToArray();
            char[] clientCharArray2 = client2.ClientToString().ToArray();
            int i = -1;
            do i++;
            while (clientCharArray1[i] == clientCharArray2[i]);

            return clientCharArray1[i] > clientCharArray2[i];
        }
        public static bool operator <(Client client1, Client client2)
        {
            char[] clientCharArray1 = client1.ClientToString().ToArray();
            char[] clientCharArray2 = client2.ClientToString().ToArray();
            int i = 0;
            do i++;
            while (clientCharArray1[i] == clientCharArray2[i]);

            return clientCharArray1[i] < clientCharArray2[i];
        }

        public int CompareTo(object obj)
        {
            if (this.GetType() != obj.GetType()) 
            {
                throw (new ArgumentException("Both objects being compared must be of type Client"));
            }
            else
            {
                Client otherClient = (Client)obj;

                if (otherClient == this)
                {
                    return 0;
                }
                else if (this > otherClient)
                {
                    return 1;
                }
                else if(otherClient > this)
                {
                    return -1;
                }
                else
                { 
                    return -1; 
                }
            }
        }
    }
}
