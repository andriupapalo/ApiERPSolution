using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSolution.Models;
using ERPSolution.Models.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ERPSolution.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UnidadMedidaController : Controller
    {
        //private readonly ERPContext context;
        public readonly ERPContext context;
        public UnidadMedidaController(ERPContext context)
        {
            this.context = context;

        }

        [HttpGet("UnidadMedida")]
        public async Task<ActionResult<List<UnidadMedida>>> UnidadMedida()
        {
            try
            {
                var unidadmedida = await context.UnidadMedida.ToListAsync();
                var unidadmedidaDto = unidadmedida.Select(x => new UnidadMedidaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion.Trim()
                });

                if (unidadmedidaDto != null)
                {
                    return Ok(unidadmedidaDto);
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
