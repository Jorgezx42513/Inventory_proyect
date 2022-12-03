using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventario
{
    internal class AddPro : InsertTB    
    {
        setVals setVals = new setVals();
        public void Add(string code,Label name, Label Value, Label Amount,Label total, TextBox textBox)
        {           
            string[] Data = ReaderCode(code, "SELECT * FROM inventory;");           
            if (Data[0] != "" && Data[1] != "")
            {
                Insert(Data, code);
                setVals.set_vals(new Label[] {name,Value,Amount,total}, Data);
                textBox.Clear();
            }
        }
    }
    internal class setVals
    {
        public void set_vals(Label[] labels, string[] Data)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Content = $"{labels[i].Content.ToString().Split(":")[0]}:";
                labels[i].Content += $" {Data[i]}";
            }
        }
    }
}
