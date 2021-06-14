using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using IndumentariasExceptions;

namespace Logica
{
    public static class Fabrica
    {
        public static List<Indumentaria> indumentariaProduccion;
        public static List<Indumentaria> indumentariaDisponible;
        static Fabrica ()
        {
            Fabrica.indumentariaProduccion = new List<Indumentaria>();
            Fabrica.indumentariaDisponible = new List<Indumentaria>();
        }


        #region Agregar indu a listas
        /// <summary>
        /// Agrega indumentara a la tanda de fabricacion.
        /// </summary>
        /// <param name="indumentariaFabricar">Indumentaria a ser fabricada, no debe ser repetida</param>
        /// <returns></returns>
        public static void agregarAProduccion(Indumentaria indumentariaFabricar)
        {
            try
            {
                if (!(IndumentariaYaEnProduccion(indumentariaFabricar)))
                {
                    if (indumentariaFabricar.CantidadManufacturada > 0)
                    {
                        indumentariaFabricar.CantidadManufacturada = 0;
                    }

                    Fabrica.indumentariaProduccion.Add(indumentariaFabricar);
                }
            }catch(IndumentariasExceptionsIndumentariaNoInstanciada e)
            {
                throw new Exception("No se pudo agregar indumentaria a tanda de produccion", e);
            }
            
        }

        /// <summary>
        /// Agrega indumentaria a lista de disponibles
        /// </summary>
        /// <param name="indumentariaAgregar">Indumentaria a ser agregada, no pueden repetirse</param>
        public static void agregarADisponible(Indumentaria indumentariaAgregar)
        {
            if (!(IndumentariaYaDisponible(indumentariaAgregar)))
            {
                Fabrica.indumentariaDisponible.Add(indumentariaAgregar);
            }
            else
            {
                throw new Exception("Ya se encuentra disponible");

                //throw new IndumentariasExceptionsRepetida("El modelo ya esta en la tanda de produccion");
            }
        }
        #endregion

        #region Consulta/Manipulacion de listas
        /// <summary>
        /// Aqui se aplican generics: Devuelve una lista con la indumentaria manufacturada del tipo parametro
        /// </summary>
        /// <typeparam name="T">Tipo de indumentaria que se quiere </typeparam>
        /// <returns>Una nueva lista con l</returns>
        public static List<T> ListaIndumentariaProduccion<T>() where T : Indumentaria
        {
            try
            {
                List<T> listaRetorno = Fabrica.indumentariaProduccion.OfType<T>().ToList();
                return listaRetorno;
            }
            catch(Exception error)
            {
                throw new Exception("Error al generar informe de indumentaria de produccion", error);
            }
           
        }


        /// <summary>
        /// Devuelve una lista con la indumentaria disponible del tipo pasado
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo de indumentaria que se quiere </typeparam>
        /// <returns>Una nueva lista basada en la </returns>
        public static List<T> ListaIndumentariaDisponible<T>() where T : Indumentaria
        {
            try
            {
                List<T> listaRetorno = Fabrica.indumentariaDisponible.OfType<T>().ToList();
                return listaRetorno;
            }
            catch (Exception error)
            {
                throw new Exception("Error al generar informe de indumentaria disponible", error);
            }

        }


        /// <summary>
        /// Borra la tanda de produccion de la fabrica
        /// </summary>
        public static void borrarTandaProduccion()
        {
            Fabrica.indumentariaProduccion.Clear();
        }

        #endregion

        #region Validaciones
        /// <summary>
        /// Devuelve verdadero si la indumentaria que se pasa por 
        /// </summary>
        /// <param name="indumentariaManufacturar">Indumen</param>
        /// <returns></returns>
        public static bool IndumentariaYaEnProduccion(Indumentaria indumentariaManufacturar)
        {
            if (indumentariaManufacturar is null)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada("No se instancio ninguna indumentaria para la operacion");
            }

            foreach (Indumentaria ropa in Fabrica.indumentariaProduccion)
            {
                if ( ropa == indumentariaManufacturar)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compara los elementos de Fabrica.indumentariaDisponible con la indumentaria pasada por parametro
        /// </summary>
        /// <param name="indumentariaAgregar">La indumentaria que quiere saber si esta en la lista </param>
        /// <returns>true si la indumentaria ya se encuentra en la lista de disponibles, false si no se encuentra</returns>
        public static bool IndumentariaYaDisponible(Indumentaria indumentariaAgregar)
        { 
            if (indumentariaAgregar is null)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada("No se instancio ninguna indumentaria para la operacion");
            }

            foreach (Indumentaria ropa in Fabrica.indumentariaDisponible)
            {
                if (ropa == indumentariaAgregar)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

    }
}
