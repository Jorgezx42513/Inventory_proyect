using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    internal class ReadWriteIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string name, string key, string val,string filepath );
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder relVal, int size, string filepath);


    }
}
