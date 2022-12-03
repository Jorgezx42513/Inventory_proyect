using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventario
{
    internal class AmountCount : AutoCompleteM
    {
      
        public string gen_Amount(string code)   
        {
            int Index = 1;
            MySqlCommand command = new MySqlCommand("SELECT VarCode,Amount FROM bill", connection_Dtbase);
            try
            {
                connection_Dtbase.Open();
                MySqlDataReader reader = command.ExecuteReader();              
                while (reader.Read())
                {

                    string data = reader.GetString(0);
                    int ind = reader.GetInt32(1);
                    if (data == code)
                    {
                        for (int i = 0; i < ind; i++)
                        {
                            Index++;
                        }                     
                        break;
                    }
                }
                connection_Dtbase.Close();
                return Index.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
