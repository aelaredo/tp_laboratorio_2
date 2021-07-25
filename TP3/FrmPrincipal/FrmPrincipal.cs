using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using IndumentariasExceptiones;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;
using Logica.BaseDeDatos;
using Logica.Listas;
using Logica.Documentos;
using Logica.Objetos;
using Logica.Interfaces;

namespace FrmPrincipal
{
    public delegate void Fabricar();
    public delegate void ProbandoFormNuevaIndu(object objeto);
    public partial class FrmPrincipal : Form
    {
        Thread hiloFabricarIndu;
        public static event Fabricar EsperarFabricar;
        
        public FrmPrincipal()
        {
            InitializeComponent();
            //esperarFabricar += BarraProgresoFabricacion;
        }


        /// <summary>
        /// Al cargar la aplicacion se busca en la carpeta que se indique cual es el ultimo archivo de indumentaruia disponible y ya se carga la lista con esto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //string[] files = Directory.GetFiles((Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), "IndumentariaDisponible?????????????????.xml");

            ///// si se encontro alguna lista de indumentaria disponible, se leera la primera de la lista
            //if (files.Length > 0)
            //{
            //aca tambien se podria llenar la lista de manufactura con otro archivo
            //DocumentosFabrica.LeerDocumento(files[files.Length - 1], out Fabrica.indumentariaDisponible);
            try
            {
                LeerGuardarBaseDatos.LeerBaseDatosDisponibles(out AltaBajaConsultaListas.indumentariaDisponible);
            }
            catch(Exception excepcion)
            {
                MessageBox.Show("Error al cargar de base de datos", excepcion.Message);
            }
                
               
            //}
            //llenamos los lisboxes, con listas de tipo Indumentaria
            this.lstBoxInduDisponible.DataSource = AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>();
            this.lstBoxInduManufacturada.DataSource = AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>();

        }

        public static void ActualizarListBoxDisponible(object sender)
        {
            //if (this.lstBoxInduDisponible.InvokeRequired)
            //{
            
            //}
            if (((ListBox)sender).InvokeRequired)
            {
                ProbandoFormNuevaIndu relato = new ProbandoFormNuevaIndu(ActualizarListBoxDisponible);
                ((ListBox)sender).Invoke(relato);
            }
            else
            {
                //while (true)
                //{
                    ((ListBox)sender).DataSource = AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>();
                //}
            }
            
            
        }

        /// <summary>
        /// Si en este metodo el path es incorrecto y falla el guardado de la lista disponible por esto, el metodo DocumentosFabrica.GuardarDocumento generara una excepcion  que sera catcheada y mostrada, junto con la informacion del path que se genero en esta misma funcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            /// ahora la actualizacion de la db la hago al momento de agregar y quitar indumentarias
            /// 

