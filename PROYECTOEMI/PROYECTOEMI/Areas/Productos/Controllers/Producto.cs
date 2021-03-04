using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYECTOEMI.Areas.Productos.Models;
using PROYECTOEMI.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using PROYECTOEMI.Models.Paginador;

namespace PROYECTOEMI.Areas.Productos.Controllers
{
    [Area("Productos")]
    public class Producto : Controller
    {
        public ApplicationDbContext _dbContext;

        public Producto(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int Pag, int Registros, string Search)
        {
            List<Models.Producto> Productos = null;
            if (Search != null)
            {
                Productos = _dbContext.Producto.Include(e => e.Categoria)
                    .Where(e => e.NombreProducto.Contains(Search)).ToList();
            }
            else
            {
                Productos = _dbContext.Producto.Include(e => e.Categoria).ToList();
            }
            string host = Request.Scheme + "://" + Request.Host.Value;
            object[] resultado = new Paginador<Models.Producto>().paginador(Productos, Pag, Registros, "Productos", "Producto", "Index", host);


            DataPaginador<Models.Producto> modelo = new DataPaginador<Models.Producto>
            {
                Lista = (List<Models.Producto>)resultado[2],
                Pagi_info = (string)resultado[0],
                Pagi_navegacion = (string)resultado[1]
            };
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            Models.Producto producto = new Models.Producto();
            producto.Categorias = _dbContext.Categoria.ToList();
            return View(producto);
        }
        [HttpPost]
        public IActionResult Guardar(Models.Producto producto)
        {
            if (!ModelState.IsValid)
            {
                producto.Categorias = _dbContext.Categoria.ToList();
                return View(producto.ProductoId == 0 ? "Crear" : "Editar", producto);
            }
            if (producto.ProductoId == 0)
            {
                if (producto.ImagenCarga != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", producto.ImagenCarga.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        producto.ImagenCarga.CopyTo(stream);
                        producto.Imagen = producto.ImagenCarga.FileName;
                    }
                }
                else
                {
                    producto.Imagen = "default.jpg";
                }
                _dbContext.Add(producto);
            }
            else
            {
                _dbContext.Update(producto);
            }
            _dbContext.Add(producto);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            //Con esto se lista
            Models.Producto producto = _dbContext.Producto.Find(id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }
            producto.Categorias = _dbContext.Categoria.ToList();

            return View("Editar");
        }
        public IActionResult CambiarEstado(int id)
        {
            //Con esto se lista
            Models.Producto producto = _dbContext.Producto.Find(id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }

            producto.Estado = !producto.Estado;

            _dbContext.Update(producto);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
        //public IActionResult Eliminar(int id)
        //{
        //    Producto producto = _dbContext.Producto.Find(id);
        //    if (producto == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    _dbContext.Producto.Remove(producto);
        //    _dbContext.SaveChanges();
        //        }
    }
}
