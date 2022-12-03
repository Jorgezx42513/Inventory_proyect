using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventario
{
    internal class Set_Reg : ConectionMySQL
    {
        public DateTime today = DateTime.Today;
        public void setUnicReg(double value)
        {
            SetCommand("INSERT INTO day_reg(Data_time,Value) VALUES('" + today.ToString("yyy-MM-dd") + "','" + value + "')"); 
        }
        public void setGeneralReg()
        {
            SetCommand("INSERT INTO gen_reg(date,value) Values('" + today.ToString("yyy-MM-dd") + "','" + generate_Gen("SELECT * FROM day_reg") + "')");
        }
    }
}
