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
    public static class DocumentosFabrica
    {

        static DocumentosFabrica()
        {
           
        }

        /// <summary>
        ///  Guarda un XML con la tanda de produccion/disponibles del tipo pasado por parametro de tipo
        /// </summary>
        /// <typeparam name="T"> El tipo de objeto que se quiere guardar</typeparam>
        /// <param name="nombreArchivo">Si se manda Produccion se guarda en ListaIndumentariaProduccion, si se manda Disponible se guarda en ListaIndumentariaDisponible, se pueden añadir formatos de fecha incluir .xml</param>
        public static void GuardarDocumento<T>(string pathArchivo) where T : Indumentaria
        {
            

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                Stream myStream = new FileStream(pathArchivo, FileMode.Create, FileAccess.Write);
                if(pathArchivo.Contains("Produccion"))
                {
                    ser.Serialize(myStream, Fabrica.ListaIndumentariaProduccion<T>());
                }
                else if (pathArchivo.Contains("Disponible"))
                {
                    ser.Serialize(myStream, Fabrica.ListaIndumentariaDisponible<T>());
                }
                
                myStream.Close();
            }
            catch (Exception ex)
            {
                throw new IndumentariasExceptionsErrorAlGenerarArchivo(" Ocurrio un error al querer guardar en GuardarDocumento <T>" , ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
                        //XmlSerializer nuevoXml = new XmlSerializer(typeof(List<Indumentaria>));
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(List<T>));
                        datos = (List<T>)nuevoXml.Deserialize(auxReader);
                    }
                }
            }
            catch (Exception)
            {
                datos = new List<T>();
                throw new Exception("No se pudo leer el archivo: " + pathArchivo);
            }
        }

        /// <summary>
        ///  Devuelve la informacion de la tanda en formato string, la fecha de produccion, el encargado y cada indumentaria que se mando a fabricar
        /// </summary>
        /// <typeparam name="T">El tipo de indumentaria que se quiera si se pasa indumentaria trae todos</typeparam>
        /// <returns></returns>
        public static string InfoTandaProduccion<T>(string fechaManufactura, string nombreEncargado) where T : Indumentaria
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fecha de produccion: " + fechaManufactura);
            foreach (Indumentaria ropita in Fabrica.ListaIndumentariaProduccion<T>())
            {
                sb.AppendLine(ropita.ToString());
            }
            sb.AppendLine("---------------------");
            sb.AppendLine("Encargado de la produccion: " + nombreEncargado);
            return sb.ToString();
        }

    }
}
