using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models
{
    public class ERPContext :DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options)
          : base(options)
        { }
        public DbSet<CabeceraDocumento> CabeceraDocumento { get; set; }
        public DbSet<DetalleDocumento> DetalleDocumento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

    }
}
