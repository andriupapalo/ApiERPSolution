using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using ERPSolution.Models;
using ERPSolution.Models.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;


namespace ERPSolution.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ClienteController : Controller
    {
        //private readonly ERPContext context;
        public readonly ERPContext context;
        public ClienteController(ERPContext context)
        {
            this.context = context;

        }

        [HttpGet("TipoIdentificacion")]
        public async Task<ActionResult<IEnumerable<TipoIdentificacion>>> TipoIdentificacion()
        {
            try
            {
                var tipoIdentificacion = await context.TipoIdentificacion.ToListAsync();
                var tTipoIdentificacionDto = tipoIdentificacion.Select(x => new TipoIdentificacionDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion.Trim()
                });

                if (tTipoIdentificacionDto != null)
                {
                    return Ok(tTipoIdentificacionDto);
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

        [HttpGet("GetClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var cliente = await context.Cliente.ToListAsync();
                var clientedto = cliente.Select(x => new ClienteDto
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

                if (clientedto != null)
                {
                    return Ok(clientedto);
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
