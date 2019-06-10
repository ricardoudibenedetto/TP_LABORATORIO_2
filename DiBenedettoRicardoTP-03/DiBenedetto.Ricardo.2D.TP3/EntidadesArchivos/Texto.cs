using EntidadesExcepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesArchivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter wtr = new StreamWriter(archivo);
                wtr.WriteLine(datos);
                wtr.Close();
                return true;

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader rdr = new StreamReader(archivo);
                datos = rdr.ReadToEnd();
                rdr.Close();
                return true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
        }
    }
}
