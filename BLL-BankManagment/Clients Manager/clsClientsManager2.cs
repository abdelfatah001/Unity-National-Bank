using Models;
using DAL_BankManagment.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public partial class clsClientsManager
    {

        public static void LoadClients()
        {
            Clients = clsReadClients.GetAllClients();

        }

        public static short AddClient(clsClient client)
        {

            short ClientId = -1;

            ClientId = clsInsertClient.InsertClient(client);

            if (ClientId != -1)
                AddClientToList(client);            

            return ClientId;

        }

        public static bool DeleteClient(short Id)
        {

            bool result = false;

            result = clsDeleteClient.DeleteClient(Id);

            if (result)
            {
                DeleteClientFromList(Id);
            }
            return result;  
        }

        public static bool UpdateClient(clsClient client)
        {
            bool result = false;

            result = clsUpdateClient.UpdateClient(client);

            if (result)
            {
                UpdateClientFromList(client);
            }
            return result;
        }

        
        public static List<clsClient> GetClient(string Name)
        {
            return GetClientFromList(Name);
        }


    }
}
