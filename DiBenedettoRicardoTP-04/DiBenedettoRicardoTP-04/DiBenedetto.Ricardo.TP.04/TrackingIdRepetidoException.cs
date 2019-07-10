using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor para TrakincIDRepetidoException con 1 parametros
        /// </summary>
        /// <param name="mensaje">mensaje que mostrara ka excepction</param>
        public TrackingIdRepetidoException(string mensaje)
            :this(mensaje, null)
        {

        }
       
        /// <summary>
        /// contructor para TrakingIdException con dos parametros
        /// </summary>
        /// <param name="mensaje">Mensaje que va a mostrar la excepcion</param>
        /// <param name="inner">una excepcion que va a manejar su exception padre</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner )
            :base(mensaje, inner)
        {

        }
    }
}
