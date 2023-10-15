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

            if (Request.QueryString["IdArticulo"] != null)
            {
                string idArticulo = Request.QueryString["IdArticulo"];
            }
        }

    }
}