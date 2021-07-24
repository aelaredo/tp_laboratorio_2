using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using IndumentariasExceptiones;
using Logica.Objetos;
using Logica.Listas;

namespace Logica.BaseDeDatos
{
    public static class LeerGuardarBaseDatos
    {

        public static SqlConnection conexion;
        public static SqlCommand comando;

        /// <summary>
        /// /cambiar o no fabrica y docum fabrica revisar domentoacion y armar la nueva
        /// </summary>

        static LeerGuardarBaseDatos()
        {
                    
        }

        /// <summary>
        /// Agrega o updatea  el objeto pasado por segundo parametro como new IndumentariaEventArgs(indumentaria) a la tabla Manufacturados
        /// </summary>
        /// <param name="source">Se usa la funcion AltaBajaConsultaListas.IndumentariaEnBDProduccion(this) que devuelve la cantidad de fabricados en la base de datos, 0 significa que no esta en la base de datos ()</param>
        /// <param name="args">pasado como new IndumentariaEventArgs(indumentariaAgregar)</param>
        public static void GuardarFabricadoEnDB(object source, IndumentariaEventArgs args)
        {
            //Casteamos lo que nos viene en los argumentos, es decir nuestra indumentaria a ser guardada
            Indumentaria indumentariaFabricar = args.IndumentariaObject;

            //Convertimos a decimal porque asi lo toma los parametros del comando
            decimal cantidadFabricadaBD = (decimal)((int)source);
            if (indumentariaFabricar != null)
            {
                LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                LeerGuardarBaseDatos.comando = new SqlCommand();
                LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }
                LeerGuardarBaseDatos.comando.Parameters.Clear();

                //Cuando se nos pasa 0 debemos insertar la nueva indumentaria en la base de datos
                if (cantidadFabricadaBD == 0)
                {
                    LeerGuardarBaseDatos.comando.CommandText = "INSERT INTO Manufacturados(codigoModelo, nombreModelo, cantidadFabricada, fechaUltimaManufactura) VALUES(@codModelo, @nombreMod, @cantFab, @fechaUltima)";
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@codModelo", indumentariaFabricar.CodigoUnico);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@nombreMod", indumentariaFabricar.Modelo);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@cantFab", (decimal)indumentariaFabricar.CantidadManufacturada);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@fechaUltima", DateTime.Now.ToString("dd-MM-yyyy HHmmss"));
                }
                else//cuando tenga mas de uno debo actualizar su cantidad manufacturada (agregandole 1) y su ultima fecha de manufactura
                {
                    LeerGuardarBaseDatos.comando.CommandText = "UPDATE Manufacturados SET cantidadFabricada = @cantFab, fechaUltimaManufactura= @fechaUltima WHERE nombreModelo = @nombreMod";
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@nombreMod", indumentariaFabricar.Modelo);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@cantFab", cantidadFabricadaBD + 1);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@fechaUltima", DateTime.Now.ToString("dd-MM-yyyy HHmmss"));
                }

                LeerGuardarBaseDatos.comando.ExecuteNonQuery();
            }
            else
            {
                throw new IndumentariasExceptionsErrorAlFabricar("Error al castear source de evento a indumentaria para ser guardada en BD de producido", null);
            }

        }


        /// <summary>
        /// Agrega el objeto pasado por segundo parametro como new IndumentariaEventArgs(indumentaria) a la tabla de disponibles. No agregar Duplicados
        /// </summary>
        /// <param name="source">Indistinto</param>
        /// <param name="args">pasado como new IndumentariaEventArgs(indumentariaAgregar)</param>
        public static void GuardarDisponibleEnDB(object source, IndumentariaEventArgs args)
        {
            Indumentaria indumentariaAgregar = args.IndumentariaObject;
            if (!(indumentariaAgregar is null))
            {
                try
                {
                    LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                    LeerGuardarBaseDatos.comando = new SqlCommand();
                    LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

                    if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                    {
                        LeerGuardarBaseDatos.conexion.Open();
                    }

                    LeerGuardarBaseDatos.comando.Parameters.Clear();

                    //debo saber a que lista de disponiblesagregarla 
                    if (indumentariaAgregar is Camiseta)
                    {
                        LeerGuardarBaseDatos.comando.CommandText = "INSERT INTO DiseñosDisponiblesCamisetas(codigoModelo, nombreModelo,       peso,porcentajeAlgodon,costoProduccion, estampado) VALUES(@codigoMod, @nombreMod, @peso, @porcent, @costo,@estamp)";

                        LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@estamp", ((Camiseta)indumentariaAgregar).Estampado ? 1 : 0);
                    }
                    else
                    {
                        LeerGuardarBaseDatos.comando.CommandText = "INSERT INTO DiseñosDisponiblesZapatillas(codigoModelo, nombreModelo,      peso,porcentajeAlgodon,costoProduccion) VALUES(@codigoMod, @nombreMod, @peso, @porcent, @costo)";
                    }

                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@codigoMod", indumentariaAgregar.CodigoUnico);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@nombreMod", indumentariaAgregar.Modelo);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@peso", (decimal)indumentariaAgregar.Peso);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@porcent", (decimal)indumentariaAgregar.PorcentajeAlgodon);
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@costo", (decimal)indumentariaAgregar.CostoProduccion);

                    LeerGuardarBaseDatos.comando.ExecuteNonQuery();
                    LeerGuardarBaseDatos.conexion.Close();



                }
                catch (Exception e)
                {
                    throw new Exception("Hubo un error al guardar el modelo en la base de datos", e);
                }
                finally
                {
                    LeerGuardarBaseDatos.conexion.Close();
                }
            }

        }




        public static void BorrarIndumentariaDisponibleBaseDato(Indumentaria indumentariaBorrar)
        {
            try
            {
                LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                LeerGuardarBaseDatos.comando = new SqlCommand();
                LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;
                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }

                if (indumentariaBorrar is Zapatilla)
                {
                    LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM DiseñosDisponiblesZapatillas WHERE nombreModelo = @nombreMod";
                }
                else
                {
                    LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM DiseñosDisponiblesCamisetas WHERE nombreModelo = @nombreMod";
                }
                LeerGuardarBaseDatos.comando.Parameters.Clear();
                LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@nombreMod", indumentariaBorrar.Modelo);

                LeerGuardarBaseDatos.comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al borrar el modelo en la base de datos", e);
            }
            finally
            {
                LeerGuardarBaseDatos.conexion.Close();
            }
           
        }

        public static void BorrarIndumentariaManufacturadaBaseDatos(Indumentaria indumentariaBorrar)
        {
            try
            {
                Dictionary<string, int> manufacturadosDB = new Dictionary<string, int>();
                LeerGuardarBaseDatos.LeerBaseDatosManufacturados(out manufacturadosDB);
                int cantidadFabricados = manufacturadosDB[indumentariaBorrar.Modelo];
                //manufacturadosDB.TryGetValue(indumentariaBorrar.Modelo, out cantidadFabricados);

                LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                LeerGuardarBaseDatos.comando = new SqlCommand();
                LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }
               
                LeerGuardarBaseDatos.comando.Parameters.Clear();
                //typeof(Indumentaria);
                if (manufacturadosDB.ContainsKey(indumentariaBorrar.Modelo) && cantidadFabricados > 1)
                {
                    LeerGuardarBaseDatos.comando.CommandText = "UPDATE Manufacturados SET cantidadFabricada = @cantFab WHERE nombreModelo = @nombreMod";
                    
                    LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@cantFab", cantidadFabricados-1);
                }
                else
                {
                    LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM Manufacturados WHERE nombreModelo = @nombreMod";
                }
                
                LeerGuardarBaseDatos.comando.Parameters.AddWithValue("@nombreMod", indumentariaBorrar.Modelo);
                

                LeerGuardarBaseDatos.comando.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al borrar el modelo en la base de datos", e);
            }
            finally
            {
                LeerGuardarBaseDatos.conexion.Close();
            }
        }

       /// <summary>
       /// Borra por completo la base de datos de disponibles del tipo de indumentaria pasado por parametro
       /// </summary>
       /// <typeparam name="T">Tipo de indumentaria a ser borrada en su totalidad</typeparam>
        public static void BorrarBaseDatosDisponibles<T>()
        {
            try
            {
                LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                LeerGuardarBaseDatos.comando = new SqlCommand();
                LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }
                
                //typeof(Indumentaria);
                if (typeof(T) == typeof(Indumentaria))
                {
                    if (AltaBajaConsultaListas.ListaIndumentariaDisponible<Camiseta>().Count > 0)
                    {
                        LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM DiseñosDisponiblesCamisetas";
                        LeerGuardarBaseDatos.comando.ExecuteNonQuery();
                        LeerGuardarBaseDatos.conexion.Close();
                    }

                    if (AltaBajaConsultaListas.ListaIndumentariaDisponible<Zapatilla>().Count > 0)
                    {
                        if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                        {
                            LeerGuardarBaseDatos.conexion.Open();
                        }
                        LeerGuardarBaseDatos.comando.Parameters.Clear();
                        LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM DiseñosDisponiblesZapatillas";
                        LeerGuardarBaseDatos.comando.ExecuteNonQuery();
                        LeerGuardarBaseDatos.conexion.Close();
                    }
                }
                else
                {
                    Type tipoParam = typeof(T);
                    LeerGuardarBaseDatos.comando.CommandText = "DELETE FROM DiseñosDisponibles"+ tipoParam.ToString() + "s";
                    LeerGuardarBaseDatos.comando.ExecuteNonQuery();
                    LeerGuardarBaseDatos.conexion.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al borrar el modelo en la base de datos", e);
            }
            finally
            {
                LeerGuardarBaseDatos.conexion.Close();
            }
        }
    

        /// <summary>
        /// Lee la base de datos de indumentaria disponible y la devuelve en una lista de Indumentaria
        /// </summary>
        /// <param name="listaIndumentariaDisponible">Lista a la que se cargaran las indumentarias que estan en la base de datos</param>
        public static void LeerBaseDatosDisponibles( out List<Indumentaria> listaIndumentariaDisponible)
        {
           listaIndumentariaDisponible = new List<Indumentaria>();
           try
           {
               LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
               LeerGuardarBaseDatos.comando = new SqlCommand();
               LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

               if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
               {
                   LeerGuardarBaseDatos.conexion.Open();
               }

               LeerGuardarBaseDatos.comando.CommandText = "SELECT * FROM DiseñosDisponiblesCamisetas";

               SqlDataReader oDrIndumentariaLeida = LeerGuardarBaseDatos.comando.ExecuteReader();

                ///Inicializo mi indumentaria que quiero leer en null para que pueda hacer los chequeos correspondientes
               Indumentaria indumentariaAgregar = null;
               while (oDrIndumentariaLeida.Read())
               {
                    ///casteo lo que lee mi lector a variables
                    string columnaNombreModelo = oDrIndumentariaLeida["nombreModelo"].ToString();
                    string columnaPeso = oDrIndumentariaLeida["peso"].ToString();
                    string columnaPorcentajeAlgodon = oDrIndumentariaLeida["porcentajeAlgodon"].ToString();
                    string columnaCostoProduccion = oDrIndumentariaLeida["costoProduccion"].ToString();
                     //Esta variable la guarde como 0 siendo false y 1 siendo true
                    bool columnaEstampado = ((int)oDrIndumentariaLeida["estampado"] == 1);

                    indumentariaAgregar = new Camiseta(float.Parse(columnaPorcentajeAlgodon), columnaEstampado, columnaNombreModelo);

                     //if (((int)oDrIndumentariaLeida["estampado"] == 1))
                     //{
                     //indumentariaAgregar = new Camiseta(float.Parse(columnaPorcentajeAlgodon), true, columnaNombreModelo);
                     //}
                     //else if (((int)oDrIndumentariaLeida["estampado"] == 0))
                     //{
                     //indumentariaAgregar = new Camiseta(float.Parse(columnaPorcentajeAlgodon), true, columnaNombreModelo);
                     //}

                     if (!(indumentariaAgregar.Equals(null)))
                     {
                         listaIndumentariaDisponible.Add(indumentariaAgregar);
                     }
                     else
                     {
                         throw new Exception("Hubo un al leer la indumentaria desde la base de datos");
                     }

               }
               LeerGuardarBaseDatos.conexion.Close();
               ////Debo cerrar y abrir de nuevo la conexion para hcer un nuevo query
               LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;
               if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
               {
                   LeerGuardarBaseDatos.conexion.Open();
               }
               LeerGuardarBaseDatos.comando.CommandText = "SELECT * FROM DiseñosDisponiblesZapatillas";

               SqlDataReader oDrZapa = LeerGuardarBaseDatos.comando.ExecuteReader();
               indumentariaAgregar = null;
               while (oDrZapa.Read())
               {
                   string columnaNombreModelo = oDrZapa["nombreModelo"].ToString();
                   string columnaPeso = oDrZapa["peso"].ToString();
                   string columnaPorcentajeAlgodon = oDrZapa["porcentajeAlgodon"].ToString();
                   string columnaCostoProduccion = oDrZapa["costoProduccion"].ToString();
                   
                   //Debemos separar la capellada y la suela (el nombre de las zapatillas se basa en esto)
                   string capelladaSuela = Regex.Replace(columnaNombreModelo, "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 ");

                   //Esto seria un array con la capellada en posicion 0, con suela en posicion 1 y con anio de produ en posicion 2
                   string[] nombreZapatilla = capelladaSuela.Split();

                   //Aca creo ni nueva zapatilla, casteando la capellada y la suela.
                   indumentariaAgregar = new Zapatilla((ECapelladas)Enum.Parse(typeof(ECapelladas), nombreZapatilla[0]), (ESuelas)Enum.Parse(typeof(ESuelas), nombreZapatilla[1]), nombreZapatilla[2]);

                   if (!indumentariaAgregar.Equals(null))
                   {
                       listaIndumentariaDisponible.Add(indumentariaAgregar);
                   }
               }
           }
           catch (Exception e)
           {
               throw new Exception("Hubo un error al guardar el modelo en la base de datos", e);
           }
           finally
           {
               LeerGuardarBaseDatos.conexion.Close();
           }
        }

        /// <summary>
        /// Lee la base de datos de indumentaria fabricada y la devuelve en un diccionario
        /// </summary>
        /// <param name="diccionarioIndumentariaCantFabricada">Lista a la que quiero cargar mis pares de modelos y cantidad fabricada</param>
        public static void LeerBaseDatosManufacturados(out Dictionary<string, int > diccionarioIndumentariaCantFabricada)
        {
            diccionarioIndumentariaCantFabricada = new Dictionary<string, int>();
            try
            {
                LeerGuardarBaseDatos.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
                LeerGuardarBaseDatos.comando = new SqlCommand();
                LeerGuardarBaseDatos.comando.Connection = LeerGuardarBaseDatos.conexion;

                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }

                LeerGuardarBaseDatos.comando.CommandText = "SELECT * FROM Manufacturados";

                SqlDataReader oDrCami = LeerGuardarBaseDatos.comando.ExecuteReader();

                while (oDrCami.Read())
                {
                    //Por cada registro voy a recuperar la columna del nombre de modelo
                    string columnaNombreModelo = oDrCami["nombreModelo"].ToString();
                    //Y tambien la cantidad fabricada
                    int columnaCantidadFabricada;
                    //Para esto hago un TryParse y en el mismo if verifico que se recupero bien el nombre del modelo
                    if(int.TryParse(oDrCami["cantidadFabricada"].ToString(), out columnaCantidadFabricada) && !(String.IsNullOrEmpty(columnaNombreModelo)))
                    {
                        //agrego a este diccionario este par de datos
                        diccionarioIndumentariaCantFabricada.Add(columnaNombreModelo, columnaCantidadFabricada);
                    }
                }
               
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al guardar el modelo en la base de datos", e);
            }
            finally
            {
                LeerGuardarBaseDatos.conexion.Close();
            }
        }


       

    }
}
