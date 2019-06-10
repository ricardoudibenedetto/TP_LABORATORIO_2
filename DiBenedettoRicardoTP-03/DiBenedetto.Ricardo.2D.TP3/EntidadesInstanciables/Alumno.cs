
using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {
        #region Enum EEstadoCuenta
        /// <summary>
        /// enumeracion de estado cuentas
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
        #region atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion
        #region Metodos
        /// <summary>
        /// constructor por defecto de alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// constructor de seis atributos
        /// llama al constructor de cinco y le pasan los datos
        /// </summary>
        /// <param name="id">id es el legajo de la alumno</param>
        /// <param name="nombre">Nombre a asginarle al alumno</param>
        /// <param name="apellido">apellido a asignarle al alumno</param>
        /// <param name="dni">dni a asignarle al alumno</param>
        /// <param name="nacionalidad">nacionalidad a asignarle al alumno</param>
        /// <param name="claseQueToma">clase que toma a asignarle al alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {
        }
        /// <summary>
        /// constructor de cinco parameros de alumno
        /// este es el encargado de pasarle los valores de persona mediante base
        /// </summary>
        /// <param name="id">legajo a asginarle a la persona</param>
        /// <param name="nombre">nombre a asignarle al alumno</param>
        /// <param name="apellido">apellido a asginarle a l alumno</param>
        /// <param name="dni">dni a asignarle al laumno</param>
        /// <param name="nacionalidad">nacionalidad a asignarle a alumno</param>
        /// <param name="claseQueToma">clase a asignarle a la persona</param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Indica en que clase participa el alumno
        /// </summary>
        /// <returns>la informacion en forma de string</returns>
        protected override string ParticipaEnClases()
        {
            return $"TOMA CLASES DE {this.claseQueToma}";
        }
        /// <summary>
        /// muestra los datos del alumno
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine($"ESTADO DE CUENTA: Cuota al Día");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine($"ESTADO DE CUENTA: Cuota Deudora");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine($"ESTADO DE CUENTA: Cuota Becada");
                    break;
                default:
                    break;
            }
            sb.AppendLine(this.ParticipaEnClases());
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga del tostring 
        /// </summary>
        /// <returns>retorna los datos del alumno</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// un alumno sera igual a una clase si participa de ella y su estado de cuenta no es deudor
        /// </summary>
        /// <param name="a">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si son iguales </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && !(a.estadoCuenta == EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// un alumno sera distinto a una clase si no participa de la misma
        /// </summary>
        /// <param name="a">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si son distintos</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        #endregion

    }
}
