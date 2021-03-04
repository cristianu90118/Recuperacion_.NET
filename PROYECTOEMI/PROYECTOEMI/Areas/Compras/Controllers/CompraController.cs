using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYECTOEMI.Areas.Compras.Models;
using PROYECTOEMI.Areas.Productos.Models;
using PROYECTOEMI.Data;

namespace PROYECTOEMI.Areas.Compras.Controllers
{
    [Area("Compras")]
    public class CompraController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CompraController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Producto> productos = _dbContext.Producto.Where(e => e.Estado).ToList();
            return View(productos);
        }

        public IActionResult Guardar(CompraViewModel compra)
        {

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Comprar comprar = new Comprar { UsuarioId = "x", Total = compra.Total };

                    _dbContext.Add(comprar);
                    _dbContext.SaveChanges();

                    foreach (Producto item in compra.Productos)
                    {
                        ComprarProducto comprarProducto = new ComprarProducto
                        {
                            ProductoId = item.ProductoId,
                            ComprarId = comprar.CompraId
                        };
                        _dbContext.Add(comprarProducto);

                    }
                    _dbContext.SaveChanges();

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction();

        }
    }
}
