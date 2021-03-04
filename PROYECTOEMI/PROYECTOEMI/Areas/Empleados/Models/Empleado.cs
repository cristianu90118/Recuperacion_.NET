using Microsoft.AspNetCore.Http;
using PROYECTOEMI.Areas.Compras.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTOEMI.Areas.Empleados.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            ComprarProducto = new HashSet<ComprarProducto>();
        }

        public int EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<ComprarProducto> ComprarProducto { get; set; }
        [NotMapped]
        [Display(Name = "Imagen")]
        public IFormFile ImagenCarga { set; get; }
    }
}
