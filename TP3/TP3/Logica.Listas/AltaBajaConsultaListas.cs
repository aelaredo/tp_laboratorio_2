using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using IndumentariasExceptiones;
using Logica.Objetos;
using Logica.BaseDeDatos;

namespace Logica.Listas
{
    public static class AltaBajaConsultaListas
    {
        public static List<Indumentaria> indumentariaProduccion;
        public static List<Indumentaria> indumentariaDisponible;


        static AltaBajaConsultaListas()
        {
            AltaBajaConsultaListas.indumentariaProduccion = new List<Indumentaria>();
            AltaBajaConsultaListas.indumentariaDisponible = new List<Indumentaria>();
        }

        #region Agregar elementos a las listas

        /// <summary>
        /// Agrega a lista de produccion objeto indumentaria pasada por segundo parametro como "new IndumentariaEventArgs(indumentariaAgregar)", agrega +1 a la cantidadManufacturada del mismo objeto
        /// </summary>
        /// <param name="source">FALSE: Agrega indumentaria pasada a lista Fabrica.indumentariaProduccion y suma 1 a la cantidadManufacturada de la indumentaria pasada TRUE: Suma +1 cantidadManufacturada sin agregar a lista</param>
        /// <param name="args">new IndumentariaEventArgs(indumentariaAgregar)</param>
        public static void AgregarIndumentariaProduccion(object source, IndumentariaEventArgs args)
        {
            Indumentaria indumentariaFabricar = args.IndumentariaObject;
            if (indumentariaFabricar != null)
            {
                if ((int)source>0 && AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>().Contains(indumentariaFabricar))
                {
                    indumentariaFabricar.CantidadManufacturada++;
                }
                else
                {
                    AltaBajaConsultaListas.indumentariaProduccion.Add(indumentariaFabricar);
                    indumentariaFabricar.CantidadManufacturada++ ;
                }
            }
            else
            {
                throw new IndumentariasExceptionsErrorAlFabricar("Error al castear source de evento a indumentaria para ser agregada en listbox de producido", null);
            }
        }

        /// <summary>
        /// Agrega indumentaria a lista de disponible, el primer parametro es indistinto lo que se le paso, ya que la validacion se hace acá con IndumentariaYaDisponible(indumentariaAgregar), el segundo debe pasarse como tipo IndumentariaEventArgs usando su constructor con primer arguimente la indumentaria a pasar/agregar
        /// </summary>
        /// <param name="source">Indistinto, la validacion se hace en esta misma funcion</param>
        /// <param name="args">new IndumentariaEventArgs(indumentariaAgregar)</param>
        public static void AgregarIndumentariaDisponible(object source, IndumentariaEventArgs args)
        {
            Indumentaria indumentariaAgregar = args.IndumentariaObject;

            if (!(indumentariaAgregar is null) && !(IndumentariaYaDisponible(indumentariaAgregar)))
            {
                AltaBajaConsultaListas.indumentariaDisponible.Add(indumentariaAgregar);
            }
            else
            {
                throw new IndumentariasExceptionsRepetida("Ya se encuentra disponible");
            }
        }

        #endregion

        #region Consula a las listas
        /// <summary>
        /// Aqui se aplican generics: Devuelve una lista con la indumentaria manufacturada del tipo parametro
        /// </summary>
        /// <typeparam name="T">Tipo de indumentaria que se quiere </typeparam>
        /// <returns>Una nueva lista con l</returns>
        public static List<T> ListaIndumentariaProduccion<T>() where T : Indumentaria
        {
            try
            {
                List<T> listaRetorno = AltaBajaConsultaListas.indumentariaProduccion.OfType<T>().ToList();
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
                List<T> listaRetorno = AltaBajaConsultaListas.indumentariaDisponible.OfType<T>().ToList();
                return listaRetorno;
            }
            catch (Exception error)
            {
                throw new Exception("Error al generar informe de indumentaria disponible", error);
            }
        }

        #endregion

        #region Borrado de la lista 
        /// <summary>
        /// Borra la lista tanda de produccion de la fabrica
        /// </summary>
        public static void borrarTandaProduccion()
        {
            AltaBajaConsultaListas.indumentariaProduccion.Clear();
        }
        #endregion

        #region Validaciones

        /// <summary>
        /// Devuelve la cantidad de la indumentaria pasada por parametro que esta manufacturada en la base de datos
        /// </summary>
        /// <param name="indumentariaManufacturar">Indumentaria que quiera saber su cantidad de manufacturas en base de datos</param>
        /// <returns>Cantidad de indumentaria fabricada</returns>
        public static int IndumentariaEnBDProduccion(Indumentaria indumentariaManufacturar)
        {
            if (indumentariaManufacturar is null)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada("No se instancio ninguna indumentaria para la operacion");
            }
            Dictionary<string, int> manufacturadosBD = new Dictionary<string, int>();

            //Leo mi base de datos, para obtener el modelo y la cantidad fabricada
            LeerGuardarBaseDatos.LeerBaseDatosManufacturados(out manufacturadosBD);

            //itero la lista para ver si mi indumentaria pasada por parametro esta en mi base de datos
            foreach (KeyValuePair<string,int> ropa in manufacturadosBD)
            {
                if ( ropa.Key == indumentariaManufacturar.Modelo)
                {
                    //si mi indumentaria esta en la base de datos, devuelvo la cantidad de fabricados que tiene
                    return ropa.Value;
                }
            }

            return 0;
        }

        /// <summary>
        /// Compara los elementos de mla lista  Fabrica.indumentariaDisponible (cargados con la base de datos al iniciar) con la indumentaria pasada por parametro
        /// </summary>
        /// <param name="indumentariaAgregar">La indumentaria que quiere saber si esta en la lista </param>
        /// <returns>true si la indumentaria ya se encuentra en la lista de disponibles, false si no se encuentra</returns>
        public static bool IndumentariaYaDisponible(Indumentaria indumentariaAgregar)
        { 
            if (indumentariaAgregar is null)
            {
                throw new IndumentariasExceptionsIndumentariaNoInstanciada("No se instancio ninguna indumentaria para la operacion");
            }

            foreach (Indumentaria ropa in AltaBajaConsultaListas.indumentariaDisponible)
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
