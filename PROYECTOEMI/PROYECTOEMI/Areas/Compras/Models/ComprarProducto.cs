using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PROYECTOEMI.Areas.Empleados.Models;
using PROYECTOEMI.Areas.Productos.Models;

namespace PROYECTOEMI.Areas.Compras.Models
{
    public class ComprarProducto
    {
        [Key]
        public int ComprarCursoId { set; get; }
        public int ComprarId { set; get; }
        public int ProductoId{ set; get; }

        public Producto Producto { set; get; }
        public Comprar Comprar { set; get; }
        public Empleado Empleado { set; get; }



    }
}
