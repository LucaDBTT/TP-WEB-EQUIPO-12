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
    public partial class Default : System.Web.UI.Page
    {
       public List<Articulo>  ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.ListarConSP();
            if (!IsPostBack)
            {
                repRepeater.DataSource = ListaArticulo;
                repRepeater.DataBind();
            } 
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            Button btnDetalle = (Button)sender;
            string idArticulo = btnDetalle.CommandArgument;

            if (!string.IsNullOrEmpty(idArticulo))
            {
                Session["IdArticulo"] = idArticulo;
                Response.Redirect("Detalle.aspx", false);
            }
        }

    }
}