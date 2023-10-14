using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoDeCompras
    {
        private List<ItemCarrito> items;

        public CarritoDeCompras()
        {
            items = new List<ItemCarrito>();
        }

        // Agregar un producto al carrito
        public void AgregarAlCarrito(Articulo articulo, int cantidad)
        {
            var itemExistente = items.FirstOrDefault(i => i.Articulo.IdArticulo == articulo.IdArticulo);

            if (itemExistente != null)
            {
                itemExistente.Articulo.IdArticulo = articulo.IdArticulo;
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                var nuevoItem = new ItemCarrito
                {
                    
                    Articulo = articulo,
                    Cantidad = cantidad,
                };
                items.Add(nuevoItem);
            }
        }

        // Obtener todos los items del carrito
        public List<ItemCarrito> ObtenerItems()
        {
            return items;
        }
    }
}
