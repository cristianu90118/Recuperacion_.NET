using PROYECTOEMI.Areas.Compras.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTOEMI.Areas.Facturas.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Comprar = new HashSet<Comprar>();
        }
        [Key]
        public int NumFactura { get; set; }
        public string NombreFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public int IdPago { get; set; }
        public bool Estado { set; get; }
        public Pago Pago { set; get; }


        public virtual ICollection<Comprar> Comprar { get; set; }
        [NotMapped]
        public List<Pago> Pagos { set; get; }
    }
}
