//using PROYECTOEMI.Areas.Ventas.Models;
//using System;
//using System.Collections.Generic;
//using PROYECTOEMI.Models;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using PROYECTOEMI.Areas.Empleados.Models;

//namespace PROYECTOEMI.Areas.Ventas.Models
//{
//    public partial class Venta
//    {
//        //Ventas es muchos
//        //Un empleado puede tener muchas ventas
//        //Venta es uno con detalle vetnas, una venta puede tener muchos detalles
//        [Key]
//        public int IdVenta { get; set; }
//        public string NombreVenta { get; set; }
//        public double Total { get; set; }
//        //public string Id { get; set; }
//        public int EmpleadoId { get; set; }
//        public double Iva { get; set; }
//        public DateTime Fecha { get; set; }
//        public bool Estado { set; get; }
//        public Empleado Empleado { set; get; }
//        public ICollection<DetalleVenta> DetalleVentas { set; get; }



//        [NotMapped]
//        public List<Empleado> Empleados { set; get; }
        

//    }
//}
