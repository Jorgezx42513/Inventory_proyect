using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Inventario
{
    public class ConectionMySQL : MySqlPort
    {
        AmountCount amountCount = new AmountCount();
        setVals setVals = new setVals();
        OpenPortMy openPort = new OpenPortMy();

        public void fillTable(DataGrid dataGrid,string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection_Dtbase);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            
            try
            {
                connection_Dtbase.Open();
                adapter.Fill(table);
                dataGrid.ItemsSource = table.DefaultView;
                connection_Dtbase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("The DataBase is not enabled", "Server Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        SetTotal setTotal = new SetTotal();
        public string[] ReaderCode(string Code, string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection_Dtbase);
            string Name = "";
            string Value = "";
            try
            {
                connection_Dtbase.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    string currentData = rdr.GetString("VarCode");
                    if (currentData == Code)
                    {
                        Name = rdr.GetString("Name");
                        Value = rdr.GetString("Value");
                        break;
                    }
                }
                connection_Dtbase.Close();
                return new string[] { Name, Value, amountCount.gen_Amount(Code), Convert.ToString(setTotal.setTotal(Value)) };
            }
            catch (Exception)
            {
                MessageBox.Show("The DataBase is not enabled", "server error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new string[] { };
            }
        }

        public void SetCommand(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection_Dtbase);
            try
            {
                connection_Dtbase.Open();
                command.ExecuteNonQuery();
                connection_Dtbase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("The DataBase is not enabled", "server error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void resetTotal()
        {
            setTotal.ResetTotal();
        }
        public void subtract(double price, Label label_total)
        {
            setTotal.subtract_total(price);
            setVals.set_vals(new Label[] {label_total}, new string[] {Convert.ToString(setTotal.Total)});
        }
        public float generate_Gen(string query)
        {
            float Value = 0;
            MySqlCommand Command = new MySqlCommand(query, connection_Dtbase);
            try
            {
                connection_Dtbase.Open();
                MySqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Value += reader.GetFloat("Value");  
                }
                connection_Dtbase.Close();
                return Value;
            }
            catch (Exception)
            {
                MessageBox.Show("The DataBase is not enabled", "server error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }


        }
    }
}
