using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventario
{
    internal class SetTotal
    {
        public double Total {
            get { return _total; }
            set { _total += value; }
        }

        private  double _total;

        public double setTotal(string value)
        {
            if (value != "")
            {
                Total = Convert.ToDouble(value);  
                return Total;
            }
            return 0;
        }
        public void ResetTotal()
        {
            _total = 0;
        }
        public void subtract_total(double subtract)
        {
            _total -= subtract;
        }
    }
}
