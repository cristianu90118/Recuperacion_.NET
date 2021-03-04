using PROYECTOEMI.Areas.Facturas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTOEMI.Areas.Compras.Models
{
    public class Comprar
    {
        [Key]
        public int CompraId { set; get; }
        public DateTime Fechacompra { set; get; } = DateTime.Now;
        public string UsuarioId { set; get; }
        public float Total { set; get; }
        public Factura Factura { set; get; }

        public ICollection<ComprarProducto> ComprarCurso { set; get; }


    }
}
