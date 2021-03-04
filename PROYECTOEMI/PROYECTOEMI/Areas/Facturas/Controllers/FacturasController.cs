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
using PROYECTOEMI.Areas.Compras.Models;

namespace PROYECTOEMI.Areas.Facturas.Controllers
{
    public class FacturasController : Controller
    {
        public ApplicationDbContext _dbContext;

        public FacturasController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int Pag, int Registros, string Search)
        {
            List<Models.Factura> Facturas = null;
            if (Search != null)
            {
                Facturas = _dbContext.Factura.Include(e => e.Pago)
                    .Where(e => e.NombreFactura.Contains(Search)).ToList();
            }
            else
            {
                Facturas = _dbContext.Factura.Include(e => e.Pago).ToList();
            }
            string host = Request.Scheme + "://" + Request.Host.Value;
            object[] resultado = new Paginador<Models.Factura>().paginador(Facturas, Pag, Registros, "Facturas", "Factura", "Index", host);


            DataPaginador<Models.Factura> modelo = new DataPaginador<Models.Factura>
            {
                Lista = (List<Models.Factura>)resultado[2],
                Pagi_info = (string)resultado[0],
                Pagi_navegacion = (string)resultado[1]
            };
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            Models.Factura Factura = new Models.Factura();
            Factura.Pagos = _dbContext.Pago.ToList();
            return View(Factura);
        }
        [HttpPost]
        public IActionResult Guardar(Models.Factura factura)
        {
            if (!ModelState.IsValid)
            {
                factura.Pagos = _dbContext.Pago.ToList();
                return View(factura.NumFactura == 0 ? "Crear" : "Editar", factura);
            }

            else
            {
                _dbContext.Update(factura);
            }
            _dbContext.Add(factura);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            //Con esto se lista
            Models.Factura factura = _dbContext.Factura.Find(id);
            if (factura == null)
            {
                return RedirectToAction("Index");
            }
            factura.Pagos = _dbContext.Pago.ToList();

            return View("Editar");
        }
        public IActionResult CambiarEstado(int id)
        {
            //Con esto se lista
            Models.Factura factura = _dbContext.Factura.Find(id);
            if (factura == null)
            {
                return RedirectToAction("Index");
            }

            factura.Estado = !factura.Estado;

            _dbContext.Update(factura);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
