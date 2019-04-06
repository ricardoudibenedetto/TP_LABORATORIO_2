using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Valida que el operador ingresado sea +,-,/ o * 
        /// </summary>
        /// <param name="operador">Parametro string a validar</param>
        /// <returns>si el operador es correcto lo retorna, caso contrario retornara + </returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    return operador;

                default:
                    return "+";
            }
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        #endregion
    }
}
