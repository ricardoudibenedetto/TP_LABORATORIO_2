using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesExcepciones;
namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        #region Enum
        /// <summary>
        /// Enumeracion de Nacionalidades
        /// </summary>
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
        /// <summary>
        /// Propiedad string que asigna valor al apellido validando que los valores sean correctos
        /// </summary>
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
        /// <summary>
        /// propiedad int , asigna valor al dni validando que sea correcto
        /// </summary>
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
        /// <summary>
        /// Propiedad Enacionalidad , asigna valor a al atributo nacionalidad
        /// </summary>
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
        /// <summary>
        /// propiedad string, asigna valor al nombre validando que el valor sea correcto
        /// </summary>
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
        /// <summary>
        /// propiedad string, asigna valor al dni valudando que el valor sea correcto y transformandolo en int
        /// </summary>
        public string StringToDNI
        {

            set
            {
                this.DNI = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion
        #region Metodos
        /// <summary>
        /// metodo que valida un dato se corresponda en nacionalidad y dni
        /// </summary>
        /// <param name="nacionalidad">nacionalidad que debe ser valida para el dni</param>
        /// <param name="dato">dni a validar con la nacionalidad </param>
        /// <returns>si el dato es correcto lo retorna sino lanzara una exception</returns>
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
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el numero de DNI.");
            }
        }

        /// <summary>
        /// valida que el dato no tenga caracteres no numericos
        /// </summary>
        /// <param name="nacionalidad">nacionalidad que se correspondera al dni</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>si es validado correctamente retorna el dato, sino lanzara una exception</returns>
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
        /// <summary>
        /// valida que el dato solo contenga caracteres validos para un nombre o apellido
        /// </summary>
        /// <param name="dato">dato es el valor a validar</param>
        /// <returns>si esta correcto retorna el dato, sino retornara un vacio</returns>
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

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// constructor con tres parametros
        /// asignara los valores correspondientes mediante las propiedades que validaran si todo es correcto
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// <param name="nacionalidad">Nacionalidad a asignar</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor con cuatro parametros
        /// asigna valor a las propiedades de la persona
        /// llama al otro constructor de 4 parametros y le pasa el dni de forma string
        /// </summary>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="dni">ani a asignar</param>
        /// <param name="nacionalidad">nacionalidad a asignar</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        /// <summary>
        /// constructor con cuatro parametros 
        /// asigna los valores a las propiedades de la eprsona
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// <param name="dni">dni a asignar</param>
        /// <param name="nacionalidad">nacionalidad a asginar</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// sobrecarga el tostring de persona
        /// 
        /// </summary>
        /// <returns>retorna todo los datos de la persona </returns>
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
