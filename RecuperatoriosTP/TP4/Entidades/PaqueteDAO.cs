using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        static PaqueteDAO()
        {
            _conexion = new SqlConnection(Properties.Settings.Default.Conexion);

            _comando = new SqlCommand();
        }

        public static bool Insertar(Paquete p)
        {
            bool returnValue = false;

            try
            {
                _comando.CommandText = String.Format("insert into Paquetes(direccionEntrega,trackingID,alumno) values('{0}','{1}','Arevalo Federico')", p.DireccionDeEntrega, p.TrackingID);
                _comando.Connection = _conexion;

                _conexion.Open();

                _comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                    _conexion.Close();
            }


            return returnValue;
        }
    }
}
