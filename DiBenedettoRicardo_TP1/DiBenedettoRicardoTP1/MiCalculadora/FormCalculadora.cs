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
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.lblResultado.Text = " ";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero((this.txtNumero1.Text).Replace('.',','));
            Numero numero2 = new Numero((this.txtNumero2.Text).Replace('.',','));
            double resultado = Calculadora.Operar(numero1, numero2, this.cmbOperador.Text);
           if( resultado == double.MinValue)
            {
                this.lblResultado.Text = "Error\nno se puede dividir por 0";

            }
           else
            {
                this.lblResultado.Text = resultado.ToString();

            }
            
            
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = " ";
            this.cmbOperador.Text= " ";
        }
    }
}
