using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IndumentariasExceptiones;
using Logica.Listas;
using Logica.BaseDeDatos;
using Logica.Interfaces;
using Logica.MetodoExtension;


namespace Logica.Objetos
{
    public delegate void IndumentariaFabricarEventHandler(object source, EventArgs args);
   

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
        
        public event EventHandler<IndumentariaEventArgs> FabricandoIndumentaria;

        protected Indumentaria()
        {
            this.codigoUnico = Guid.NewGuid().SimplificarCodigoUnico();
            FabricandoIndumentaria += AltaBajaConsultaListas.AgregarIndumentariaProduccion;
            FabricandoIndumentaria += LeerGuardarBaseDatos.GuardarFabricadoEnDB;
        }

        /// <summary>
        /// Para el caso de las pruebas el codigo debe ser "prueba" y no uno generado por Guid
        /// </summary>
        /// <param name="codigoUnico">string que se le quiere dar al codigoUnico "prueba" cuando se agregue una indumentaria desde los Tests</param>
        protected Indumentaria(string codigoUnico)
        {
            this.codigoUnico = codigoUnico;
            FabricandoIndumentaria += AltaBajaConsultaListas.AgregarIndumentariaProduccion;
            FabricandoIndumentaria += LeerGuardarBaseDatos.GuardarFabricadoEnDB;
        }

        #region Metodos y propiedades IFabricable

        /// <summary>
        /// Devuelve la cantidad manufacturada de la indumentaria
        /// </summary>
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
        /// <summary>
        /// Devuelve el Costo de Proiduccion de la indumentaria
        /// </summary>
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

        /// <summary>
        /// Llama a evento FabricandoIndumentaria, actualmente suscrito a AltaBajaConsultaListas.AgregarIndumentariaProduccion y LeerGuardarBaseDatos.GuardarFabricadoEnDB
        /// </summary>                                                    
        public void Fabricar()
        {
            try
            {
                //// le aviso a mi evento si ya esta disponible para que se agregue una unidad a CantidadManufactuirada, si es false que lo agregue
                if (!(this.FabricandoIndumentaria is null)){
                    this.FabricandoIndumentaria(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this), new IndumentariaEventArgs(this));
                }
                
            }
            catch (Exception e)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada(" No se pudo fabricar la indumentaria" + e.Message, e);
            }
            

        }
        #endregion

        #region Propiedades Indumentaria
        public string CodigoUnico
        {
            get { return this.codigoUnico.ToString(); }
            set { this.codigoUnico = value; }
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
            get { return (float)Math.Round(this.peso, 3); }
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
        /// <summary>
        /// Las indumentarias seran iguales cuando tengan el mismo CodigoUnico o cuando tengan el mismo nombre de Modelo
        /// </summary>
        /// <param name="ropaUno">Ropa a ser comparada</param>
        /// <param name="ropaDos">Ropa a ser comparada</param>
        /// <returns>TRUE=Si ambas NO tienen el mismo codigo unico o nombre de modelo FALSE=Cuando ambas indumentarias tengan el mismo CodigoUnico o nombre de modelo</returns>
        public static bool operator ==(Indumentaria ropaUno, Indumentaria ropaDos)
        {
            if (ropaUno is null || ropaDos is null)
            {
                return false;
            }
            if (ropaUno.Modelo == ropaDos.Modelo)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Indumentaria ropaUno, Indumentaria ropaDos)
        {
            return !(ropaUno == ropaDos);
        }

        /// <summary>
        /// La sobrecarga de ToString la usaremos para mostrar la informacion en nuestro UI
        /// </summary>
        /// <returns>"El tipo de indumentaria" - "el nombre del modelo")</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(this.GetType().ToString().Replace("Logica.Objetos.", "")+ " - ");
            sb.Append(this.Modelo +" ");
            //sb.Append("Peso: "+this.Peso.ToString() + ", ");
            //sb.Append("Porcentaje Algodon: " + this.PorcentajeAlgodon.ToString() + ", ");
            //sb.Append("Costo produccion : " + this.CostoProduccion.ToString() + ", ");
            return sb.ToString();
        }
        #endregion

    }
}
