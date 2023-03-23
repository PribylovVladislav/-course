using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice10._6_Task3
{
    internal class Client
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
    }
}
