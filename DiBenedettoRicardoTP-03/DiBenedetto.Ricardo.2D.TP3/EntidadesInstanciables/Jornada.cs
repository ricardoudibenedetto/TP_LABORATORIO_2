using EntidadesAbstractas;
using EntidadesArchivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region metodos
        /// <summary>
        /// consttuctor por defecto encargado de inicializae la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// constructor con dos parametros llama al constructor por defecto para inicializar la lista de alumnos
        /// </summary>
        /// <param name="clase">clase a asignarle a la jornada</param>
        /// <param name="instructor">profesor que dara la clase en la jornada</param>
        public Jornada(Universidad.EClases clase , Profesor instructor)
            :this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }
        /// <summary>
        /// propiedad que retorna y asigna una lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// propiedad de lectura y escritura del atribto clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// propiedad de lectrua y escritura ´para el atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// una jornada sera igual a un alumno si el mismo participa de la jornada
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno esta en la jornada</returns>
        public static bool operator == ( Jornada j , Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// una jornada sera distinto a un alumno si el mismo no participa de la jornada
        /// </summary>
        /// <param name="j">jornada a comparr</param>
        /// <param name="a">alumno acomparar</param>
        /// <returns>returna true si el alumno participa de la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// sobrecarga de adicion, agrega un alumno a una jornada si el mismo no participa de la jornada
        /// </summary>
        /// <param name="j">jornada a la que se le va a asignar el alumno</param>
        /// <param name="a">alumno a agregar a la jornada</param>
        /// <returns>retorna la jornada con el alumno agregado si corresponde, sino retorna la jornada inicial</returns>
        public static Jornada operator +(Jornada j , Alumno a )
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// sobrecarga del tostring retorna toda la informacion de la jornada
        /// </summary>
        /// <returns>string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CLASE DE {this.clase.ToString()} POR ");
            sb.Append(instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<----------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// guarda los datos de una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            if (txt.Guardar(".//jornada.txt", jornada.ToString()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// lee los datos de una jornada
        /// </summary>
        /// <returns>string con la informacion de una jornada de un archivo de texto</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            txt.Leer(".//jornada.txt", out string archivo);
            return archivo;
        }
        #endregion

    }
}
