using IndumentariasExceptiones;
using Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Logica.Listas;
using Logica.Documentos;
using Logica.BaseDeDatos;
using Logica.Objetos;

namespace Logica.Documentos
{
    public class LeerGuardarXML
    {
        /// <summary>
        /// Lee un archivo XML desde el patch pasado popr parametro y lo pasa a una lista del tipo parametro
        /// </summary>
        /// <typeparam name="T">Tipo ede lista que se quiere leer y que se pasara al ser leido</typeparam>
        /// <param name="pathArchivo">Path completo incluido nombre archivo y .xml</param>
        /// <param name="datos">Lista a la que se le cargara, no es necesario que este instanciada</param>
        public static void LeerDocumento<T>(string pathArchivo, out List<T> datos)
        {
            datos = new List<T>();

            try
            {
                if (pathArchivo != null && File.Exists(pathArchivo))
                {
                    using (XmlTextReader auxReader = new XmlTextReader(pathArchivo))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(List<T>));
                        datos = (List<T>)nuevoXml.Deserialize(auxReader);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("No se pudo leer el archivo: " + pathArchivo);
            }
        }

        /// <summary>
        ///  Guarda un XML con la tanda de produccion/disponibles del tipo pasado por parametro de tipo
        /// </summary>
        /// <typeparam name="T"> El tipo de objeto que se quiere guardar</typeparam>
        /// <param name="pathArchivo">path completo del archivo si se manda Produccion se guarda en ListaIndumentariaProduccion, si se manda Disponible se guarda en ListaIndumentariaDisponible, se pueden añadir formatos de fecha incluir .xml</param>
        public static void GuardarDocumento<T>(string pathArchivo) where T : Indumentaria
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                Stream myStream = new FileStream(pathArchivo, FileMode.Create, FileAccess.Write);
                if (pathArchivo.Contains("Produccion"))
                {
                    ser.Serialize(myStream, AltaBajaConsultaListas.ListaIndumentariaProduccion<T>());
                }
                else if (pathArchivo.Contains("Disponible"))
                {
                    ser.Serialize(myStream, AltaBajaConsultaListas.ListaIndumentariaDisponible<T>());
                }
                else
                {
                    throw new IndumentariasExceptionsErrorAlGenerarArchivo("Debe indicar en el nombre del archivo si es un archivo de produccion o de disponibles GuardarDocumento <T>");
                }
                myStream.Close();
            }
            catch (Exception ex)
            {
                throw new IndumentariasExceptionsErrorAlGenerarArchivo(" Ocurrio un error al querer guardar en GuardarDocumento <T>", ex);
            }
        }
    }
}
