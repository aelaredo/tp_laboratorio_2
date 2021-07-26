using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.MetodoExtension

{
    public static class CodigoUnicoExtension 
    {
        /// <summary>
        /// Recorta el Guid a 5 caracteres
        /// </summary>
        /// <param name="codigo">Codigo a ser simplificado</param>
        /// <returns>5 caracteres correspondientes a una parte del string que se le paso</returns>
        public static string SimplificarCodigoUnico(this Guid codigo)
        {
            return codigo.ToString("N").Substring(0, 5);
        }
    }
}
