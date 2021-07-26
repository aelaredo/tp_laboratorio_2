using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Objetos;

namespace Logica.Interfaces
{
    /// <summary>
    /// Define el funcionamiento de un objeto fabricable
    /// </summary>
    /// <typeparam name="T">Tipo parametro para ser utilizado en otras funcionalidades</typeparam>
    public interface IFabricable<T> where T : Indumentaria
    {
        /// <summary>
        /// Un objeto fabricable debe tener una propiedad para consultar y seterar la cantidad manufacturada 
        /// </summary>
        int CantidadManufacturada { get; set; }

        /// <summary>
        /// Un objeto fabricable debe tener una propiedad para consultar y setear el costo de su produccion
        /// </summary>
        float CostoProduccion { get; set; }

        /// <summary>
        /// Un objeto fabricable debe poder ser fabricado de alguna forma
        /// </summary>
        void Fabricar();
    }
}
