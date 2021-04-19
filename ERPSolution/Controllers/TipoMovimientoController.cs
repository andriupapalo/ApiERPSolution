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
    public class TipoMovimientoController : Controller
    {
        //private readonly ERPContext context;
        public readonly ERPContext context;
        public TipoMovimientoController(ERPContext context)
        {
            this.context = context;

        }

        [HttpGet("TipoMovimiento")]
        public async Task<ActionResult<IEnumerable<TipoMovimiento>>> TipoMovimiento()
        {
            try
            {
                var tipoMovimiento = await context.TipoMovimiento.ToListAsync();
                var tipoMovimientoDto = tipoMovimiento.Select(x => new TipoMovimientoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion.Trim()
                });

                if (tipoMovimientoDto != null)
                {
                    return Ok(tipoMovimientoDto);
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
