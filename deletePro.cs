using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Inventario
{
    internal class deletePro : ConectionMySQL
    {
        public void delete_reg()
        {
            object[] data = set_lost_data();
            if ((int)data[1] > 1)
            {
                SetCommand($"UPDATE bill SET Amount={(int)data[1] - 1} WHERE id={data[0]}");
            }
            else {
                SetCommand($"DELETE FROM bill WHERE id={data[0]}");
                SetCommand($"ALTER TABLE bill AUTO_INCREMENT ={(int)data[0] - 1};");
            }
        }
        public object[] set_lost_data()
        {
            int id = 0;
            int amount = 0;
            double Price = 0;
            MySqlCommand command = new MySqlCommand("SELECT id,Amount,Price FROM bill", connection_Dtbase);
            try
            {
                connection_Dtbase.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    id = Convert.ToInt32(rdr["ID"]);
                    amount = Convert.ToInt32(rdr["AMOUNT"]);
                    Price = Convert.ToDouble(rdr["PRICE"]);
                }
                connection_Dtbase.Close();
                return new object[] { id, amount, Price };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
