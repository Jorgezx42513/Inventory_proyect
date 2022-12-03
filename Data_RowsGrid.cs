using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsInput.Native;

namespace Inventario
{
    internal class Data_RowsGrid : MySqlPort
    {
        string _name = "New";
        [RefreshProperties(RefreshProperties.Repaint)]
        public String Name
        {
            get => _name;
            set { _name = value;
                if (!_Value.Equals(0) && !_varCode.Equals(0) && !_name.Equals("New"))
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO Inventory(Name, VarCode, Value) VALUES('" + Name + "', '" + VarCode + "', '" + Value + "')", connection_Dtbase);
                    try
                    {
                        connection_Dtbase.Open();
                        command.ExecuteNonQuery();
                        connection_Dtbase.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        int _varCode = 0;
        [RefreshProperties(RefreshProperties.Repaint)]
        public int VarCode
        {
            get { return _varCode; }
            set { _varCode = value;}
        }
        float _Value = 0;
        public float Value
        {
            get { return _Value; }
            set { _Value = value;}
        }
        public struct MyData
        {
            public string Name { set; get; }
            public object VarCode { set; get; }
            public object Value { set; get; }
        }
    }
}
