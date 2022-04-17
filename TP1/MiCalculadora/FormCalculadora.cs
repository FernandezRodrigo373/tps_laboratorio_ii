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
        /// <summary>
        /// asigna los operandos como items del cmboperador
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();

            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
        }

        /// <summary>
        /// limpia la pantalla y vacia lo que muestra la calculadora
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = -1;
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// llama a la funcion limpiar mediante un boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inicia el form con los campos vacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// llama a la funcion operar, valida si los datos de ingreso son erroneos y les da un valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoFinal;
            string resultadoString;
            string operador;


            if (this.txtNumero1.Text == "")
            {
                this.txtNumero1.Text = "0";
            } 
            
            if (this.txtNumero2.Text == "")
            {
                this.txtNumero2.Text = "0";
            }

            operador = this.cmbOperador.Text;

            if (string.IsNullOrEmpty(operador))
            {
                operador = "+";
            }

            resultadoFinal = Operar(this.txtNumero1.Text, this.txtNumero2.Text, operador);

            if(resultadoFinal == double.MinValue)
            {
                this.lblResultado.Text = "IMPOSIBLE DIVIDIR POR 0";
            }
            else
            {
                resultadoString = resultadoFinal.ToString();

                this.lblResultado.Text = resultadoString;

                this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {operador} {this.txtNumero2.Text} = {resultadoString}");
            }


        }

        /// <summary>
        /// realiza las operaciones matematicas llamando a la funcion operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando primerNum = new Operando();
            Operando segundoNum = new Operando();

            char operadorChar;

            primerNum.Numero = numero1;
            segundoNum.Numero = numero2;

            operadorChar = char.Parse(operador);

            return Calculadora.Operar(primerNum, segundoNum, operadorChar);
        }

        /// <summary>
        /// llama a la funcion que convierte el resultado de la operacion de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();

            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
            //this.lstOperaciones.Text = this.lblResultado.Text;
        }

        /// <summary>
        /// llama a la funcion que convierte el resultado de la operacion de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
               // this.lstOperaciones.Text = Operando.DecimalBinario(this.lblResultado.Text);
            }
        }

        /// <summary>
        /// realiza una pregunta al usuario para saber si desea salir del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Salir de la calculadora?", "Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }
}
