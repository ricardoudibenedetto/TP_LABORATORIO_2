using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesArchivos;
using EntidadesExcepciones;
namespace EntidadesInstanciables
{
    [Serializable]
    public class Universidad
    {
        #region enum EClases
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
        #region atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesors;
        #endregion
        #region propiedades
        /// <summary>
        /// priopiedad de lectrura y escritura para la lista de alumnos
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
        /// propiedad de lectrua y escritura para la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesors;
            }
            set
            {
                this.profesors = value;
            }
        }
        /// <summary>
        /// propiedad de lectura y escritura para la liosta de jornadas
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// indexador de jornada, lectura y escritura en el indice indicado
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                return this.jornada[index];
            }
            set
            {
                this.jornada[index] = value;
            }
        }
        #endregion
        #region metodos
        /// <summary>
        /// constructor por defecto de la universidad
        /// encargado de inicializar las listas de jornada, alumnos y profesores
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesors = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// una universidad sera igual a un alumno si el mismo participa de ella
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno partiipa en la universidad</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// una universidad sera distinta a un alumno si el muismo no participa de ella
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>turue si el alumno no participa en la universidad</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// una univesidad ssera igual a un profesor si el mismo participa de ella
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="p">profespor a comparar</param>
        /// <returns>true si el profesor participa de ella</returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Profesor item in g.profesors)
            {
                if (item == p)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// un profesor sera distinto a una universidad si no participa de ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// la igualdad entre una universidad y una clase busca el primer profesor disponibe para esa clasee
        /// en caso de no encontrar se lanza la excepcion sinProfesorException
        /// </summary>
        /// <param name="g">univeridad a comparar</param>
        /// <param name="clase">clase que debe dar un profesor</param>
        /// <returns>Profesor disponible para dar la clase solisitada</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesors)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// si una universidad es distinta a la clase debe retornar el primer profesor que no de la clase
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="clase">clase que no debe dar el profesor</param>
        /// <returns>el primer profesor que no da dicha clase, caso de no encontrar se lanza la excepcion sinprofesorException</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesors)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// sobrecarga del operador mas
        /// genera una nueva jornada y se le asigna el profesor para dar la clase solisitada 
        /// luego se le asignan todos los alumnos que tomen esa clase 
        /// se agreja la jornada a la universidad y se retorna 
        /// </summary>
        /// <param name="g">universidad a agregar una hjornada</param>
        /// <param name="clase">clase con la cual se creara una jornada </param>
        /// <returns>la universidad con la nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor instructor = g == clase;
            Jornada jornada = new Jornada(clase, instructor);
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornada += item;
                }
            }
            g.Jornada.Add(jornada);
            return g;
        }
        /// <summary>
        /// sobrecarga operador mas
        /// se agregara el alumno a una universidad si el mismo no se encuentra en la universidad
        /// caso contratio se lanzara una exception AlumnoRepetidoException
        /// </summary>
        /// <param name="g">universidad a la cual se le agregara el aluimno en el caso de que el no participe en ella</param>
        /// <param name="a">alumno a agregar a la unveirsidad</param>
        /// <returns>universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            g.alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// sobrecarga operador mas entre universidad y profesor
        /// agrega un profesor si el mismo no se encuentra en la universidad
        /// </summary>
        /// <param name="g">universidad a la cual se le va a adicionar el profesor</param>
        /// <param name="p">profesor a agregar a la universidad</param>
        /// <returns>universidad con el profesor agregado si no esta repetido , caso de estarlo se retorna la universidad si modificar</returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            bool estaRepetido = false;

            foreach (Profesor item in g.profesors)
            {
                if (item == p)
                {
                    estaRepetido = true;
                    break;
                }
            }
            if (!estaRepetido)
            {
                g.profesors.Add(p);
            }
            return g;
        }
        /// <summary>
        /// metodo que retorna toda la informacion de la universidad
        /// </summary>
        /// <param name="uni">universidad que se va a mostrar la informacion</param>
        /// <returns>un string con los datos de la universidad, sus jornadas , profesores y alumnos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de tostring utiliza el metodo statico mostrar datos
        /// </summary>
        /// <returns>retorna un string con los datos de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        /// <summary>
        /// genera un archivo xml con la ingormacion de la universidad
        /// </summary>
        /// <param name="uni">universidad a serealizar</param>
        /// <returns>true si se pudo serealizar</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            if (xml.Guardar(".//universidad.xml", uni))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// lee un archivo xml y retorna la universidad
        /// </summary>
        /// <returns>universidad de un archivo xml</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(".//universidad.xml", out Universidad uni);
            return uni;
        }
        #endregion
    }
}
