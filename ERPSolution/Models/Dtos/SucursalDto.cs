using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models.Dtos
{
    public class SucursalDto
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
		public int UsuarioCreacionId { get; set; }
		public int UsuarioModificacionId { get; set; }
	}
}
