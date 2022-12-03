using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    internal class InsertTB : ConectionMySQL
    {
        public void Insert(string[] Data, string code)
        {
            int amount = Convert.ToInt32(Data[2]);
            if (amount <= 1)
            {
                 SetCommand("INSERT INTO bill (Name,VarCode,Amount,Price) VALUES('" + Data[0] + "','" + code + "','" + Data[2] + "','" + Data[1] + "')");
            }
            else
            {
                SetCommand("UPDATE bill SET Amount='"+ Data[2] + "' WHERE VarCode='"+ code +"'");
            }          
        }
    }
}
