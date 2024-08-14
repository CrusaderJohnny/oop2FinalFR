using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace OOP2FINAL.Persistence
{
    public class ClientDB
    {
        //This is a list of clients that will be generated if a report needs to be created or if new clients are being added or a client is being removed
        internal List<Client> clients = new List<Client>();
        //This will be the connection to the database
        
        internal void RetreiveClientTable()
        {
            clients.Clear();
            DataBase dataBase = new DataBase();


        }
    }
}
