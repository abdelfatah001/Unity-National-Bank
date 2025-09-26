using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace DAL.Repository
{
    internal class DBConnection
    {

        static public string _connectionString =
            "Server=.;Database=dbBankManagmentSystem;User ID=sa;Password=123456;";

    }
}
