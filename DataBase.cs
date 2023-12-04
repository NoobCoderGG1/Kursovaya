using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class DataBase
    {
        public MySqlConnection conn;
        
        public void Connection()
        {
            conn = new MySqlConnection("Datasource=localhost; port=3306; username = root; password=;database=183kucherov_nikolay; Convert Zero Datetime=True");
        }
    }
}
