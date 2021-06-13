using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo cantidadPuertas):base(marca, chasis, color)
        {
            this.tipo = cantidadPuertas;
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color):this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }


        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SEDAN\r\n");
            sb.AppendLine((string)this);
            sb.AppendLine($"TAMAÑO : {this.Tamanio} TIPO: {this.tipo}\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
