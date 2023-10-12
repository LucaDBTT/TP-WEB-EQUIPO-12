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
                // Verifica si el parámetro "IdArticulo" está presente en la URL.
                if (Request.QueryString["IdArticulo"] != null)
                {
                    string idArticulo = Request.QueryString["IdArticulo"];
                    // Ahora puedes usar el valor de idArticulo como desees en esta página.
                    LBL.Text = "ID del Artículo: " + idArticulo; // Por ejemplo, puedes mostrarlo en una etiqueta Label.
                }
                else
                {
                    // Maneja el caso en el que el parámetro "IdArticulo" no está presente en la URL.
                    LBL.Text = "ID del Artículo no especificado"; // Puedes mostrar un mensaje de error.
                }
            }
        }
    }
}