            //string nombreArchivo = "\\IndumentariaDisponible" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            //string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            //try
            //{
            //    DocumentosFabrica.GuardarDocumento<Indumentaria>(pathArchivo);
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("Hubo un error al guardar el archivo " + pathArchivo + error.Message);
            //}

        }


        /// <summary>
        /// cada vez que se pinta el form se calcula el costo de la lista de produccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Paint(object sender, PaintEventArgs e)
        {
            float costoTanda = 0;

            foreach (object item in this.lstBoxInduManufacturada.Items)
            {
                costoTanda += ((Indumentaria)item).CostoProduccion * (((Indumentaria)item).CantidadManufacturada);
            }
           this.txtCostoTanda.Text = costoTanda.ToString();

        }


        #region Eventos listBoxes
        /// <summary>
        /// Cuando se selecciona un item en el list box de indumentaria manufacturada se nos muestra el detalle en sus respectivos casilleros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxInduManufacturada_SelectedValueChanged(object sender, EventArgs e)
        {
            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduManufacturada.SelectedItem;

            this.txtTipo.Text = seleccionada.GetType().ToString().Replace("Logica.Objetos.", "");
            if (seleccionada is Camiseta && ((Camiseta)seleccionada).Estampado)
            {
                this.txtTipo.Text += " con estampado";
            }
            else if (seleccionada is Camiseta && !(((Camiseta)seleccionada).Estampado))
            {
                this.txtTipo.Text += " lisa";
            }
            this.txtModelo.Text = seleccionada.Modelo;
            this.txtCodigo.Text = seleccionada.CodigoUnico;
            this.txtPeso.Text = seleccionada.Peso.ToString();
            this.txtPorcent.Text = seleccionada.PorcentajeAlgodon.ToString();
            this.txtCosto.Text = seleccionada.CostoProduccion.ToString();
            this.numCantFabricada.Value = seleccionada.CantidadManufacturada;
        }

        /// <summary>
        /// Cuando se selecciona un item en el list box de indumentaria disponible se nos muestra el detalle en sus respectivos casilleros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxInduDisponible_SelectedValueChanged(object sender, EventArgs e)
        {
            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;

            this.txtTipoDisp.Text = seleccionada.GetType().ToString().Replace("Logica.Objetos.", "");

            if (seleccionada is Camiseta && ((Camiseta)seleccionada).Estampado)
            {
                this.txtTipoDisp.Text += " con estampado";
            }
            else if (seleccionada is Camiseta && !(((Camiseta)seleccionada).Estampado))
            {
                this.txtTipoDisp.Text += " lisa";
            }

            this.txtCodigoDisp.Text = seleccionada.CodigoUnico;
            this.txtModeloDisp.Text = seleccionada.Modelo;
            this.txtPesoDisp.Text = seleccionada.Peso.ToString();
            this.txtPorcentDisp.Text = seleccionada.PorcentajeAlgodon.ToString();
            this.txtCostoDisp.Text = seleccionada.CostoProduccion.ToString();

        }
        #endregion

        #region Eventos Botones
        private void btnAgregarAManufactura_Click(object sender, EventArgs e)
        {
            //Primero chequeamos que halla articulos disponibles para pasar a manufactura
            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                MessageBox.Show("No hay indumentarias disponibles para ser manufacturadas");
                return;
            }


            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;

            try
            {
                //Una vez que casteamos el item seleccionado hacemos uso del metodo su interface
                seleccionada.Fabricar();
                //Luego de que se agregue a la lista de manufactura es necesario que actualicemos la lista para que muestre este nuevo item que acabamos de agregar
                //this.esperarFabricar.BeginInvoke();
                //hiloFabricarIndu = new Thread(BarraProgresoFabricacion);
                //hiloFabricarIndu.Start();
                this.lstBoxInduManufacturada.DataSource = AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>();
                
                //Luego lo seleccionamos para que se vea que se agrego
                this.lstBoxInduManufacturada.SelectedItem = seleccionada;
            }
            catch (Exception error)
            {
                //Catcheamos cualquier excepcion que se pueda dar al momento de agregar la indumentaria a la lista de produccion
                MessageBox.Show(error.Message + error.InnerException.Message);
            }
            
        }

    

        private void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "\\FabricaProduccion " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            if (this.lstBoxInduManufacturada.Items.Count == 0)
            {
                MessageBox.Show("No se encuentran indumentarias para ser manufacturadas");
                return;
            }

            try
            {
                LeerGuardarXML.GuardarDocumento<Indumentaria>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo en "+ pathArchivo + error.Message);
            }
            
        }

        private void btnBorrarProducida_Click(object sender, EventArgs e)
        {
            if (this.lstBoxInduManufacturada.Items.Count ==0)
            {
                MessageBox.Show("No se encuentran indumentarias en la tanda para ser manufacturadas");
                return;
            }

            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduManufacturada.SelectedItem;
            //Si es el caso de que hay mas de una indumentaria, simplemente que se reste una unidad
            LeerGuardarBaseDatos.BorrarIndumentariaManufacturadaBaseDatos(seleccionada);
            if (seleccionada.CantidadManufacturada > 1)
            {
                seleccionada.CantidadManufacturada--;
            }
            else
            {
                //Si no borramos directamente ese objeto
                seleccionada.CantidadManufacturada--;
                AltaBajaConsultaListas.indumentariaProduccion.Remove(seleccionada);
            }

            this.lstBoxInduManufacturada.DataSource = AltaBajaConsultaListas.ListaIndumentariaProduccion<Indumentaria>();

            //Si es el caso de que no quede ninguna indumentaria en el listbox, que se limpien los casilleros de los detalles
            if (this.lstBoxInduManufacturada.Items.Count == 0)
            {
                this.limpiarCasillerosInduManufacturada();
            }

        }

        private void btnBorrarDisp_Click(object sender, EventArgs e)
        {
            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                MessageBox.Show("No se encuentran indumentarias disponibles para ser borradas");
                return;
            }

            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;


            if (MessageBox.Show($"Esta seguro que desea borrar {seleccionada.Modelo} de la lista y de la base de datos?",
               "Confirmacion de eliminacion",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            if (!AltaBajaConsultaListas.indumentariaDisponible.Remove(seleccionada))
            {
                MessageBox.Show("No se encontro la indumentaria para ser borrado");
                return;
            }
            LeerGuardarBaseDatos.BorrarIndumentariaDisponibleBaseDato(seleccionada);
            //Fabrica.conexion = new SqlConnection("Data Source=.; Initial Catalog=Modelos; Integrated Security=True");
            //Fabrica.comando = new SqlCommand();
            //Fabrica.comando.Connection = Fabrica.conexion;


            //if (seleccionada is Zapatilla)
            //{
            //    Fabrica.comando.CommandText = "DELETE FROM DiseñosDisponiblesZapatillas WHERE nombreModelo = @nombreMod";
            //}else
            //{
            //    Fabrica.comando.CommandText = "DELETE FROM DiseñosDisponiblesCamisetas WHERE nombreModelo = @nombreMod";
            //}
            //Fabrica.comando.Parameters.Clear();
            //Fabrica.comando.Parameters.AddWithValue("@nombreMod", seleccionada.Modelo);

            //Fabrica.EjecutarNonQuerySQL();

            this.lstBoxInduDisponible.DataSource = AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>();

            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                this.LimpiarCasillerosInduDisponible();
            }
        }
        //public delegate void ParameterizedThreadStart(object objeto, ListBoxEventArgs eventArgs);
        
        private void btnAgregarNuevaIndu_Click(object sender, EventArgs e)
        {
            FrmCrearIndumentaria ventanaCrearIndumentaria = new FrmCrearIndumentaria(this.lstBoxInduDisponible);
            ventanaCrearIndumentaria.ShowDialog();

            //Al volver del cuadro que nos permitio agregar una indumentaria a la lista de disponibles, actualizamos el source de la listbox
            this.lstBoxInduDisponible.DataSource = AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>();
        }
       
        #endregion

        #region Eventos ToolStrip
        private void generarDocumentoDeManufacturaSoloCAMISTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AltaBajaConsultaListas.ListaIndumentariaProduccion<Camiseta>().Count == 0)
            {
                MessageBox.Show("No se encuentran camisetas para ser manufacturadas");
                return;
            }

            //Se decidio crear estas variables para que las llamadas a las funciones se pueda cambiar en algun momento, pero que mantenga el formato
            string nombreArchivo = "\\FabricaProduccionCamisetas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                LeerGuardarXML.GuardarDocumento<Camiseta>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }

            
        }

        private void generarDocManufacturaSoloZAPATILLASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AltaBajaConsultaListas.ListaIndumentariaProduccion<Zapatilla>().Count == 0)
            {
                MessageBox.Show("No se encuentran zapatillas para ser manufacturadas");
                return;
            }

            string nombreArchivo = "\\FabricaProduccionZapatillas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                LeerGuardarXML.GuardarDocumento<Zapatilla>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }

        }

        private void documentosDisponiblesSoloZAPATILLASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AltaBajaConsultaListas.ListaIndumentariaDisponible<Zapatilla>().Count == 0)
            {
                MessageBox.Show("No se encuentran zapatillas disponibles para exportar a XML");
                return;
            }

            string nombreArchivo = "\\FabricaDisponibleZapatillas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                LeerGuardarXML.GuardarDocumento<Zapatilla>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);

            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }
        }

        private void documentosDisponiblesSoloCAMISETASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AltaBajaConsultaListas.ListaIndumentariaDisponible<Camiseta>().Count == 0)
            {
                MessageBox.Show("No se encuentran camisetas disponibles para exportar a XML");
                return;
            }

            string nombreArchivo = "\\IndumentariaDisponibleCamisetas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                LeerGuardarXML.GuardarDocumento<Camiseta>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }
        }
        #endregion

        #region Funciones de Limpieza
        /// <summary>
        /// Limpia las casillas con el detalles de la indumentaria manufacturada seleccionada
        /// </summary>
        private void limpiarCasillerosInduManufacturada()
        {
            this.txtTipo.Text = "";
            this.txtCodigo.Text = "";
            this.txtModelo.Text = "";
            this.txtPeso.Text = "";
            this.txtPorcent.Text = "";
            this.txtCosto.Text = "";
            this.txtCostoTanda.Text = "0";
            this.numCantFabricada.Value = 0;
        }

        /// <summary>
        /// Limpia las casillas con el detalles de la indumentaria disponible seleccionada
        /// </summary>
        private void LimpiarCasillerosInduDisponible()
        {
            this.txtTipoDisp.Text = "";
            this.txtCodigoDisp.Text = "";
            this.txtModeloDisp.Text = "";
            this.txtPesoDisp.Text = "";
            this.txtPorcentDisp.Text = "";
            this.txtCostoDisp.Text = "";
        }

        #endregion



        private void exportarIndumentariaDisponibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "\\IndumentariaDisponible" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                LeerGuardarXML.GuardarDocumento<Indumentaria>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error al guardar el archivo " + pathArchivo + error.Message);
            }
        }

        private void exportarXMLManufacturaIndumentariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGenerarDocumento_Click(sender, e);
        }

       

        public void ActulizarListBoxDisponible()
        {
            this.lstBoxInduDisponible.DataSource = AltaBajaConsultaListas.ListaIndumentariaDisponible<Indumentaria>();
        }
    }
}
