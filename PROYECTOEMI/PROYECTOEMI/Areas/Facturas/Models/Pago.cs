using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROYECTOEMI.Areas.Facturas.Models
{
    public partial class Pago
    {
        public Pago()
        {
            Facturas = new HashSet<Factura>();
        }
        [Key]
        public int IdPago { get; set; }
        public string TipoPago { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
