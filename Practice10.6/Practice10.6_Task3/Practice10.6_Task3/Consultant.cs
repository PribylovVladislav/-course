using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice10._6_Task3
{
    internal class Consultant : IDataEdition
    {
        public Consultant(string surname, string name, string patronymic,
           string passportSeries, string passportNumber, string phone)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
            this.phone = phone;
        }
        
        public Consultant()
        {

        }
        
        private string surname;
        public string Surname { get { return surname; } set { surname = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string patronymic;
        public string Patronymic { get { return patronymic; } set { patronymic = value; } }

        private string passportSeries;
        public string PassportSeries { get { return new string('*', passportSeries.Length); } set { passportSeries = value; } }

        private string passportNumber;
        public string PassportNumber { get { return new string('*', passportNumber.Length); } set { passportNumber = value; } }

        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }

        public virtual Client Edit( Client selectedClient, Client editedClient)
        {
            var dict = new Dictionary<int, string>
            {
                {0, "фамилия" },
                {1, "имя" },
                {2, "отчество" },
                {3, "серия паспорта" },
                {4, "номер паспорта" },
                {5, "телефон" },
                {6, "ID" }
            };
            editedClient.DateTimeEdit = DateTime.Now.ToString();
            string[] strSelClient = selectedClient.ClientToString().Split("#");
            string[] strEditClient = editedClient.ClientToString().Split("#");
            List<string> changedData = new List<string>();
            for(int i = 0; i < strSelClient.Length; i++)
            {
                if (strSelClient[i] != strEditClient[i])
                {
                    string data = dict[i];
                    changedData.Add(data);
                }
            }
            if (changedData.Count > 1) 
            {
                editedClient.DataEdit = $"Изменены: {String.Join(", ", changedData.ToArray())}";
            }
            else
            {
                editedClient.DataEdit = $"Изменены: {changedData[0]}";
            }
            editedClient.PersonEdit = "Изменено: Консультант";

            return editedClient;
        }
    }
}
