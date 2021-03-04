using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYECTOEMI.Data;
using PROYECTOEMI.Areas.Empleados;
using Microsoft.EntityFrameworkCore;
using PROYECTOEMI.Models.Paginador;

namespace PROYECTOEMI.Areas.Empleados.Controllers
{
    public class EmpleadoController : Controller
    {
        public ApplicationDbContext _dbContext;
        public EmpleadoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int Pag, int Registros, string Search)
        {
            List<Models.Empleado> Empleados = null;
            if (Search != null)
            {
                Empleados = _dbContext.Empleado.Where(e => e.NombreEmpleado.Contains(Search)).ToList();
            }
            else
            {
                Empleados = _dbContext.Empleado.ToList();
            }
            string host = Request.Scheme + "://" + Request.Host.Value;
            object[] resultado = new Paginador<Models.Empleado>().paginador(Empleados, Pag, Registros, "Empleados", "Empleado", "Index", host);


            DataPaginador<Models.Empleado> modelo = new DataPaginador<Models.Empleado>
            {
                Lista = (List<Models.Empleado>)resultado[2],
                Pagi_info = (string)resultado[0],
                Pagi_navegacion = (string)resultado[1]
            };
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            Models.Empleado empleado = new Models.Empleado();
            return View(empleado);
        }
        [HttpPost]
        public IActionResult Guardar(Models.Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado.EmpleadoId == 0 ? "Crear" : "Editar", empleado);
            }
            if (empleado.EmpleadoId == 0)
            {
                if (empleado.ImagenCarga != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", empleado.ImagenCarga.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        empleado.ImagenCarga.CopyTo(stream);
                        empleado.Imagen = empleado.ImagenCarga.FileName;
                    }
                }
                else
                {
                    empleado.Imagen = "default.jpg";
                }
                _dbContext.Add(empleado);
            }
            else
            {
                _dbContext.Update(empleado);
            }
            _dbContext.Add(empleado);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            //Con esto se lista
            Models.Empleado empleado = _dbContext.Empleado.Find(id);
            if (empleado == null)
            {
                return RedirectToAction("Index");
            }
            return View("Editar");
        }
        public IActionResult CambiarEstado(int id)
        {
            //Con esto se lista
            Models.Empleado empleado = _dbContext.Empleado.Find(id);
            if (empleado == null)
            {
                return RedirectToAction("Index");
            }

            empleado.Estado = !empleado.Estado;

            _dbContext.Update(empleado);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
