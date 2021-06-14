using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Camiseta : Indumentaria
    {
        private bool estampado;

        public bool Estampado
        {
            get { return estampado; }
            set { estampado = value; }
        }

        public Camiseta()
        {

        }

        public Camiseta(float porcentajeAlgodon, bool estampado, string modelo): base()
        {
            this.porcentajeAlgodon = porcentajeAlgodon;
            this.estampado = estampado;
            this.modelo = modelo;
            this.peso = 25.50f;
            this.costoProduccion = (this.PorcentajeAlgodon + 100) * 10;
        }

        /// <summary>
        /// La sobre carga de ToString 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            if (this.estampado == true)
            {
                sb.Append("- Estampada");
            }
            else
            {
                sb.Append("- Lisa");
            }
            
            return sb.ToString();
        }

    }
}
