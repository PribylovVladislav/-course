using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice10._6_Task3
{
    internal class ClientListBox
    {
        private string initials;
        public string Initials { get; set; }
        private string phone;
        public string Phone { get; set; }

        private Client client;
        public Client Client { get; set; }

        private string dateTimeEdit = "";
        public string DateTimeEdit { get; set; }
        private string personEdit = "";
        public string PersonEdit { get; set; }
        private string dataEdit = "";
        public string DataEdit { get; set; }
    }
}
