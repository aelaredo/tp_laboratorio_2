using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Propiedades y Atributos
        /// <summary>
        /// Unico campo de numero un double que representa el numero
        /// </summary>
        private double numero; 

        /// <summary>
        /// Seteo el numero previamente validad con metodo ValidarNumero
        /// </summary>
        public string SetNumero
        {
            set
            {
                //recien aca seteo mi numero validando
                this.numero = ValidarNumero(value);
            }

        }
        #endregion

        #region Constructores
        /// <summary>
        /// El constructor sin parametros es seteando el valor de numero en 0
        /// </summary>
        public Numero():this(0)
        {
            
        }
        /// <summary>
        /// Crea un numero con el numero a ser seteado
        /// </summary>
        /// <param name="doubleNumero">Numeo a ser seteado en el nuevo numero a ser creado</param>
        public Numero(double doubleNumero)
        {
            //sobrecarga con double
            this.numero = doubleNumero;
        }

        /// <summary>
        /// Crea un numero a partir de la propiedad SetNUmero que a su vez utiliza ValidarNumero que se encarga de validar el numero en string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            //sobrecarga con string
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el string apsado por parametro sea un numero, lo devuelve si es correcto si no, devuelve un cero
        /// </summary>
        /// <param name="strNumero">El string del numero a ser validado</param>
        /// <returns>El numero pasado por param si es un numero, 0 si no es un numero</returns>
        private static double ValidarNumero(String strNumero)
        {
            double numeroValidado;

            if (double.TryParse(strNumero, out numeroValidado))
            {
                return numeroValidado;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// Valida que el string pasado por parametro este compuesto por ceros y unos
        /// </summary>
        /// <param name="binario">El String a ser validado si es un numero binario</param>
        /// <returns>Falso si encuentra algo distinto a 0 o 1, verdadero si todos los caracteres son 1 o 0</returns>
        private static bool EsBinario(String binario)
        {
            char[] ch = binario.ToCharArray();
            foreach (char numero in ch)
            {
                if (!(numero == '0' || numero == '1'))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Convierte un string conformado de 1 y 0 y lo convierte a decimal
        /// </summary>
        /// <param name="binario">El numero binario a ser convertiudo</param>
        /// <returns>El numero decimal correspondiente al valor del numero binario pasado por parametr</returns>
        public static String BinarioDecimal(String binario)
        {
            if (!EsBinario(binario))
            {
                return ("Valor Invalido!");
            }
            else
            {
                int binarioAConvertir = (int)new Numero(binario);
                int digito = 0;
                int numero = 0;
                for (long i = binarioAConvertir, j = 0; i > 0; i /= 10, j++)
                {
                    digito = (int)i % 10;

                    numero += digito * (int)Math.Pow(2, j);
                }

                return numero.ToString();
            }

        }

        /// <summary>
        /// Convierte la parte entera de un numero decimal a un string con el valor correspondiente en sistema binario
        /// </summary>
        /// <param name="numero">El numero decimal a ser convertido, si es un numero con coma, se toma la parte entera</param>
        /// <returns>Un string con el valor en binario del numero pasado por parametro</returns>
        public static String DecimalBinario(double numero)
        {
            if (numero == 0)
            {
                return "0";
            }
            Numero numeroAConvertir = new Numero((int)numero);
            String binarioCadena = "";
            while (numeroAConvertir.numero > 0)
            {
                
                if (numeroAConvertir.numero % 2 == 0)
                {
                    binarioCadena = "0" + binarioCadena;
                }
                else
                {
                    binarioCadena = "1" + binarioCadena;
                }
                numeroAConvertir.numero = (int)(numeroAConvertir.numero / 2);
            }


            return binarioCadena;
        }
        /// <summary>
        /// Convierte la parte entera de un numero decimal a un string con el valor correspondiente en sistema binario
        /// </summary>
        /// <param name="numero">El numero decimal a ser convertido a sistema bianrio en formato string</param>
        /// <returns>Un string con el valor en binario del numero pasado por parametro</returns>
        public static String DecimalBinario(String numero)
        {
            Numero numeroConvertir = new Numero(numero);
            return DecimalBinario(numeroConvertir.numero);
        }

        #endregion

        #region Sobrecarga de Operadores y Casteos
        /// <summary>
        /// Devuelve el atributo de numero de un objeto tipo Numero
        /// </summary>
        /// <param name="numeroAConvertir">Objeto del tipo Numero a ser casteado</param>
        public static explicit operator double(Numero numeroAConvertir)
        {
            return numeroAConvertir.numero;
        }
        /// <summary>
        /// Devuelve la parte entera del numero atributo del objeto a ser casteado
        /// </summary>
        /// <param name="numeroAConvertir">Objeto del tipo Numero a ser casteado</param>
        public static explicit operator int(Numero numeroAConvertir)
        {
            return (int)numeroAConvertir.numero;
        }
        /// <summary>
        /// Crea un objeto numero a partir del double pasado para castear
        /// </summary>
        /// <param name="numeroAConvertir">Numero double que sera asignado al objeto devuelto</param>
        public static explicit operator Numero(double numeroAConvertir)
        {
            return new Numero(numeroAConvertir);
        }
        /// <summary>
        /// Suma de los atributos de nuemro de cada objeto Numero que se esta sumando
        /// </summary>
        /// <param name="n1">El primer operando que sera sumado al segundo</param>
        /// <param name="n2">El segundo operando que sera sumado al primero</param>
        /// <returns>Numero double resultante de la suma de los dos atributos numero de los objetos Numero</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Resta de los atributos de nuemro de cada objeto Numero que se esta sumando
        /// </summary>
        /// <param name="n1">El primer operando que sera restado al segundo</param>
        /// <param name="n2">El segundo operando que sera restado al primero</param>
        /// <returns>Numero double resultante de la resta de los dos atributos numero de los objetos Numero</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Multiplicacion de los atributos de nuemro de cada objeto Numero que se esta sumando
        /// </summary>
        /// <param name="n1">El primer operando que sera multiplicado al segundo</param>
        /// <param name="n2">El segundo operando que sera multiplicado al primero</param>
        /// <returns>Numero double resultante de la multiplicacion de los dos atributos numero de los objetos Numero</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Division de los atributos de numero de cada objeto Numero que se esta sumando
        /// </summary>
        /// <param name="n1">El primer operando que sera multiplicado al segundo</param>
        /// <param name="n2">El segundo operando que sera multiplicado al primero</param>
        /// <returns>Numero double resultante de la division de los dos atributos numero de los objetos Numero si se divide por 0 devuelve el minimo valor de double</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
        #endregion 
    }
}
