using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IFabricable<T> where T : Indumentaria
    {
        int CantidadManufacturada { get; set; }

        float CostoProduccion { get; set; }

        void Fabricar();
    }
}
