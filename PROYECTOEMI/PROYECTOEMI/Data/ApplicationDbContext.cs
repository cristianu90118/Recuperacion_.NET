using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROYECTOEMI.Areas.Compras.Models;
using PROYECTOEMI.Areas.Empleados.Models;
using PROYECTOEMI.Areas.Facturas.Models;
using PROYECTOEMI.Areas.Productos.Models;
using PROYECTOEMI.Models;

namespace PROYECTOEMI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Comprar> Comprar { get; set; }
        public virtual DbSet<ComprarProducto> ComprarProducto { get; set; }




        //public DbSet<AspNetUsers> AspNetUsers { set; get; }

    }
}
