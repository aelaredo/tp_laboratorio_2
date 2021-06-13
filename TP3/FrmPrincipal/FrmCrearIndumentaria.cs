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

namespace FrmPrincipal
{
    public partial class FrmCrearIndumentaria : Form
    {

        //List<Indumentaria> indumentariasDisponibles;
        public FrmCrearIndumentaria()
        {
            InitializeComponent();

            
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

        private void btnNuevaIndumentaria_Click(object sender, EventArgs e)
        {
            if (this.rdbZapatilla.Checked)
            {

                Zapatilla zapatillaNueva = new Zapatilla(((ECapelladas)this.cmbCapellada.SelectedItem), (ESuelas)this.cmbSuela.SelectedItem);
                try
                {
                    Fabrica.agregarADisponible(zapatillaNueva);
                    MessageBox.Show("Se ha agregado correctamente la "+ zapatillaNueva.ToString());
                }catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                Camiseta camisetaNueva = new Camiseta((float)numPorcent.Value, (this.rdbEstampado.Checked ? true : false), this.txtModelo.Text);
                try
                {
                    Fabrica.agregarADisponible(camisetaNueva);
                    MessageBox.Show("Se ha agregado correctamente la " + camisetaNueva.ToString());
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }


        }

    }
}
