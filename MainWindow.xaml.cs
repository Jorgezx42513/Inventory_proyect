using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using WindowsInput.Native;
using WindowsInput;

namespace Inventario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenPortMy openPort = new OpenPortMy();
        manager_resBtton manager = new manager_resBtton();
        AutoCompleteM CompleteM = new AutoCompleteM();
        AddPro AddPro = new AddPro();
        Set_Reg Set_Reg = new Set_Reg();
        add_ToInv add_ToInv = new add_ToInv();
        InputSimulator sim = new InputSimulator();
        deletePro deletePro = new deletePro();
        setVals setVals = new setVals();

        public MainWindow()
        {
            InitializeComponent();
            openPort.ExeComand(@"mysql\bin\mysqld --defaults-file=mysql\bin\my.ini --standalone", @"\MySQL\");
            AddPro.SetCommand("truncate bill");
            CompleteM.GetData(GripProduc);           
            manager.StateServer = true;
            AddPro.fillTable(DataDridView, "select * from bill;");
        }   
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ButtonMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;       
            else
                this.WindowState = WindowState.Normal;
        }

        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ChangeItem(object sender, MouseButtonEventArgs e)
        {
            switch (Convert.ToString(ListB.SelectedItems[0]))
            {
                case "Bill":
                    AddPro.fillTable(DataDridView, "select * from bill;");
                    break;             
                case "Day_Reg":
                    AddPro.fillTable(DataDridView, "select * from day_reg;");
                    break;
                case "Gen_Reg":
                    AddPro.fillTable(DataDridView, "select * from gen_reg;");
                    break;
            }
        }   
        private void TextB_Pro_TextChanged(object sender, TextChangedEventArgs e)
        {
            GripProduc.ItemsSource = null;
            char[] name = TextB_Pro.Text.ToCharArray();
            GripProduc.Items.Clear();

            if (name.Length > CompleteM.name.Count)
                CompleteM.name.Add(name[name.Length - 1]);
            else
                CompleteM.name.Remove(CompleteM.name[CompleteM.name.Count - 1]);

            sand_button.Visibility = Visibility.Hidden;
            CompleteM.GetData(GripProduc);
        }
        private void tbVarCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbVarCode.Text != "")
            {
                AddPro.Add(tbVarCode.Text, L_Name, L_Value, L_Amount, L_Total, tbVarCode);
                AddPro.fillTable(DataDridView, "select * from bill;");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Set_Reg.setUnicReg(Convert.ToDouble(L_Total.Content.ToString().Split(":")[1]));
                    AddPro.SetCommand("truncate bill");
                    AddPro.resetTotal();
                    setVals.set_vals(new Label[] {L_Name, L_Value, L_Amount, L_Total},new string[4]);
                    AddPro.fillTable(DataDridView, "select * from bill;");
                    break;
                case Key.Add:
                    tbVarCode.Focus();
                    break;
                case Key.Subtract:
                    AddPro.subtract((double)deletePro.set_lost_data()[2],L_Total);
                    deletePro.delete_reg();
                    break;
                default:
                    break;
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            sand_button.Visibility = Visibility.Visible;
            add_ToInv.add_Colum(GripProduc);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_ToInv.add_Colum(GripProduc);
        }

        private void Button_MySQL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            manager.Manager(Button_MySQL);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
    }
}
