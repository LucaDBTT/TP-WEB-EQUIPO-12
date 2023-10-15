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
    }
}