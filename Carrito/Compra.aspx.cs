using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Carrito
{
    public partial class Compra : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            if (!IsPostBack)
            {
                if (Request.QueryString["EliminarArticulo"] != null)
                {
                    int idArticuloEliminar = Convert.ToInt32(Request.QueryString["EliminarArticulo"]);
                    EliminarArticuloDelCarrito(idArticuloEliminar);
                }
                if (Request.QueryString["IdArticulo"] != null)
                {
                    string idArticulo = Request.QueryString["IdArticulo"];

                    // Agregar el artículo al carrito si es necesario
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    articulos = articuloNegocio.ListarConSP();

                    foreach (Articulo obj in articulos)
                    {
                        if (obj.IdArticulo.ToString() == idArticulo)
                        {

                            seleccionado = obj;

                        }
                    }

                    if (articulos != null)
                    {
                        ItemCarrito carritoCompra = ObtenerCarrito();
                        carritoCompra.AgregarAlCarrito(seleccionado);
                    }
                }

                ItemCarrito carrito = ObtenerCarrito();
                repeaterResultados.DataSource = carrito.ArticulosEnCarrito;
                repeaterResultados.DataBind();

                decimal total = 0;
                foreach (Articulo item in carrito.ArticulosEnCarrito)
                {
                    total += item.Precio;
                }

                totalAmount.InnerText = total.ToString("C");

            }
        }

        private void EliminarArticuloDelCarrito(int idArticuloEliminar)
        {
            // Obtén el carrito
            ItemCarrito carrito = ObtenerCarrito();

            // Utiliza LINQ para encontrar el artículo a eliminar por su ID
            Articulo articuloAEliminar = carrito.ArticulosEnCarrito.FirstOrDefault(a => a.IdArticulo == idArticuloEliminar);

            if (articuloAEliminar != null)
            {
                // Si se encontró el artículo, elimínalo del carrito
                carrito.ArticulosEnCarrito.Remove(articuloAEliminar);

                // Actualiza la lista de carrito en la sesión
                Session["Carrito"] = carrito;
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

