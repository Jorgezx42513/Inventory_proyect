using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventario
{
    public class MySqlPort
    {
        private MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=inventory_dts;");
        public MySqlConnection connection_Dtbase 
        {
            get { return connection; }
        }
    }
}
