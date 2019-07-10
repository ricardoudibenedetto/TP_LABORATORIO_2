using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Metodo de extencion que nos permite guardar un archivo de texto en el escritorio.
        /// </summary>
        /// <param name="texto">string a guardar en el archivo</param>
        /// <param name="archivo">nombre del archivo donde se va a guardar el texto</param>
        /// <returns>ture si pudo crear el archivo false si hubo algun problema</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\{archivo}.txt ";
            try
            {
                StreamWriter wtr = new StreamWriter(path,true);
                wtr.WriteLine(texto);
                wtr.Close();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            

        }
    }
}
