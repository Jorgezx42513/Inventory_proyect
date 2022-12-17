using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    internal class Act_MyIni : ReadWriteIni
    {
        public Act_MyIni()
        {
            string[,,] DataInifile = new string[,,] { 
                { 
                    {"client", "socket", $"\"{getDir_Ini()}/mysql/mysql.sock\""},
                    {"mysqld", "socket", $"\"{getDir_Ini()}/mysql/mysql.sock \""},
                    {"mysqld", "basedir", $"\"{getDir_Ini()}/mysql\""},
                    {"mysqld", "tmpdir", $"\"{getDir_Ini()}/mysql/tmp\""},
                    {"mysqld", "datadir", $"\"{getDir_Ini()}/mysql/data\""},
                    {"mysqld", "plugin_dir", $"\"{getDir_Ini()}/mysql/lib/plugin/\""},
                    {"mysqld", "innodb_data_home_dir", $"\"{getDir_Ini()}/mysql/data\""},
                    {"mysqld", "innodb_log_group_home_dir", $"\"{getDir_Ini()}/mysql/data\""}
                }
            };
            for (int i = 0; i < 8; i++)
            {
                WriteINI(DataInifile[0,i,0], DataInifile[0, i, 1], DataInifile[0, i, 2]);
            }
        }
    }
}
