using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logica;
using IndumentariasExceptiones;
using System.IO;
using System.Data.SqlClient;
using Logica.Documentos;
using Logica.BaseDeDatos;
using Logica.Listas;
using Logica.Objetos;


namespace UnitTestFabrica
{
    //new Zapatilla(Capelladas.Zoom, Suelas.React)
    [TestClass]
    public class TestDeFabrica
    {
        #region Zapatillas Camisetas 

        public Zapatilla indumentariaBienZapa1;
        public Zapatilla indumentariaBienZapa2;
        public Zapatilla indumentariaBienZapa3;
        public Zapatilla indumentariaBienZapa4;
        public Camiseta indumentariaBienCami1;
        public Camiseta indumentariaBienCami2;
        public Camiseta indumentariaBienCami3;
        public Camiseta indumentariaBienCami4;
        public Indumentaria indumentariaRepetidaCami;
        public Indumentaria indumentariaMismoObjeto;
        public Indumentaria indumentariaNull;

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            AltaBajaConsultaListas.borrarTandaProduccion();

            this.indumentariaBienZapa1 = new Zapatilla(ECapelladas.Zoom, ESuelas.React, "2021", "prueba");
            this.indumentariaBienZapa2 = new Zapatilla(ECapelladas.Revolution, ESuelas.Metcon, "2021", "prueba");
            this.indumentariaBienZapa3 = new Zapatilla(ECapelladas.Waffle, ESuelas.Shox, "2021", "prueba");
            this.indumentariaBienZapa4 = new Zapatilla(ECapelladas.Wildhorse, ESuelas.Pegasus, "2021", "prueba");
            this.indumentariaBienCami1 = new Camiseta(11.1f, true, "BienCami1", "prueba");
            this.indumentariaBienCami2 = new Camiseta(22.2f, false, "BienCami2", "prueba");
            this.indumentariaBienCami3 = new Camiseta(33.3f, true, "BienCami3", "prueba");
            this.indumentariaBienCami4 = new Camiseta(44.5f, false, "BienCami4", "prueba");
            this.indumentariaNull = null;
        }


        #region Testeos XML
        /// <summary>
        /// Agrega cuatro indumentaria y lo guarda en Escritorio como TestDisponibleGuardado, luego lo lee
        /// </summary>
        [TestMethod]
        public void TestGuardarLeerXML()
        {

            // seteo el path del archivo que utilizaran mis funciones de leido/guardado 
            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//TestDisponibleGuardado.xml";

            //Agrego cuatro indumentarias 
            this.TestCuatroIndumentarias("Disponible-Indumentaria");

            //Testeo si se cargaron las 4 indumentarias a lista de disponibles 
            LeerGuardarXML.GuardarDocumento<Indumentaria>(pathArchivo);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 4);

