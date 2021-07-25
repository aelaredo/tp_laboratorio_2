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
        public event EventHandler<IndumentariaEventArgs> FabricandoIndumentaria;
        public event DelegadoIndumentaria AvisarCreacion;
        public ListBox listadoDisponibles;
        private int progreso;

        public FrmCrearIndumentaria(ListBox listaDisponibles)
        {
            InitializeComponent();
            this.progreso = 0;
            this.listadoDisponibles = listaDisponibles;
            FabricandoIndumentaria += AltaBajaConsultaListas.AgregarIndumentariaDisponible;
            FabricandoIndumentaria += LeerGuardarBaseDatos.GuardarDisponibleEnDB;
            AvisarCreacion += MostrarMensajeCreacion;
        }

        public void MostrarMensajeCreacion (Indumentaria zapatillaNueva)
        {
            MessageBox.Show($"La indumentaria {zapatillaNueva.ToString()} se ha diseñado con exito");

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
                //si el flujo de aplicacion entra aqui desde un thread secundario debemos invocarlo nuevamente desde el thread primario apra que modifique el form
                DelegadoActualizarForm actualizarBarra = new DelegadoActualizarForm(ActualizarBarraProgreso);
                this.Invoke(actualizarBarra);
            }
            else
            {
                //actualizo la barar de progreso de mi form
                this.pbCreacion.Value = this.progreso;
                if(this.pbCreacion.Value == 100)
                {
                        //Una vez llena la barra de progreso, reseteamos el contador y limpiamos la barra
                        this.progreso = 0;
                        this.pbCreacion.Value = this.progreso;
                }
                else
                {
                    //avanzamos +1 el progreso
                    this.progreso++;
                }
            }
        }
        private void AvanzarBarra(Indumentaria zapatillaNueva)
        {
            for (int i = 0; i < 101; i++)
            {
                //cada 50 ms actualizo mi bara de progreso uno mas
                this.ActualizarBarraProgreso();
                Thread.Sleep(50);
            }
            // una vez que llenamos la barra de progreso avisamos que ya se creó la indumentaria que pasamos por parametro
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
