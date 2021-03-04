//using PROYECTOEMI.Areas.Facturas.Models;
//using PROYECTOEMI.Areas.Productos.Controllers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PROYECTOEMI.Areas.Ventas.Models
//{
//    public class DetalleVenta
//    {
//        //DetalleVenta es muchos
//        // muchos detalles pueden tener muchas ventas y muchos detalles pueden tener muchos productos
//        [Key]
//        [Display(Name = "DetalleVenta")]
//        public int IdDetalle { set; get; }
//        [Display(Name = "NumFactura")]
//        public int NumFactura { set; get; }
//        [Display(Name = "IdVenta")]
//        public int IdVenta { set; get; }
//        [Display(Name = "Subtotal")]
//        public double SubTotal { set; get; }
//        [Display(Name = "Producto")]
//        public int ProductoId { set; get; }
//        [Display(Name = "Descuento")]
//        public int Descuento { set; get; }
//        [Display(Name = "Cantidad")]
//        public int Cantidad { set; get; }
//        public Venta Venta { set; get; }
//        public Producto Producto { set; get; }
//        public Factura Factura { set; get; }


//        [NotMapped]
//        public List<Venta> Ventas { set; get; }
//        public List<Producto> Productos { set; get; }
//        public List<Factura> Facturas { set; get; }


//    }
//}
