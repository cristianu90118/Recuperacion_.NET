using Microsoft.AspNetCore.Http;
using PROYECTOEMI.Areas.Compras.Models;
using PROYECTOEMI.Areas.Productos.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTOEMI.Areas.Productos.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { set; get; }
        public string NombreProducto { set; get; }
        public string Imagen { set; get; }
        public int CategoriaId { set; get; }
        public bool Estado { set; get; }
        public double Precio { set; get; } = 0;
        public Categoria Categoria { set; get; }
        public ICollection<ComprarProducto> ComprarCurso { set; get; }

        [NotMapped]
        public List<Categoria> Categorias { set; get; }
        [NotMapped]
        [Display(Name = "Imagen")]
        public IFormFile ImagenCarga { set; get; }
    }
}