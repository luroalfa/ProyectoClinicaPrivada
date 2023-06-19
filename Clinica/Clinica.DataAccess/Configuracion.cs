using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DataAccess
{
    internal class Configuracion
    {
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
