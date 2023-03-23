﻿using System.Threading.Tasks;

namespace Practice10._6_Task2
{
    internal class Consultant
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

    }
}
