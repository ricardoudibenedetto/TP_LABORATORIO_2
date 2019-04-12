using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributo
        private double numero;
        #endregion

        #region Metodos
        /// <summary>
        /// contructor sin parametro que asigna 0 al atributo en el caso de ser invocado
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Contructor , recibe un string y se lo asigna a SetNumero
        /// </summary>
        /// <param name="strNumero">String a guardar </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Contructor, llama al constructor string y le asigna el double recibido
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Asigna valor al atributo numero 
        /// valida el numero a asignar
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el parametro ingresado sea numerico,
        /// si el parametro no es numerico se le asigna el valor 0
        /// </summary>
        /// <param name="strNumero">Va a ser transformado a double</param>
        /// <returns>retorna el parametro en formato double</returns>
        private double ValidarNumero(string strNumero)
        {
            double numeroValidado = 0;

            if (double.TryParse(strNumero, out numeroValidado))
            {
                return numeroValidado;
            }

            return numeroValidado;
        }

        /// <summary>
        /// Convierte un Binario a un Decimal
        /// </summary>
        /// <param name="binario">Numero a convertir en Decimal</param>
        /// <returns>Retorna un string con el Decimal convertido, si no es posible se retornara Valor Invalido</returns>
        public string BinarioDecimal(string binario)
        {
            int multiplicador = 1;
            int resultado = 0;
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] == '1')
                {
                    resultado += multiplicador;
                }
                else if (!(binario[i] == '0'))
                {
                    return "¡Valor inválido!";
                }
                multiplicador *= 2;
            }
            return resultado.ToString();
        }


        /// <summary>
        /// Convierte un Decimal a binario
        /// </summary>
        /// <param name="numero">Numero que va a ser convertido a Binario</param>
        /// <returns>retorna un string con el numero convertido</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int entero = (int)Math.Abs(numero);
            while (entero > 0)
            {
                binario = (entero % 2).ToString() + binario;
                entero = entero / 2;
            }
            return binario;
        }

        /// <summary>
        /// Convierte un Decimal string a un Binario
        /// </summary>
        /// <param name="strNumero">string que va a ser convertido a Binario</param>
        /// <returns>retornara el valor convertido, caso contrario retorna mensaje de erro</returns>
        public string DecimalBinario(string strNumero)
        {
            // desarrollar codigo aca
            int numeroTryParse;
            if (int.TryParse(strNumero, out numeroTryParse))
                return DecimalBinario(numeroTryParse);
            else
                return "¡Valor inválido!";
        }

        /// <summary>
        /// Suma dos objetos Numero
        /// </summary>
        /// <param name="n1">Numero a sumar</param>
        /// <param name="n2">Numero a sumar</param>
        /// <returns>Resultado de la suma en forma de double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero a restar</param>
        /// <param name="n2">Objeto Numero a restar</param>
        /// <returns>Resultado de la resta en forma de double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos objetos Numero
        /// </summary>
        /// <param name="n1">Objeto numero a multiplicar</param>
        /// <param name="n2">Objeto Numero a multiplicar</param>
        /// <returns>Resultado de la multiplicacion en forma de double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos objetos Numero 
        /// </summary>
        /// <param name="n1">Objeto numero a dividir</param>
        /// <param name="n2">Objeto numero divisor</param>
        /// <returns>Retorna la division en forma de double , en el caso de tener una division por cero retornara double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion
    }
}
