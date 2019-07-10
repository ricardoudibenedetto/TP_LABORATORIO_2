using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado(object sender, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformarEstado;
        /// <summary>
        /// propiedad de lectura y escritura de direccion entrega tipo string
        /// </summary>
        public string DireccionEntrega
        {
            get => this.direccionEntrega;
            set => this.direccionEntrega = value;
        }
        /// <summary>
        ///propiedad de lectura y escritura de estado tipo EEstado
        /// </summary>
        public EEstado Estado
        {
            get => this.estado;
            set => this.estado = value;
        }
        /// <summary>
        /// propiedad de lectura y escritura TrackingId tipo string
        /// </summary>
        public string TrackingID
        {
            get => this.trackingID;
            set => this.trackingID = value;
        }

        /// <summary>
        /// Constructor Paquete con dos parametros, asigna los valores a sus atributos
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega tipo string</param>
        /// <param name="trackingID">Tracking id tipo string</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        /// <summary>
        /// actualiza todos los estados hasta que sean entregados
        ///  duerme el hilo 4s para simular 
        ///  si puede conectarse con la base de datos insera el paquete, sino lanza una excepcion. 
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);
                this.estado++;
                this.InformarEstado.Invoke(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw new Exception("no se puede conectar a la base de datos", e);
            }
        }

        /// <summary>
        /// muestra los datos de un paquete, trackingId, direccion
        /// </summary>
        /// <param name="elemento">elemento de tipo IMostrar<Paquete> del cual se v a mostrar la informacon </param>
        /// <returns>un string con los datos del elemento a mostrar</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// sobrecarga del operador == entre dos paquetes.
        /// </summary>
        /// <param name="p1"> Paquete a comparar</param>
        /// <param name="p2"> Paqiete a comparar</param>
        /// <returns>retorna true si tienen el mismo traking id</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del operador != entre dos paquetes
        /// </summary>
        /// <param name="p1">paquete a comparar</param>
        /// <param name="p2">paquete a comparar</param>
        /// <returns>retorna true si los paquetes tienen distinto trackingID</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// sobrecarga de tostring retorna la informacion de un paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
    }
}
