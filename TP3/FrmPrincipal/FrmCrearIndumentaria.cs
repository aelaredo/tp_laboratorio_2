using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Objetos;
using Logica.BaseDeDatos;
using Logica.Documentos;
using Logica.Listas;
using Logica.Interfaces;

namespace FrmPrincipal
{
    public delegate void DelegadoIndumentaria(Indumentaria indu);
    public delegate void DelegadoActualizarForm();
    public partial class FrmCrearIndumentaria : Form
    {

        //List<Indumentaria> indumentariasDisponibles;
        //public event Comunicarse avisarCreacion;
        public event EventHandler<IndumentariaEventArgs> FabricandoIndumentaria;
        public event DelegadoIndumentaria AvisarCreacion;
        //public event DelegadoVacio eventoSinParams;
        public ListBox listadoDisponibles;
        int progreso;
        public FrmCrearIndumentaria(ListBox listaDisponibles)
        {
            InitializeComponent();
            this.progreso = 0;
            this.listadoDisponibles = listaDisponibles;
            //avisarCreacion = btnNuevaIndumentaria_Click;
            //avisarCreacion += FrmPrincipal.comunicarseConForm;
            //FrmPrincipal.comunicarseConForm += avisarCreacion;
            FabricandoIndumentaria += AltaBajaConsultaListas.AgregarIndumentariaDisponible;
            FabricandoIndumentaria += LeerGuardarBaseDatos.GuardarDisponibleEnDB;
            //FabricandoIndumentaria += FrmPrincipal.ActualizarListBoxDisponible;
            AvisarCreacion += MostrarMensajeCreacion;
            //ActualizarListBox += FrmPrincipal.ActualizarListBoxDisponible;
        }

        public void MostrarMensajeCreacion (Indumentaria zapatillaNueva)
        {
            MessageBox.Show($"La indumentaria {zapatillaNueva.ToString()} se ha fabricado con exito");

        }

        private void rdbCamiseta_CheckedChanged(object sender, EventArgs e)
        {
            this.lblCapellada.Visible = false;
            this.cmbCapellada.Visible = false;
            this.cmbSuela.Visible = false;
            this.lblSuela.Visible = false;
            this.lblPorcent.Visible = true;
            this.numPorcent.Visible = true;
            this.rdbEstampado.Visible = true;
            this.rdbNoEstampada.Visible = true;
            this.rdbNoEstampada.Checked = true;
            this.lblModelo.Visible = true;
            this.txtModelo.Visible = true;

        }

        private void rdbZapatilla_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCapellada.Visible = true;
            this.lblCapellada.Visible = true;
            this.cmbSuela.Visible = true;
            this.lblSuela.Visible = true;
            this.lblPorcent.Visible = false;
            this.numPorcent.Visible = false;
            this.rdbEstampado.Visible = false;
            this.rdbNoEstampada.Visible = false;
            this.lblModelo.Visible = false;
            this.txtModelo.Visible = false;

        }

        private void FrmCrearIndumentaria_Load(object sender, EventArgs e)
        {
            this.rdbCamiseta.Checked = true;
            this.cmbSuela.DataSource = Enum.GetValues(typeof(ESuelas));
            this.cmbCapellada.DataSource = Enum.GetValues(typeof(ECapelladas));
            this.cmbSuela.SelectedIndex = 0;
            this.cmbCapellada.SelectedIndex = 0;
        }

        private void ActualizarBarraProgreso ()
        {
            if (this.pbCreacion.InvokeRequired)
            {
                DelegadoActualizarForm actualizarBarra = new DelegadoActualizarForm(ActualizarBarraProgreso);
                this.Invoke(actualizarBarra);
            }
            else
            {
                this.pbCreacion.Value = this.progreso;
                if(this.pbCreacion.Value == 100)
                {
                        this.progreso = 0;
                        this.pbCreacion.Value = this.progreso;
                }
                else
                {
                    this.progreso++;
                }
            }
            
        }

        private void AvanzarBarra(Indumentaria zapatillaNueva)
        {
            for (int i = 0; i < 101; i++)
            {
                this.ActualizarBarraProgreso();
                Thread.Sleep(50);
            }
            this.AvisarCreacion.Invoke(zapatillaNueva);
        }

        private void btnNuevaIndumentaria_Click(object sender, EventArgs e)
        {
            if (this.rdbZapatilla.Checked  )
            {
                Zapatilla zapatillaNueva = new Zapatilla(((ECapelladas)this.cmbCapellada.SelectedItem), (ESuelas)this.cmbSuela.SelectedItem);
                try
                {

                    this.FabricandoIndumentaria.Invoke(this, new IndumentariaEventArgs(zapatillaNueva));

                    Task MostrarProgreso = new Task(() => 
                    {
                        AvanzarBarra(zapatillaNueva);
                    });

                    MostrarProgreso.Start();
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else if (this.rdbCamiseta.Checked && !string.IsNullOrEmpty(this.txtModelo.Text))
            {
                Camiseta camisetaNueva = new Camiseta((float)numPorcent.Value, (this.rdbEstampado.Checked ? true : false), this.txtModelo.Text);
                try
                {

                    this.FabricandoIndumentaria.Invoke(this, new IndumentariaEventArgs(camisetaNueva));

                    Task MostrarProgreso = new Task(() =>
                    {
                        AvanzarBarra(camisetaNueva);
                    });

                    MostrarProgreso.Start();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message+error.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre para el modelo");
            }
            this.limpiarCasilleros();
        }

        private void limpiarCasilleros()
        {
            this.cmbCapellada.Text = "";
            this.cmbSuela.Text = "";
            this.numPorcent.Text = "";
            this.txtModelo.Text = "";

        }
    }
}
