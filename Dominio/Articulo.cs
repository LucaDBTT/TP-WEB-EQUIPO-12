using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Articulo
    {
        [DisplayName("Id del articulo")]
        public int IdArticulo { get; set; }
        [DisplayName("Codigo del articulo")]
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Marca del articulo")]
        public Marca Marca { get; set; }
        [DisplayName("Categoría del articulo")]
        public Categoria Categoria { get; set; }
        public Imagen ImagenUrl { get; set; }
        public Decimal Precio { get; set; }
    }
}
