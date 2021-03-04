//using Microsoft.AspNetCore.Http;
//using PROYECTOEMI.Areas.Ventas.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PROYECTOEMI.Areas.Empleados.Models
//{
//    public class Empleado
//    {
//        //Empleado es uno
//        //Un empleado puede tener muchas ventas, pero muchas ventas solo pueden tener un empleado.
//        [Key]
//        public int EmpleadoId { set; get; }
//        [Required(ErrorMessage = "El nombre es requerido")]
//        [StringLength(50, MinimumLength = 3)]
//        public string NombreEmpleado { set; get; }
//        public string Apellido { set; get; }
//        public string Direccion { set; get; }
//        public string Telefono { set; get; }

//        public string Imagen { set; get; }
//        public bool Estado { set; get; }
//        public ICollection<Venta> Ventas { set; get; }


//    }
//}
