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
        private CarritoDeCompras carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
        {
            // Inicializa el carrito de compras
            carrito = new CarritoDeCompras();
        }

        // Actualiza el GridView con los artículos en el carrito
        ActualizarGridView();
        }
        private void ActualizarGridView()
        {
            // Limpia el GridView
            dgvCarrito.DataSource = null;
            dgvCarrito.DataBind();

            // Llena el GridView con los artículos en el carrito
            dgvCarrito.DataSource = carrito.ObtenerItems();
            dgvCarrito.DataBind();
        }
    }
}