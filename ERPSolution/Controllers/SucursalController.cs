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

    public class SucursalController : Controller
    {
        //private readonly ERPContext context;
        public readonly ERPContext context;
        public SucursalController(ERPContext context)
        {
            this.context = context;

        }

        [HttpGet("Sucursal")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> Sucursal()
        {
            try
            {
                var sucursal = await context.Sucursal.ToListAsync();
                var sucursalDto = sucursal.Select(x => new SucursalDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion.Trim()
                });

                if (sucursalDto != null)
                {
                    return Ok(sucursalDto);
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
