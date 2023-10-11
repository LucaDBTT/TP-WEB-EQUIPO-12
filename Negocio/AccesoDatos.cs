using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AccesoDatos : IDisposable
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Lector;

        public SqlDataReader lector
        {
            get { return Lector; }
        }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            Comando = new SqlCommand();
        }

        public void setearParametros(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        public void SetearQuery(string Query)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Query;
        }

        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
            }
            if (Conexion != null && Conexion.State != ConnectionState.Closed)
            {
                Conexion.Close();
            }
        }

        public void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void Dispose()
        {
            // Implementa la interfaz IDisposable para cerrar la conexión y liberar recursos
            CerrarConexion();
        }
    public void EjecutarLectura()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }


        
    }

