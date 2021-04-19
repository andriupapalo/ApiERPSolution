using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models
{
    public class TipoIdentificacion
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
		public int UsuarioCreacionId { get; set; }
		public int UsuarioModificacionId { get; set; }
	}
}
