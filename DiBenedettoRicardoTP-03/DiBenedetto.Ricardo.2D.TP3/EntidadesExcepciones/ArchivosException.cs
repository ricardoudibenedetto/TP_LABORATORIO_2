using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException):base("Error al guardar el archivo",innerException)
        {

        }
    }
}
