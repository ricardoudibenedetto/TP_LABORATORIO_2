using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Profesor : Universitario
    {
        #region atributos
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        #endregion
        #region metodos
        /// <summary>
        /// constructr estatico que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// contructor por defecto
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// constructor de cinco parametros encargado de pasarle los datos a universitario
        /// </summary>
        /// <param name="id">id a asignar al profesor</param>
        /// <param name="nombre">nombre a asgnar al profesor</param>
        /// <param name="apellido">apellido a asignar al profesor</param>
        /// <param name="dni">dni a asignar al profesor</param>
        /// <param name="nacionalidad">nacionalidad a asignar al profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        /// <summary>
        /// encargado de generar una clase random y asignarle a un profesor
        /// </summary>
        private void _randomClases()
        {
            int valor = random.Next(0, 3);
            this.claseDelDia.Enqueue((Universidad.EClases)valor);
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// muestra las clases en las cuales participa el profesor
        /// </summary>
        /// <returns>un string con las clases donde participa el profesor</returns>
        protected override string ParticipaEnClases()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            while (claseDelDia.Count > 0)
            {
                sb.AppendLine(this.claseDelDia.Dequeue().ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// muestra todos los datos del profesor
        /// </summary>
        /// <returns>string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticipaEnClases());
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de tostring
        /// </summary>
        /// <returns>retorna los datos del profesor</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// un profesor sera igual a una clase si participa de la clase
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clases">clase a comparar</param>
        /// <returns>true si participa de la clase</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clases)
        {
            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clases)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// un profesor sera distinto a una clase si no participa de ella
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clases">clase a comparar</param>
        /// <returns>true si un profesor no participa de la clase</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clases)
        {
            return !(i == clases);
        }
        #endregion

    }
}
