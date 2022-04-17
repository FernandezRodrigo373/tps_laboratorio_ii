using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// constructor que asigna valor 0
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// contructor que asignar valor recibido
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// valida que se ingrese un numero si no retorna 0
        /// </summary>
        /// <param name="strNumero">numero ingresado
        /// <returns> retorna el numero final 
        private double ValidarOperando(string strNumero)
        {
            double numeroFinal;

            bool resultado = double.TryParse(strNumero, out numeroFinal);

            if (resultado == false)
            {
                numeroFinal = 0;
            }

            return numeroFinal;
        }

        public Operando(string strNumero)
        {
            this.numero = ValidarOperando(strNumero);
        }

        /// <summary>
        /// setea el numero validado al campo numero 
        /// </summary>
        public string Numero
        {
            set
            { 
                this.numero = ValidarOperando(value); 
            }
        }

        /// <summary>
        /// verifica que el numero sea binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> retorna false si es distinto a 1 y a 0
        private bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// sobrecarga el operador de suma para la clase operando
        /// </summary>
        /// <param name="n1"> primer numero ingresado
        /// <param name="n2"> segundo numero ingresado
        /// <returns> el resultado
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// sobrecarga el operador de multiplicacion para la clase operando
        /// </summary>
        /// <param name="n1"> primer numero ingresado
        /// <param name="n2"> segundo numero ingresado
        /// <returns> el resultado
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// sobrecarga el operador de resta para la clase operando 
        /// </summary>
        /// <param name="n1"> primer numero ingresado
        /// <param name="n2"> segundo numero ingresado
        /// <returns> el resultado
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// sobrecarga el operador de division para la clase operando
        /// </summary>
        /// <param name="n1"> primer numero ingresado
        /// <param name="n2"> segundo numero ingresado
        /// <returns> el resultado
        public static double operator / (Operando n1, Operando n2)
        {
            if(n2.numero != 0 )
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
            
        }

        /// <summary>
        /// convierte un numero binario a decimal siempre que se trate de un binario
        /// </summary>
        /// <param name="binario"> numero(string) binario a convertir
        /// <returns> numero convertido como cadena o "valor invalido" si el resultado no es un binario
        public string BinarioDecimal(string binario)
        {
            double doubleDecimal = 0;

            int caracteres = binario.Length;
           
            if (EsBinario(binario) == true)
            {
                foreach (char i in binario)
                {
                    caracteres--;

                    if (i == '1')
                    {
                        doubleDecimal += Math.Pow(2, caracteres);
                    }
                }
                return doubleDecimal.ToString();
            }
            else
            {
                return "Valor Inválido";
            }
           
        }

        /// <summary>
        /// convierte de decimal a binario siemppre q pueda y lo devuelve como double
        /// </summary>
        /// <param name="numero"> numero a convertir
        /// <returns> el numero en binario o "valor invalido" si el resultado no es decimal 
        public static string DecimalBinario(double numero)
        {
            string numBinario = "";

            int resultado = (int)Math.Round(numero);

            int resto;

            if (resultado >= 0)
            {
                while(resultado > 0)
                {
                    resto = resultado % 2;

                    resultado /= 2;

                    numBinario = resto.ToString() + numBinario;
                }

                return numBinario;
            }
            else
            {
                return "Valor Inválido";
            }

        }

        /// <summary>
        /// convierte de decimal a binario siemppre q pueda llamando a la funcion de igual nombre pero q recibe un numero y devuelve un string
        /// </summary>
        /// <param name="numero"> numero(string) a convertir 
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            double convertirNumero;

            double.TryParse(numero, out convertirNumero);

            return DecimalBinario(convertirNumero);
        }
    }
}
