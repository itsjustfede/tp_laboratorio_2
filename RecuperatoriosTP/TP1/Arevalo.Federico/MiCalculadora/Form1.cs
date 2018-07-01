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
    public partial class Form1 : Form
    {
        Calculadora calculadora = new Calculadora();
        Numero numero = new Numero();

        public Form1()
        {
            InitializeComponent();
            this.cmbOperador.SelectedItem = "+";
        }

        private void btnConvertirBinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = this.numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text != "" && this.txtNumero2.Text != "" && this.cmbOperador.SelectedItem != null)
            {
            Numero num1 = new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text); 

            this.lblResultado.Text = this.calculadora.Operar(num1, num2, this.cmbOperador.SelectedItem.ToString()).ToString();
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }

        private void brnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = this.numero.BinarioDecimal(this.lblResultado.Text);
        }
    }
}
