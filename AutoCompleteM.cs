using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Inventario
{
    internal class AutoCompleteM : Data_RowsGrid
    {
        public  List<char> name { get; set; } = new List<char>();
        public int index { get; set; }
        string query = "SELECT * FROM Inventory;";

        public void GetData(DataGrid dataGrid)
        {         
            MySqlCommand command = new MySqlCommand(query, connection_Dtbase);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                connection_Dtbase.Open();
                adapter.Fill(table);
                MySqlDataReader rdr = command.ExecuteReader();
              
                while (rdr.Read())
                {
                    string currentName = "";
                    string ProcName = "";
                    char[] txt = rdr.GetString("Name").ToCharArray();

                    for (int i = 0; i < name.Count; i++)
                    {
                        currentName += name[i];
                        ProcName += txt[i];
                    }

                    if (ProcName == currentName)
                    {
                        DataRow row = table.Rows[index];
                        dataGrid.Items.Add(new MyData { Name = (string)row[0], VarCode = row[1], Value = row[2] });
                    }                  
                   index++;
                }
                connection_Dtbase.Close();
                index = 0;
            }
            catch (Exception)
            {
                throw;
            }          
        }
    }
}
