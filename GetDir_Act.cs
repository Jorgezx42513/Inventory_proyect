using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    internal class GetDir_Act 
    {
        public string getDir()
        {
            string dir = "";
            string[] SplitDir = Directory.GetCurrentDirectory().Split(@"\"); 
            foreach (string s in SplitDir) 
            {
                if (s != "Inventario")
                {
                    dir += @$"{s}\";
                }
                else
                {
                    dir += @$"{s}\{s}";
                    break;
                }
            }
            return dir;
        }
        public string getDir_Ini()
        {
            string dir = "";
            string[] SplitDir = Directory.GetCurrentDirectory().Split(@"\");
            foreach (string s in SplitDir)
            {
                if (s != "Inventario")
                {
                    dir += @$"{s}/";
                }
                else
                {
                    dir += @$"{s}/{s}";
                    break;
                }
            }
            return dir;
        }
    }
}
