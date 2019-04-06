using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(Calculadora.Operar(new Numero(2), new Numero("2"),"+"));

            Console.WriteLine(Calculadora.Operar(new Numero(2), new Numero(2), "-"));

            Console.WriteLine(Calculadora.Operar(new Numero(2), new Numero(2), "/"));

            Console.WriteLine(Calculadora.Operar(new Numero(2), new Numero(2), "*"));

            Console.WriteLine(Calculadora.Operar(new Numero(2), new Numero(), "/")==Double.MinValue?"error divide by 0": Calculadora.Operar(new Numero(2), new Numero(), "/").ToString());
            Console.ReadKey();
               
        }
    }
}
