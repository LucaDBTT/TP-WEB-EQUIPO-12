using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Dominio
{
    public class ItemCarrito
    {
        public List<Articulo> ArticulosEnCarrito { get; set; }

        public ItemCarrito()
        {
            ArticulosEnCarrito = new List<Articulo>();
        }

        public void AgregarAlCarrito(Articulo articulo)
        {
            ArticulosEnCarrito.Add(articulo);
        }

        public void EliminarDelCarrito(Articulo articulo)
        {
            ArticulosEnCarrito.Remove(articulo);
        }
        public void LimpiarCarrito()
        {
            ArticulosEnCarrito.Clear();
        }
    }
}
