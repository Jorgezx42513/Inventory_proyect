using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Inventario
{
    internal class manager_resBtton : Set_Reg
    {
        public bool StateServer { get; set; }
        public void Manager(Image image)
        {
            if (StateServer == false)
            {
                image.Source = new BitmapImage(new Uri(@"\switch_On.png", UriKind.RelativeOrAbsolute));
                StateServer = true;
            }
            else
            {
                setGeneralReg();
                SetCommand("truncate day_reg");
                image.Source = new BitmapImage(new Uri(@"\switch_Off.png", UriKind.RelativeOrAbsolute));
                StateServer = false;
            }

        }
    }
}
