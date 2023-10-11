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
       //public List<Articulo>  ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            dgvArticulo.DataSource = articuloNegocio.ListarConSP();
            dgvArticulo.DataBind();
            
            
            /*repRepeater.DataSource = ListaArticulo;
            repRepeater.DataBind(); */
        }
    }
}