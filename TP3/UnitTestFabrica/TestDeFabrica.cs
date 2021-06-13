using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logica;
using IndumentariasExceptions;
using System.IO;

namespace UnitTestFabrica
{
    //new Zapatilla(Capelladas.Zoom, Suelas.React)
    [TestClass]
    public class TestDeFabrica
    {
        //(Capelladas capellada, Suelas suela, float costoProduccion)
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


        [TestInitialize]
        public void Initialize()
        {
            Fabrica.borrarTandaProduccion();

            this.indumentariaBienZapa1 = new Zapatilla(ECapelladas.Zoom, ESuelas.React);
            this.indumentariaBienZapa2 = new Zapatilla(ECapelladas.Revolution, ESuelas.Metcon);
            this.indumentariaBienZapa3 = new Zapatilla(ECapelladas.Waffle, ESuelas.Shox);
            this.indumentariaBienZapa4 = new Zapatilla(ECapelladas.WildHorse, ESuelas.Pegasus);
            this.indumentariaBienCami1 = new Camiseta(11.1f, true, "BienCami1");
            this.indumentariaBienCami2 = new Camiseta(22.2f, false, "BienCami2");
            this.indumentariaBienCami3 = new Camiseta(33.3f, true, "BienCam13");
            this.indumentariaBienCami4 = new Camiseta(44.5f, false, "BienCami4");
            this.indumentariaNull = null;
        }

        /// <summary>
        /// Agrega a la lista indicada y el tipo que pase por parametro
        /// </summary>
        /// <param name="parametros">Produccion/Disponible-Indumentaria/Zapatilla/Camiseta</param>
        public void CuatroIndumentarias(string parametros)
        {
            Fabrica.indumentariaDisponible.Clear();
            if (parametros.Contains("Disponible"))
            {
                if (parametros.Contains("Indumentaria"))
                {
                    Fabrica.agregarADisponible(indumentariaBienZapa1);
                    Fabrica.agregarADisponible(indumentariaBienZapa2);
                    Fabrica.agregarADisponible(indumentariaBienCami1);
                    Fabrica.agregarADisponible(indumentariaBienCami2);
                } else if (parametros.Contains("Zapatilla"))
                {
                    Fabrica.agregarADisponible(indumentariaBienZapa1);
                    Fabrica.agregarADisponible(indumentariaBienZapa2);
                    Fabrica.agregarADisponible(indumentariaBienZapa3);
                    Fabrica.agregarADisponible(indumentariaBienZapa4);
                } else if (parametros.Contains("Camiseta"))
                {
                    Fabrica.agregarADisponible(indumentariaBienCami1);
                    Fabrica.agregarADisponible(indumentariaBienCami2);
                    Fabrica.agregarADisponible(indumentariaBienCami3);
                    Fabrica.agregarADisponible(indumentariaBienCami4);
                }

            } else if (parametros.Contains("Produccion"))
            {

                if (parametros.Contains("Indumentaria"))
                {
                    indumentariaBienZapa1.Fabricar();
                    indumentariaBienZapa2.Fabricar();
                    indumentariaBienCami1.Fabricar();
                    indumentariaBienCami2.Fabricar();
                } else if (parametros.Contains("Zapatilla"))
                {
                    indumentariaBienZapa1.Fabricar();
                    indumentariaBienZapa2.Fabricar();
                    indumentariaBienZapa3.Fabricar();
                    indumentariaBienZapa4.Fabricar();
                } else if (parametros.Contains("Camiseta"))
                {
                    indumentariaBienCami1.Fabricar();
                    indumentariaBienCami2.Fabricar();
                    indumentariaBienCami3.Fabricar();
                    indumentariaBienCami4.Fabricar();
                }
            }
        }


        [TestMethod]
        public void GuardarLeerXML()
        {

            // seteo el path del archivo que utilizaran mis funciones de leido/guardado 
            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//DisponibleGuardado.xml";

            //Agrego cuatro indumentarias 
            this.CuatroIndumentarias("Disponible-Indumentaria");

            //Testeo si se cargaron las 4 indumentarias a lista de disponibles 
            DocumentosFabrica.GuardarDocumento<Indumentaria>(pathArchivo);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 4);

            //Limpio la lista y chequeo que esto se realizo bien
            Fabrica.indumentariaDisponible.Clear();
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 0);

            //leo el mismo archivo que guarde arriba y chequeo 
            DocumentosFabrica.LeerDocumento(pathArchivo, out Fabrica.indumentariaDisponible);
            Assert.IsTrue(Fabrica.indumentariaDisponible.Count == 4);

        }

        [TestMethod]
        public void GuardarLeerXMLGenerics()
        {
            // seteo el path del archivo que utilizaran mis funciones de leido/guardado 
            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//DisponibleGuardadoZapatillas.xml";

            //Agrego cuatro indumentarias 
            this.CuatroIndumentarias("Disponible-Zapatilla");

            //Testeo si se cargaron las 4 indumentarias a lista de disponibles 
            DocumentosFabrica.GuardarDocumento<Zapatilla>(pathArchivo);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 4);

            //Limpio la lista y chequeo que esto se realizo bien
            Fabrica.indumentariaDisponible.Clear();
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 0);

            List<Zapatilla> listaZapatillas = Fabrica.ListaIndumentariaDisponible<Zapatilla>();

            //leo el mismo archivo que guarde arriba y chequeo 
            DocumentosFabrica.LeerDocumento(pathArchivo, out listaZapatillas);
            Assert.IsTrue(listaZapatillas.Count == 4);


        }

            [TestMethod]
        public void AgregarInduDisponible()
        {
            //testo que se agreguen 4 indumentarias correctamente a disponible(Utilizando Fabrica.agregarADisponible(Indumentaria))
            this.CuatroIndumentarias("Disponible-Indumentaria");
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 4);
        }

        [TestMethod]
        public void AgregarInduProduccion()
        {
            //testo que se agreguen 4 indumentarias correctamente a produccion(Utilizando indumentaria.Fabricar()))
            this.CuatroIndumentarias("Produccion-Indumentaria");
            Assert.IsTrue(Fabrica.ListaIndumentariaProduccion<Indumentaria>().Count == 4);
        }

        [TestMethod]
        public void FiltrarTipoIndumentaria()
        {
            //Testeo que se suman 4 zapatillas ninguna camiseta
            this.CuatroIndumentarias("Disponible-Zapatillas");
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Camiseta>().Count == 0);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Zapatilla>().Count == 4);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 4);
            Fabrica.indumentariaDisponible.Clear();
            //Testeo que se suman 4 camisetas ninguna camiseta
            this.CuatroIndumentarias("Disponible-Camiseta");
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Camiseta>().Count == 4);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Zapatilla>().Count == 0);
            Assert.IsTrue(Fabrica.ListaIndumentariaDisponible<Indumentaria>().Count == 4);
            Fabrica.indumentariaDisponible.Clear();
        }



  


    }


}
