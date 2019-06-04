using ClasesAbstractas;
using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enum EEstadoCuenta
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
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni , ENacionalidad nacionalidad, Universidad.EClases claseQueToma )
            :base(nombre,apellido, dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre , apellido , dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string ParticipaEnClases()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
