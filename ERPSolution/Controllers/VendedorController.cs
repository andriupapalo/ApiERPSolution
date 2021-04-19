using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSolution.Models;
using ERPSolution.Models.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPSolution.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class VendedorController : Controller
    {

        //private readonly ERPContext context;
        public readonly ERPContext context;
        public VendedorController(ERPContext context)
        {
            this.context = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            try
            {
                var vendedor = await context.Vendedor.ToListAsync();
                var vendedordto = vendedor.Select(x => new VendedorDto
                {
                    Id = x.Id.Trim(),
                    DocumentoId = x.documentoId,
                    NombreCompleto = x.NombreCompleto.Trim(),
                    DireccionResidencia = x.direccionResidencia.Trim(),
                    TelefonoContacto = x.TelefonoContacto.Trim(),
                    Email = x.Email.Trim(),
                    FechaNacimiento = x.FechaNacimiento,
                    Edad = x.Edad,
                    Sexo = x.Sexo,
                    Activo = x.Activo
                });

                if (vendedordto != null)
                {
                    return Ok(vendedordto);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
