using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro?",
                "Confirmacioan de cerrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

       /// <summary>
       /// Setea valores 0 por default y + en comboBox de operador para que no falle
       /// </summary>
        private void Limpiar ()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            this.cmbOperador.Text = "+";
        }
        /// <summary>
        /// A apartir de los string de los numeros y el operador devuelve el double de la operacion
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private double Operar (string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
    }
}
