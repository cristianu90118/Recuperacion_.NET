//using PROYECTOEMI.Areas.Ventas.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PROYECTOEMI.Areas.Facturas.Models
//{
//    public class Factura
//    {
//        [Key]
//        public int NumFctura { set; get; }
//        public DateTime Fecha { set; get; }
//        public double Iva { set; get; }
//        public double Total { set; get; }
//        public int IdPago { set; get; }
//        public Pago Pago { set; get; }

//        public ICollection<DetalleVenta> DetalleVentas { set; get; }
//        public List<Pago> Pagos { set; get; }


//    }
//}
