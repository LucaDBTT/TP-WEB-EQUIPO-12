using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Marca
    {
        [DisplayName("Id de la marca")]
        public int IdMarca { get; set; }
        [DisplayName("Descripción de la marca")]
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
