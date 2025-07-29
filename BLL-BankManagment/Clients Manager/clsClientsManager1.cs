using DAL_BankManagment;
using DAL_BankManagment.Clients;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;



namespace Manager
{
    public partial class clsClientsManager
    {
        private static List<clsClient> Clients;

        private static int GetClientIndexFromList (short Id)
        {
            int index = Clients.FindIndex(client => client.Id == Id);

            return index;
        }

        private static void AddClientToList (clsClient client)
        {
            Clients.Add(client);
        }

        private static bool DeleteClientFromList (short Id)
        {
            int index = GetClientIndexFromList(Id);

            if (index != -1)
            {
                Clients.RemoveAt(index);
                return true;
            }

            return false;

        }

        private static bool UpdateClientFromList (clsClient client)
        {
            int index = GetClientIndexFromList(client.Id);

            if (index != -1)
            {
                Clients[index] = client;
                return true;
            }

            return false; 
        }
        private static List<clsClient>  GetClientFromList(string Name)
        {
            List<clsClient > clients = new List<clsClient> ();

            foreach (clsClient client in Clients)
            {
                if (client.Person.FirstName == Name
                    || client.Person.LastName == Name
                    || client.Person.FullName() == Name)
                {
                    clients.Add(client);
                }
            }

            return clients;
        }

    }
}
