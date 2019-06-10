using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Universitario : Persona
    {
        #region atributos
        private int legajo;

        #endregion
        #region metodos
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// constructor con cinco parametros
        /// </summary>
        /// <param name="legajo">legajo a asignar </param>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="dni">dni a asignar</param>
        /// <param name="nacionalidad">nacionalidad a asignar</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido,dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// metodo abstracto a implementar en clases heredadas
        /// </summary>
        /// <returns>string con los datos de la clase donde participa</returns>
        protected abstract string ParticipaEnClases();
        /// <summary>
        /// muestra los datos del universitario
        /// </summary>
        /// <returns>stting con los datos del universitaro</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"LEGAJO: {this.legajo}");
            return sb.ToString();
        }
        /// <summary>
        /// un universitario sera iugal a otro si son del mismo tipo y comparten legajo o dni
        /// </summary>
        /// <param name="pg1">universitario a comparar</param>
        /// <param name="pg2">universitaio a comparar</param>
        /// <returns>true si se cumple la cpondicion de igualdad</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            return (pg1 is Universitario && pg2 is Universitario) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// dos universitarios seran distintos si no tienen el mismo tipo o no comparten dni o legajo
        /// </summary>
        /// <param name="pg1">universuitario a comparar</param>
        /// <param name="pg2">universitario a comparar</param>
        /// <returns>true si son distintos</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// sobrecarga equals utilizando el == de unviersitario
        /// </summary>
        /// <param name="obj">objeto a comparar </param>
        /// <returns>true si son iguales</returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
        #endregion

    }
}