            //Limpio la lista y chequeo que esto se realizo bien
            AltaBajaConsultaListas.indumentariaDisponible.Clear();
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 0);

            //leo el mismo archivo que guarde arriba y chequeo 
            LeerGuardarXML.LeerDocumento(pathArchivo, out AltaBajaConsultaListas.indumentariaDisponible);
            Assert.IsTrue(AltaBajaConsultaListas.indumentariaDisponible.Count == 4);

        }


        /// <summary>
        /// Agrega cuatro zapatillas y guarda estas en XML, lo guarda en Escritorio como TestDisponibleGuardadoZapatillas, luego lo lee
        /// </summary>
        [TestMethod]
        public void TestGuardarLeerXMLGenerics()
        {
            // seteo el path del archivo que utilizaran mis funciones de leido/guardado 
            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//TestDisponibleGuardadoZapatillas.xml";

            //Agrego cuatro indumentarias 
            this.TestCuatroIndumentarias("Disponible-Zapatilla");

            //Testeo si se cargaron las 4 indumentarias a lista de disponibles 
            LeerGuardarXML.GuardarDocumento<Zapatilla>(pathArchivo);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 4);

            //Limpio la lista y chequeo que esto se realizo bien
            AltaBajaConsultaListas.indumentariaDisponible.Clear();
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 0);

            List<Zapatilla> listaZapatillas = AltaBajaConsultaListas.ListaIndumentariaDisponible<Zapatilla>();

            //leo el mismo archivo que guarde arriba y chequeo 
            LeerGuardarXML.LeerDocumento(pathArchivo, out listaZapatillas);
            Assert.IsTrue(listaZapatillas.Count == 4);


        }

        #endregion

        #region Testeos Listas

        /// <summary>
        /// Agrega 4 zapatillas y 4 camisetas a lista interna de Disponibles mediante Fabrica.AgregarIndumentariaDisponible y se filtran mediante Fabrica.ListaIndumentariaDisponible<T>
        /// </summary>
        [TestMethod]
        public void TestFiltrarTipoIndumentariaDisponible()
        {
            //Testeo que se suman 4 zapatillas ninguna camiseta
            this.TestCuatroIndumentarias("Disponible-Zapatillas");
            //Hago uso de la funcion para filtrar la lista
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Camiseta>().Count == 0);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Zapatilla>().Count == 4);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 4);
            AltaBajaConsultaListas.indumentariaDisponible.Clear();
            //Testeo que se suman 4 camisetas ninguna camiseta
            this.TestCuatroIndumentarias("Disponible-Camiseta");
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Camiseta>().Count == 4);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Zapatilla>().Count == 0);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>().Count == 4);
            AltaBajaConsultaListas.indumentariaDisponible.Clear();
        }

        /// <summary>
        /// Agrega 4 zapatillas y 4 camisetas a lista interna de Produccion mediante Fabrica.AgregarIndumentariaProduccion y se filtran mediante Fabrica.ListaIndumentariaProduccion<T>
        /// </summary>
        [TestMethod]
        public void TestFiltrarTipoIndumentariaProduccion()
        {
            //Testeo que se suman 4 zapatillas ninguna camiseta
            this.TestCuatroIndumentarias("Produccion-Zapatillas");
            //Hago uso de la funcion para filtrar la lista
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Camiseta>().Count == 0);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Zapatilla>().Count == 4);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>().Count == 4);
            AltaBajaConsultaListas.indumentariaProduccion.Clear();
            //Testeo que se suman 4 camisetas ninguna camiseta
            this.TestCuatroIndumentarias("Produccion-Camiseta");
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Camiseta>().Count == 4);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Zapatilla>().Count == 0);
            Assert.IsTrue(AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>().Count == 4);
            AltaBajaConsultaListas.indumentariaProduccion.Clear();
        }

        #endregion

        #region Pruebas base de datos

        /// <summary>
        /// agrega y consulta una zapatilla y una camiseta a la base de datos de disponibles. Luego de la prueba elimina las nuevas entradas de la BD 
        /// </summary>
        [TestMethod]
        public void AgregarConsultarBaseDatosDisponibles()
        {
            //Guardo los datos de mi base de datos en mi fabrica
            LeerGuardarBaseDatos.LeerBaseDatosDisponibles(out AltaBajaConsultaListas.indumentariaDisponible);

            //Borro estos datos en la base de datos
            if (AltaBajaConsultaListas.indumentariaDisponible.Count != 0)
            {
                LeerGuardarBaseDatos.BorrarBaseDatosDisponibles<Indumentaria>();
            }

            //Guardo dos indumentarias de las pruebas
            LeerGuardarBaseDatos.GuardarDisponibleEnDB(this, new IndumentariaEventArgs(this.indumentariaBienZapa1));
            LeerGuardarBaseDatos.GuardarDisponibleEnDB(this, new IndumentariaEventArgs(this.indumentariaBienCami1));
            AltaBajaConsultaListas.indumentariaDisponible.Add(this.indumentariaBienCami1);
            AltaBajaConsultaListas.indumentariaDisponible.Add(this.indumentariaBienZapa1);

            //Instancio una lista nueva para que la lectura de base de datos se haga aquí
            List<Indumentaria> listaPrueba = new List<Indumentaria>();
            LeerGuardarBaseDatos.LeerBaseDatosDisponibles(out listaPrueba);

            //Aca testeo que esten agregadas mis dos indumentarias que previamente guarde
            Assert.IsTrue(listaPrueba.Count == 2);

            ///Borramos los datos que utilizamos para el assert anterior
            LeerGuardarBaseDatos.BorrarBaseDatosDisponibles<Indumentaria>();
            AltaBajaConsultaListas.indumentariaDisponible.Remove(this.indumentariaBienCami1);
            AltaBajaConsultaListas.indumentariaDisponible.Remove(this.indumentariaBienZapa1);

            //Cargamos la base de datos con la indumentaria que estaba antes
            foreach (var item in AltaBajaConsultaListas.indumentariaDisponible)
            {
                LeerGuardarBaseDatos.GuardarDisponibleEnDB(this, new IndumentariaEventArgs(item));
            }

            //Leemos nuevamente para asegurarnos que se cargaron bien los elementos
            listaPrueba.Clear();
            LeerGuardarBaseDatos.LeerBaseDatosDisponibles(out listaPrueba);

            //Verificamos que esten alineada la lista interna con la lista leido de la base de datos.
            Assert.IsTrue(listaPrueba.Count == AltaBajaConsultaListas.indumentariaDisponible.Count);

        }

        /// <summary>
        /// Agrega 4 indumentarias (2 veces la misma zapatilla, 2 veces la misma camiseta) a la base de datos y se fija que se impacte estos cambios
        /// </summary>
        [TestMethod]
        public void AgregarConsultarBaseDatosManufacturados()
        {

            //Guardamos la cantidad de indumentaria que tenemos antes de nuestros testeos
            Dictionary<string, int> listaAntesTesteos = new Dictionary<string, int>();
            LeerGuardarBaseDatos.LeerBaseDatosManufacturados(out listaAntesTesteos);
            //En esta variable
            int cantidadInudmentariaAntesTesteo = listaAntesTesteos.Count;

            this.indumentariaBienCami1.CantidadManufacturada++;
            ///Agrego 4 indumentarias, tambien debo aumentar en una la cantidad manufacturada.
            LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienCami1), new IndumentariaEventArgs(this.indumentariaBienCami1));
            this.indumentariaBienCami1.CantidadManufacturada++;
            ///Cuando paso false como primer parametro significa que me actualizara la cantidad manufacturada, no que me agregara una entrada nueva
            LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienCami1), new IndumentariaEventArgs(this.indumentariaBienCami1));
            this.indumentariaBienZapa1.CantidadManufacturada++;
            LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienZapa1), new IndumentariaEventArgs(this.indumentariaBienZapa1));
            this.indumentariaBienZapa1.CantidadManufacturada++;
            LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienZapa1), new IndumentariaEventArgs(this.indumentariaBienZapa1));


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

                SqlDataReader oDrManufacturado = LeerGuardarBaseDatos.comando.ExecuteReader();
                int i = 0;
                // para no leer otros datos que esten antes, voy a limitarme a leer los dos primeros registros que sume
                while (oDrManufacturado.Read())
                {

                    //LeerGuardarBaseDatos.LeerBaseDatosManufacturados

                    i++;
                    string columnaCodigoModelo = oDrManufacturado["codigoModelo"].ToString();
                    string columnaNombreModelo = oDrManufacturado["nombreModelo"].ToString();
                    string columnaCantidadFabricada = oDrManufacturado["cantidadFabricada"].ToString();
                    string columnaFechaUltimaManufactura = oDrManufacturado["fechaUltimaManufactura"].ToString();

                    ///Primero chequeo que se haya leido las columnas bien
                    Assert.IsTrue(!(columnaCantidadFabricada is null && columnaCantidadFabricada.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaCodigoModelo is null && columnaCodigoModelo.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaNombreModelo is null && columnaNombreModelo.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaFechaUltimaManufactura is null && columnaFechaUltimaManufactura.Equals(String.Empty)));

                    ///Ademas de fijarnos que leyo bien, ahora nos fijamos que si son los agregados por esta prueba 
                    if (columnaCodigoModelo=="prueba")
                    {
                        ///Ambas indumentarias tienen que tener 2 unidades fabricadas
                        Assert.IsTrue(columnaCantidadFabricada == "2");

                        //nuestra ultima indumentaria que agregamos es la que leyamos primero la zapatilla
                        Assert.IsTrue(columnaNombreModelo == "ZoomReact2021" || columnaNombreModelo == "BienCami1");
                    }
                    //tengoq ue chequear cuando creo dos, salgo de la aplicativo, y cuando agrego nuevamente 1 tendira que tener 3, borro 1 y sigo teniendo 2
                }
                LeerGuardarBaseDatos.conexion.Close();
                //Cierro la conexion de mi consulta

                ///agrego 1 mas de cada objeto
                LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienCami1), new IndumentariaEventArgs(this.indumentariaBienCami1));
                this.indumentariaBienCami1.CantidadManufacturada++;
                ///Tengo que pasarle la cantidad que ya tiene la base de datos (ahora mismo 2) y me actualizara la cantidad manufacturada a 3
                LeerGuardarBaseDatos.GuardarFabricadoEnDB(AltaBajaConsultaListas.IndumentariaEnBDProduccion(this.indumentariaBienZapa1), new IndumentariaEventArgs(this.indumentariaBienZapa1));
                this.indumentariaBienZapa1.CantidadManufacturada++;


                //y me preparo para consultar de nuevo
                if (LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Open && LeerGuardarBaseDatos.conexion.State != System.Data.ConnectionState.Connecting)
                {
                    LeerGuardarBaseDatos.conexion.Open();
                }

                LeerGuardarBaseDatos.comando.CommandText = "SELECT * FROM Manufacturados";

                oDrManufacturado = LeerGuardarBaseDatos.comando.ExecuteReader();

                while (oDrManufacturado.Read())
                {
                    i++;
                    string columnaCodigoModelo = oDrManufacturado["codigoModelo"].ToString();
                    string columnaNombreModelo = oDrManufacturado["nombreModelo"].ToString();
                    string columnaCantidadFabricada = oDrManufacturado["cantidadFabricada"].ToString();
                    string columnaFechaUltimaManufactura = oDrManufacturado["fechaUltimaManufactura"].ToString();

                    ///Primero chequeo que se haya leido las columnas bien
                    Assert.IsTrue(!(columnaCantidadFabricada is null && columnaCantidadFabricada.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaCodigoModelo is null && columnaCodigoModelo.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaNombreModelo is null && columnaNombreModelo.Equals(String.Empty)));
                    Assert.IsTrue(!(columnaFechaUltimaManufactura is null && columnaFechaUltimaManufactura.Equals(String.Empty)));

                    ///Ademas de fijarnos que leyo bien, ahora nos fijamos que si son los agregados por esta prueba 
                    if (columnaCodigoModelo == "prueba")
                    {
                        //Nuestra zapatillo o camisa deberian ser siempre las mismas
                        Assert.IsTrue(columnaNombreModelo == "ZoomReact2021" || columnaNombreModelo == "BienCami1");
                        //ahora deberia tener 3, ya que la primer vez agregue 2 y en esta ocasion sume 1.
                        Assert.IsTrue(columnaCantidadFabricada == "3");
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al guardar el modelo en la base de datos", e);
            }
            finally
            {
                //Borro mis 4 
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienCami1);
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienCami1);
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienCami1);
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienZapa1);
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienZapa1);
                LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(indumentariaBienZapa1);

                Dictionary<string, int> listaDespuesTesteos = new Dictionary<string, int>();
                LeerGuardarBaseDatos.LeerBaseDatosManufacturados(out listaDespuesTesteos);
                Assert.IsTrue(cantidadInudmentariaAntesTesteo == listaDespuesTesteos.Count);
                LeerGuardarBaseDatos.conexion.Close();
                //para no afectar nuestra base de datos eliminaremos las indumentarias que agregamos al principio del test
                
            }
        }

        #endregion

        #region Funciones Auxiliares
        /// <summary>
        /// Agrega a la lista indicada 2 sumando y agregando a lista de produccion/disponibles y el tipo que pase por parametro
        /// </summary>
        /// <param name="parametros">Produccion/Disponible-Indumentaria/Zapatilla/Camiseta</param>
        public void TestCuatroIndumentarias(string parametros)
        {
            AltaBajaConsultaListas.indumentariaDisponible.Clear();
            if (parametros.Contains("Disponible"))
            {
                if (parametros.Contains("Indumentaria"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa1));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa2));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami1));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami2));
                }
                else if (parametros.Contains("Zapatilla"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa1));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa2));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa3));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienZapa4));
                }
                else if (parametros.Contains("Camiseta"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami1));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami2));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami3));
                    AltaBajaConsultaListas.AgregarIndumentariaDisponible(this, new IndumentariaEventArgs(indumentariaBienCami4));
                }

            }
            else if (parametros.Contains("Produccion"))
            {

                if (parametros.Contains("Indumentaria"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa1), new IndumentariaEventArgs(indumentariaBienZapa1));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa2), new IndumentariaEventArgs(indumentariaBienZapa2));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami1), new IndumentariaEventArgs(indumentariaBienCami1));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami2), new IndumentariaEventArgs(indumentariaBienCami2));
                }
                else if (parametros.Contains("Zapatilla"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa1), new IndumentariaEventArgs(indumentariaBienZapa1));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa2), new IndumentariaEventArgs(indumentariaBienZapa2));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa3), new IndumentariaEventArgs(indumentariaBienZapa3));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienZapa4), new IndumentariaEventArgs(indumentariaBienZapa4));
                }
                else if (parametros.Contains("Camiseta"))
                {
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami1), new IndumentariaEventArgs(indumentariaBienCami1));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami2), new IndumentariaEventArgs(indumentariaBienCami2));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami3), new IndumentariaEventArgs(indumentariaBienCami3));
                    AltaBajaConsultaListas.AgregarIndumentariaProduccion(AltaBajaConsultaListas.IndumentariaEnBDProduccion(indumentariaBienCami4), new IndumentariaEventArgs(indumentariaBienCami4));
                }
            }
        }

        #endregion
    }
}
