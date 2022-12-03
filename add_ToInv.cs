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
    internal class add_ToInv : Data_RowsGrid
    {
        public ConectionMySQL conectionMySQL = new ConectionMySQL();
        public ObservableCollection<Data_RowsGrid> _data = new ObservableCollection<Data_RowsGrid>();
        public ObservableCollection<Data_RowsGrid> Data
        {
            get { return _data;}
            set { _data = value;}
        }
        public void add_Colum(DataGrid dataGrid)
        {
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = Data;           
        }
    }
}
