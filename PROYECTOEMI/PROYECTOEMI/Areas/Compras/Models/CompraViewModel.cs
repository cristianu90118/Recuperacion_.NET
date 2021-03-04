using PROYECTOEMI.Areas.Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTOEMI.Areas.Compras.Models
{
    public class CompraViewModel
    {
        public float Total { set; get; }
        public List<Producto> Productos { set; get; }
    }
}
