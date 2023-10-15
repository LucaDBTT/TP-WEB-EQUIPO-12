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
    public partial class WebMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el carrito de compras
                ItemCarrito carrito = ObtenerCarrito();

                // Calcular la cantidad de artículos en el carrito
                int cantidadArticulos = carrito.ArticulosEnCarrito.Count;

                // Establecer el valor del Label
                lblCartItemCount.Text = cantidadArticulos.ToString();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            // Obtén el término de búsqueda ingresado por el usuario.
            string searchTerm = txtSearch.Value;  // Usamos .Value en lugar de .Text

            // Realiza aquí la lógica de búsqueda, como la consulta a la base de datos.

            // Luego, redirige a la página de resultados de búsqueda, pasando el término de búsqueda como parámetro de consulta.
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Response.Redirect("ResultadosBusqueda.aspx?search=" + Server.UrlEncode(searchTerm));
            }
            else
            {
                
            }
        }
        protected ItemCarrito ObtenerCarrito()
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new ItemCarrito();
            }

            return (ItemCarrito)Session["Carrito"];
        }
    }
}
