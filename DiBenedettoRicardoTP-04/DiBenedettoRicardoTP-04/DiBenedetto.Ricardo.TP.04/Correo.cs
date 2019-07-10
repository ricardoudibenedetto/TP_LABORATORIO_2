using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// propiedad de lectura y escritura tipo List<paquete>
        /// </summary>
        public List<Paquete> Paquetes
        {
            get => this.paquetes;
            set => this.paquetes = value;
        }

        /// <summary>
        /// constructor de Correo
        /// sin parametros, se encarga de inicializar las listas de paquetes e hilos
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// metodo que se encargara de abortar todos los hilos generados
        /// </summary>
        public void FinEntrega()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// muestra los datos de todos los paquietes 
        /// con el formato TrakingId DireccionEntrega Estado
        /// </summary>
        /// <param name="elemento">elemento del cual se mostraran los paquetes tipo Imostrar<list<paquete>> </paquete></param>
        /// <returns>string con los datos de todos los elementos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elemento).paquetes)
            {
                sb.AppendLine(String.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// sobrecatrga del operado + encargado de agregar un paquete a un correo
        /// si el mismo no se encuentra ya cargado.
        /// crea un hilo para poder cargar multiples paquetes al mismo tiempo mientras se simula el cilo.
        /// </summary>
        /// <param name="c">Correo al cual se le va a agregar el paquete</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>retorna el correo cargado si lo pudo cargar, sino lanza una excepcion</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool isContained = false;

            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                    isContained = true;
            }
            if (!isContained)
            {
                c.paquetes.Add(p);
                Thread h = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(h);
                h.Start();
                return c;
            }
            else
            {
                throw new TrackingIdRepetidoException("el paquete ya existe");
            }


        }
    }
}
