using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region atributos
        private int legajo;

        #endregion
        #region metodos
        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticipaEnClases();
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"LEGAJO: {this.legajo}");
            return sb.ToString();
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            return (pg1 is Universitario && pg2 is Universitario) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }


        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
        #endregion

    }
}
