using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito
{
    public partial class Compra : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializa el carrito de compras
                if (Request.QueryString["IdArticulo"] != null)
                {
                    string idArticulo = Request.QueryString["IdArticulo"];
                    // Ahora puedes usar el valor de idArticulo como desees en esta página.
                    LBL.Text = "ID del Artículo: #" + idArticulo;
                }

            }
        }
    }
}
