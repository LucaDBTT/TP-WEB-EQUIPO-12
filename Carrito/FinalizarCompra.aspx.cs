using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Carrito
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpiarCarrito();
        }
        protected ItemCarrito ObtenerCarrito()
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new ItemCarrito();
            }

            return (ItemCarrito)Session["Carrito"];
        }
        private void LimpiarCarrito()
        {
            ItemCarrito carrito = ObtenerCarrito();
            carrito.LimpiarCarrito();
        }
    }
}