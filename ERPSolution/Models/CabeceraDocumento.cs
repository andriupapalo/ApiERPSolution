using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models
{
    public class CabeceraDocumento
    {
        public int Id { get;set; }
        public int TipoMovimientoId { get; set; }
        public int SucursalId { get; set; }
        public int VendedorId { get; set; }
        public string ClienteId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int CantidadUnidades { get; set; }
        public int Subtotal { get; set; }
        public int Iva { get; set; }
        public int Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int UsuarioModificacionId { get; set; }
    }
}
