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
    public partial class ResultadosBusqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si se proporciona un parámetro de búsqueda en la URL
                if (Request.QueryString["search"] != null)
                {
                    string searchTerm = Request.QueryString["search"];

                    // Llama al método filtrar del proyecto "negocio" para obtener los resultados.
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> resultados = negocio.filtrar("Nombre", "Contiene las letras: ", searchTerm);

                    // Muestra los resultados en el Repeater
                    repeaterResultados.DataSource = resultados;
                    repeaterResultados.DataBind();
                }
            }
        }
    }
}