using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Categoria
    {
        [DisplayName("Id de la Categoría")]
        public int IdCategoria { get; set; }
        [DisplayName("Descripción de la categoría")]
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
