using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesExcepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enum
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {

            set
            {
                this.DNI = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion
        #region Metodos
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //Si es Argentino y el valor es de 1 a 89999999
            if (nacionalidad == ENacionalidad.Argentino &&
                dato > 0 &&
                dato < 90000000)
            {
                return dato;
            }
            //Si es extranjero y el valor es de 90000000 y 99999999
            else if (this.nacionalidad == ENacionalidad.Extranjero &&
                     dato > 89999999 &&
                     dato < 999999999)
            {
                return dato;
            }
            //Si no cumple con ningun caso se lanza la excepcion
            else
            {
                throw new NacionalidadInvalidException("Nacionalidad Invalida!");
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (int.TryParse(dato, out dni) &&
                dato.Length < 9)
            {
                return ValidarDni(nacionalidad, dni);
            }
            throw new DniInvalidException("DNI INVALIDA EXCEPTION");
        }
        private string ValidarNombreApellido(string dato)
        {
            bool isLetters = true;
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    isLetters = false;
                    break;
                }
            }
            if (isLetters)
            {
                return dato;
            }
            return "";
        }
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}.");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            return sb.ToString();
        }
        #endregion

    }
}
