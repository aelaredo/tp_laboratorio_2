using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IndumentariasExceptions;

namespace Logica
{
    [XmlInclude(typeof(Zapatilla))]
    [XmlInclude(typeof(Camiseta))]
    public abstract class Indumentaria : IFabricable<Indumentaria>
    {
        protected String codigoUnico;
        protected String modelo;
        protected float peso;
        protected float porcentajeAlgodon;
        protected float costoProduccion;
        protected int cantidadManufacturada = 0;
        protected int cantidadStock = 0;


        protected Indumentaria()
        {
            this.codigoUnico = Guid.NewGuid().ToString().Substring(10);
        }

        #region Metodos y propiedades IFabricable
        public int CantidadManufacturada
        {
            get { return this.cantidadManufacturada; }
            set
            {
                if (value >= 0)
                {
                    this.cantidadManufacturada = value;
                }
                else
                {
                    throw new Exception("No se puede manufacturar menos de una prenda");

                }
            }
        }

        public virtual float CostoProduccion
        {
            set
            {
                if (value <= 0)
                {
                    throw new IndumentariasExceptionsPrecioErroneo("El precio no es valido!");
                }
                else
                {
                    this.costoProduccion = value;
                }
            }
            get
            {
                return this.costoProduccion;
            }
        }

        public void Fabricar()
        {
            try
            {
                Fabrica.agregarAProduccion(this);
                this.cantidadManufacturada++;
            }
            catch(Exception e)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada(" No se pudo fabricar la indumentaria" + e.Message, e);
            }
            

        }
        #endregion


        #region Propiedades Indumentaria
        public string CodigoUnico
        {
            get { return this.codigoUnico.ToString(); }
            set { }
        }


        protected virtual float PrecioConImpuestos
        {
            get
            {
                return this.costoProduccion * (this.porcentajeAlgodon/100);
            }
            set
            {
                if (value > 0)
                {
                    this.costoProduccion = value + this.costoProduccion;
                }
            }
        }

        public float Peso
        {
            get { return this.peso; }
            set 
            { 
                if (value != 0)
                {
                    this.peso = value;
                }
            }
        }

        public virtual float PorcentajeAlgodon
        {
            get
            {
                return this.porcentajeAlgodon;
            }
            set
            {
                if (value > 0)
                {
                    this.porcentajeAlgodon = value;
                }
            }
        }

        public virtual string Modelo
        {
            set
            {
                if (value is null || value == "")
                {
                    throw new IndumentariasExceptionsNombreErroneo("El nombre esta vacio!");
                }
                else
                {
                    this.modelo = value;
                }
            }
            get
            {
                return this.modelo;
            }
        }
        #endregion


        #region Sobrecarga operadores/metodos
        public static bool operator ==(Indumentaria ropaUno, Indumentaria ropaDos)
        {
            if (ropaUno is null || ropaDos is null)
            {
                return false;
            }

            if (ropaUno.CodigoUnico == ropaDos.CodigoUnico || ropaUno.Modelo == ropaDos.Modelo)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Indumentaria ropaUno, Indumentaria ropaDos)
        {
            return !(ropaUno == ropaDos);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(this.GetType().ToString().Replace("Logica.", "")+ " - ");
            sb.Append(this.Modelo +" ");
            //sb.Append("Peso: "+this.Peso.ToString() + ", ");
            //sb.Append("Porcentaje Algodon: " + this.PorcentajeAlgodon.ToString() + ", ");
            //sb.Append("Costo produccion : " + this.CostoProduccion.ToString() + ", ");
            return sb.ToString();
        }
        #endregion


    }
}
