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
using IndumentariasExceptions;
using System.IO;
using System.Text.RegularExpressions;

namespace FrmPrincipal
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Al cargar la aplicacion se busca en la carpeta que se indique cual es el ultimo archivo de indumentaruia disponible y ya se carga la lista con esto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

            string[] files = Directory.GetFiles((Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), "IndumentariaDisponible?????????????????.xml");

            if (files.Length == 0)
            {
                this.lstBoxInduManufacturada.DataSource = Fabrica.ListaIndumentariaProduccion<Indumentaria>();
            }
            else
            {
                DocumentosFabrica.LeerDocumento(files[files.Length - 1], out Fabrica.indumentariaDisponible);
                this.lstBoxInduDisponible.DataSource = Fabrica.ListaIndumentariaDisponible<Indumentaria>();
                this.lstBoxInduManufacturada.DataSource = Fabrica.ListaIndumentariaProduccion<Indumentaria>();
            }
            
        }
        /// <summary>
        /// Si en este metodo el path es incorrecto y falla el guardado de la lista disponible por esto, el metodo DocumentosFabrica.GuardarDocumento generara una excepcion  que sera catcheada y mostrada, junto con la informacion del path que se genero en esta misma funcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string nombreArchivo = "\\IndumentariaDisponible" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                DocumentosFabrica.GuardarDocumento<Indumentaria>(pathArchivo);
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error al guardar el archivo " + pathArchivo + error.Message);
            }

        }

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
        private void lstBoxInduManufacturada_SelectedValueChanged(object sender, EventArgs e)
        {
            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduManufacturada.SelectedItem;

            this.txtTipo.Text = seleccionada.GetType().ToString().Replace("TP3.", "");
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

        private void lstBoxInduDisponible_SelectedValueChanged(object sender, EventArgs e)
        {
            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;

            this.txtTipoDisp.Text = seleccionada.GetType().ToString().Replace("TP3.", "");

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

            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                MessageBox.Show("No hay indumentarias disponibles para ser manufacturadas");
                return;
            }

            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;

            try
            {
                seleccionada.Fabricar();
                this.lstBoxInduManufacturada.DataSource = Fabrica.ListaIndumentariaProduccion<Indumentaria>();
                this.lstBoxInduManufacturada.SelectedItem = seleccionada;
            }
            catch (Exception error)
            {
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
                DocumentosFabrica.GuardarDocumento<Indumentaria>(pathArchivo);
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

            if (seleccionada.CantidadManufacturada > 1)
            {
                seleccionada.CantidadManufacturada--;
            }
            else
            {
                Fabrica.indumentariaProduccion.Remove(seleccionada);
            }

            this.lstBoxInduManufacturada.DataSource = Fabrica.ListaIndumentariaProduccion<Indumentaria>();

            if (this.lstBoxInduManufacturada.Items.Count == 0)
            {
                this.limpiarCasillerosInduManufacturada();
            }

        }
        private void btnAgregarNuevaIndu_Click(object sender, EventArgs e)
        {
            FrmCrearIndumentaria ventanaCrearIndumentaria = new FrmCrearIndumentaria();
            ventanaCrearIndumentaria.ShowDialog();
            this.lstBoxInduDisponible.DataSource = Fabrica.ListaIndumentariaDisponible<Indumentaria >();
        }
        private void btnBorrarDisp_Click(object sender, EventArgs e)
        {
            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                MessageBox.Show("No se encuentran indumentarias disponibles para ser borradas");
                return;
            }

            Indumentaria seleccionada = (Indumentaria)this.lstBoxInduDisponible.SelectedItem;

            if (!Fabrica.indumentariaDisponible.Remove(seleccionada))
            {
                MessageBox.Show("No se encontro la indumentaria para ser borrado");
                return;
            }

            this.lstBoxInduDisponible.DataSource = Fabrica.ListaIndumentariaDisponible<Indumentaria>();

            if (this.lstBoxInduDisponible.Items.Count == 0)
            {
                this.limpiarCasillerosInduDisponible();
            }
        }
        #endregion

        #region Eventos ToolStrip
        private void generarDocumentoDeManufacturaSoloCAMISTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fabrica.ListaIndumentariaProduccion<Camiseta>().Count == 0)
            {
                MessageBox.Show("No se encuentran camisetas para ser manufacturadas");
                return;
            }

            string nombreArchivo = "\\FabricaProduccionCamisetas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";

            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                DocumentosFabrica.GuardarDocumento<Camiseta>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }

            
        }

        private void generarDocManufacturaSoloZAPATILLASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fabrica.ListaIndumentariaProduccion<Zapatilla>().Count == 0)
            {
                MessageBox.Show("No se encuentran zapatillas para ser manufacturadas");
                return;
            }

            string nombreArchivo = "\\FabricaProduccionZapatillas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                DocumentosFabrica.GuardarDocumento<Zapatilla>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);
            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }

        }

        private void documentosDisponiblesSoloZAPATILLASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fabrica.ListaIndumentariaDisponible<Zapatilla>().Count == 0)
            {
                MessageBox.Show("No se encuentran zapatillas poner a disponibilidad");
                return;
            }

            string nombreArchivo = "\\FabricaDisponibleZapatillas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                DocumentosFabrica.GuardarDocumento<Zapatilla>(pathArchivo);
                MessageBox.Show("El archivo se ha guardado correctamente en " + pathArchivo);

            }
            catch (IndumentariasExceptionsErrorAlGenerarArchivo error)
            {
                MessageBox.Show("Hubo un error al generar el archivo " + nombreArchivo + error.Message);
            }
        }

        private void documentosDisponiblesSoloCAMISETASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fabrica.ListaIndumentariaDisponible<Camiseta>().Count == 0)
            {
                MessageBox.Show("No se encuentran camisetas poner a disponibilidad");
                return;
            }

            string nombreArchivo = "\\IndumentariaDisponibleCamisetas " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".xml";


            string pathArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nombreArchivo;

            try
            {
                DocumentosFabrica.GuardarDocumento<Camiseta>(pathArchivo);
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
        private void limpiarCasillerosInduDisponible()
        {
            this.txtTipoDisp.Text = "";
            this.txtCodigoDisp.Text = "";
            this.txtModeloDisp.Text = "";
            this.txtPesoDisp.Text = "";
            this.txtPorcentDisp.Text = "";
            this.txtCostoDisp.Text = "";
        }

        #endregion


    }
}
