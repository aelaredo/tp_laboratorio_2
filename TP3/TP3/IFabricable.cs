using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
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
