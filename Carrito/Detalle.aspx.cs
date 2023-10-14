using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Carrito
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public string nombre { get; set; }
        public string imgUrl { get; set; }
        public string descripcion { get; set; }
        public List<Imagen> imagenesArticulo { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articulos = articuloNegocio.ListarConSP();
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
                    ///aca tengo mis imagenes (se supone) 
                    imagenesArticulo = seleccionado.imagenesUrl;

                    repeaterImages.DataSource = articulos.SelectMany(articulo => seleccionado.imagenesUrl);
                    repeaterImages.DataBind();

                }
                else
                {
                    // Maneja el caso en el que el parámetro "IdArticulo" no está presente en la URL.
                    LBL.Text = "ID del Artículo no especificado"; // Puedes mostrar un mensaje de error.
                }
            }

            


        }
    }
}