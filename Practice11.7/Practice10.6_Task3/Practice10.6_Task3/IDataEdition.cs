using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice10._6_Task3
{
    internal interface IDataEdition
    {
        public Client Edit(Client selectedClient, Client editedClient)
        {
            return editedClient;
        }
    }
}
