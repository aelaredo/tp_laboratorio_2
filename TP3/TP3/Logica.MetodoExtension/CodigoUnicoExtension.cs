using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public static class CodigoUnicoExtension 
    {
        public static string SimplificarCodigoUnico(this Guid codigo)
        {
            return codigo.ToString().Substring(10);
        }
    }
}
