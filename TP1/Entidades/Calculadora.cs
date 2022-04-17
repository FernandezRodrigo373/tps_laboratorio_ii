using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// valida que el operador recibido sea " + * - / ", si no es ninguno devuelve " + " 
        /// </summary>
        /// <param name="operador"> operador a validar
        /// <returns> operdaor elegido
        private static char ValidarOperador(char operador)
        {
            if (operador != '-' && operador != '/' && operador != '*')
            {
                return '+';
            }
            else
            {
                return operador;
            }
        }


        /// <summary>
        /// realiza las operaciones matematicas con los operandos que recibe
        /// </summary>
        /// <param name="num1"> primer numero ingresado
        /// <param name="num2"> segundo numero ingresado
        /// <param name="operador"></param>
        /// <returns> resultado de la operacion 
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }


    }
    
}
