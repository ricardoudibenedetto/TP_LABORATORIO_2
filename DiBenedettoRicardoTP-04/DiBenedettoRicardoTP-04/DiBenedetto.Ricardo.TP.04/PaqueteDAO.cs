using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// constructor de PaqueteDAO
        /// se encarga de establecer un SqlComando y asignarle la conexion a la DB
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
            comando.Connection = conexion;
        }

        /// <summary>
        /// inserta un paquete en la base de datos 
        /// </summary>
        /// <param name="p">paquete a insertar</param>
        /// <returns>True si pudo insertar el paquete, en caso contrario lanza una excepcion</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = $"INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{ p.DireccionEntrega }',' { p.TrackingID }', 'Di Benedetto Ricardo')";
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                comando.Connection.Close();
                throw e;
            }

        }
    }
}
