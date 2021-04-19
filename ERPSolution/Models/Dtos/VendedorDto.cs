using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models.Dtos
{
    public class VendedorDto
    {
		public string Id { get; set; }
		public int DocumentoId { get; set; }
		public string NombreCompleto { get; set; }
		public string DireccionResidencia { get; set; }
		public string TelefonoContacto { get; set; }
		public string Email { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public int Edad { get; set; }
		public string Sexo { get; set; }
		public bool Activo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
		public int UsuarioCreacionId { get; set; }
		public int UsuarioModificacionId { get; set; }
	}
}
