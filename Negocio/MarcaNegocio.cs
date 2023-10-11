using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            List<Marca> Lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select Id, Descripcion from MARCAS");
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    Marca aux = new Marca();

                    aux.IdMarca = (int)datos.lector["Id"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
