using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndumentariasExceptiones;

namespace Logica.Objetos
{

    #region Enumerados
    public enum ESuelas
    {
        React = 5,
        Shox = 3,
        Metcon = 2,
        Airforce = 1,
        Pegasus = 4
    }

    public enum ECapelladas
    {
        Zoom = 2,
        Wildhorse = 3,
        Infinity = 1,
        Revolution = 5,
        Waffle = 4
    }
    #endregion

    [Serializable]
    public class Zapatilla : Indumentaria
    {
        private ECapelladas capellada;
        private ESuelas suela;

        public Zapatilla()
        {

        }

        public Zapatilla(ECapelladas capellada, ESuelas suela)
        {
            Random randomPeso = new Random();
            // a efectos practicos simulemos numeros randoms
            double numeroRandom = Math.Round(1 + randomPeso.NextDouble() * (100 - 1), 3);
            this.Capellada = capellada;
            this.Suela = suela;
            this.Modelo = capellada.ToString() + suela.ToString() + DateTime.Today.Year.ToString();
            this.Peso = (float)numeroRandom * (int)this.Suela;
            this.PorcentajeAlgodon = randomPeso.Next(1, 100);
            this.CostoProduccion = this.PorcentajeAlgodon * this.Peso / 3;
        }

        public Zapatilla(ECapelladas capellada, ESuelas suela, string anioProduccion):this(capellada, suela)
        {
            this.Modelo = capellada.ToString() + suela.ToString() + anioProduccion;
        }
        public Zapatilla(ECapelladas capellada, ESuelas suela, string anioProduccion, string codigoPrueba) : this(capellada, suela, anioProduccion)
        {
            this.CodigoUnico = codigoPrueba;
        }

        public ECapelladas Capellada
        {
            get { return this.capellada; }
            set { this.capellada = value; }
        }

        public ESuelas Suela
        {
            get { return this.suela; }
            set { this.suela = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            return sb.ToString();
        }

    }
}
