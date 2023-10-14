using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Data.SqlClient;
using System.Data;

namespace Carrito
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public string nombre { get; set; }
        public string imgUrl { get; set; }
        public string descripcion { get; set; }
        public Decimal precio { get; set; }
        public string marca { get; set; }
        public List<string> imagenesArticulo { get; set; }
        


        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articulos = articuloNegocio.ListarConSP();
            imagenesArticulo = new List<string>();


            Articulo seleccionado = new Articulo();
            

            if (!IsPostBack)
            {
                // Verifica si el parámetro "IdArticulo" está presente en la URL.
                if (Request.QueryString["IdArticulo"] != null)
                {
                    string idArticulo = Request.QueryString["IdArticulo"];
                    // Ahora puedes usar el valor de idArticulo como desees en esta página.
                    LBL.Text = "ID del Artículo: #" + idArticulo; // Por ejemplo, puedes mostrarlo en una etiqueta Label.
                    foreach (Articulo obj in articulos)
                    {
                        if (obj.IdArticulo.ToString() == idArticulo)
                        {
                            
                            seleccionado = obj;

                        }

                    }
                    

                    nombre = seleccionado.Nombre;
                    //imgUrl = seleccionado.ImagenUrl.Descripcion;
                    descripcion = seleccionado.Descripcion;
                    precio = seleccionado.Precio;
                    marca = seleccionado.Marca.Descripcion;
                    ///aca tengo mis imagenes (se supone) 
                    //imagenesArticulo = seleccionado.imagenesUrl;


                    int id = int.Parse(idArticulo);
                DataTable imagenes = obtenerImagenesPorId(id);
                    
                foreach (DataRow row in imagenes.Rows)
                {
                        string url = row["ImagenUrl"].ToString();
                        imagenesArticulo.Add(url);
                }
                    repeaterImagenes.DataSource = imagenesArticulo;
                    repeaterImagenes.DataBind();


                    
                }

                




                else
                {
                    // Maneja el caso en el que el parámetro "IdArticulo" no está presente en la URL.
                    LBL.Text = "ID del Artículo no especificado"; // Puedes mostrar un mensaje de error.
                }

            }

            


        }

        private DataTable obtenerImagenesPorId(int id)
        {
            // Conexión a la base de datos
            string cadenaConexion = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("ObtenerDatosPorId", conexion))
                {
                    // Especificar que el comando es un procedimiento almacenado
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro
                    comando.Parameters.AddWithValue("@Id", id);

                    // Abrir conexión y ejecutar el comando
                    conexion.Open();
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable resultados = new DataTable();
                        adaptador.Fill(resultados);
                        return resultados;
                    }
                }
            }
        }
    }
}