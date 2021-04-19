using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models
{
	public class DetalleDocumento
	{
		public int Id { get; set; }
		public int IdCabeceraDocumento { get; set; }
		public int ProductoId { get; set; }
		public int Precio { get; set; }
		public int SaldoActual { get; set; }
		public int CantidadMovimiento { get; set; }
		public int NuevoSaldo { get; set; }
		public int Subtotal { get; set; }
		public int Iva { get; set; }
		public int Total { get; set; }
	}
}
