//using Microsoft.AspNetCore.Http;
//using PROYECTOEMI.Areas.Productos.Models;
//using PROYECTOEMI.Areas.Ventas.Controllers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace PROYECTOEMI.Areas.Productos.Models
//{
//    public class Producto
//    {
//        //Productos es muchos
//        //Una categoria puede tener muchos productos, pero muchos productos solo pueden tener una categoria
//        [Key]
//        public int ProductoId { set; get; }
//        public string NombreProducto { set; get; }
//        public string Imagen { set; get; }

//        public int CategoriaId { set; get; }
//        public bool Estado { set; get; }
//        public Categoria Categoria { set; get; }
//        public ICollection<DetalleVenta> DetalleVentas { set; get; }

//        [NotMapped]
//        public List<Categoria> Categorias { set; get; }
//        [NotMapped]
//        [Display(Name = "Imagen")]
//        public IFormFile ImagenCarga { set; get; }
//    }
//}
