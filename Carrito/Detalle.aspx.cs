using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdArticulo"] != null)
                {
                    string idArticulo = Session["IdArticulo"].ToString();
                    LBL.Text = idArticulo;
                }
                else
                {
                    // Maneja el caso en el que la variable de sesión no existe o no tiene un valor
                }
            }
        }
    }
}