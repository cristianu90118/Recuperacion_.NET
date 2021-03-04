//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PROYECTOEMI.Areas.Productos.Models
//{
//    public class Categoria
//    {
//        //Categoria es una
//        // Una categoria puede tener muchos productos
//        [Key]
//        [Display(Name = "Categoria")]
//        public int CategoriaId { set; get; }
//        [Required(ErrorMessage = "El nombre es requerido")]
//        [StringLength(80)]
//        [Display(Name = "Nombre")]
//        public string NombreCategoria { set; get; }
//        [Required(ErrorMessage = "El nombre es requerido")]
//        [Display(Name = "Producto")]
//        public ICollection<Producto> Productos { set; get; }

//    }
//}
