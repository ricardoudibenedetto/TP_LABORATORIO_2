using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
  public class NacionalidadInvalidaException : Exception
  {
    public NacionalidadInvalidaException()
      :this("Nacionalidad invalida")
    {

    }
    public NacionalidadInvalidaException(string message )
      :base(message)
    {

    }

  }
}
