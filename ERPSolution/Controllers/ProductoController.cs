using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSolution.Models;
using ERPSolution.Models.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPSolution.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]

    public class ProductoController : Controller
    {
        //private readonly ERPContext context;
        private readonly IValidator<ProductoDto> _valproducto;
        public readonly ERPContext context;
        public ProductoController(ERPContext context, IValidator<ProductoDto> valproducto)
        {
            this.context = context;
            _valproducto = valproducto;

        }

        [HttpGet("GetProducto")]
        public async Task<ActionResult<List<Producto>>> GetProducto()
        {
            try
            {
                var producto = await context.Producto.ToListAsync();
                var productoDto = producto.Select(x => new ProductoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion.Trim(),
                    Saldoinicial=x.Saldoinicial,
                    SaldoActual = x.SaldoActual,
                    UnidadMedidaId = x.UnidadMedidaId,
                    CostoPromedio = x.CostoPromedio,
                    PrecioVenta = x.PrecioVenta,
                    StockMinimo = x.StockMinimo,
                    StockMaximo = x.StockMaximo,
                });

                if (productoDto != null)
                {
                    return Ok(productoDto);
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


        [HttpGet("GetProductoById/{Id}")]
        public async Task<ActionResult<Producto>> GetProductoById(int id)
        {
            try
            {
                var productoDto = new ProductoDto();
                var producto = await context.Producto.FindAsync(id);
                if (producto!=null)
                    {
                    productoDto = new ProductoDto
                    {
                        Id = producto.Id,
                        Descripcion = producto.Descripcion.Trim(),
                        Saldoinicial = producto.Saldoinicial,
                        SaldoActual = producto.SaldoActual,
                        UnidadMedidaId = producto.UnidadMedidaId,
                        CostoPromedio = producto.CostoPromedio,
                        PrecioVenta = producto.PrecioVenta,
                        StockMinimo = producto.StockMinimo,
                        StockMaximo = producto.StockMaximo,
                    };
                }
                if (productoDto != null)
                {
                    return Ok(productoDto);
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


        [HttpPut("Putproducto/{id}")]
        public async Task<IActionResult> Putproducto(int id, ProductoDto productoDto)
        {
            var producto = new Producto
            {
                Id = productoDto.Id,
                Descripcion = productoDto.Descripcion,
                Saldoinicial = productoDto.Saldoinicial,
                SaldoActual = productoDto.SaldoActual,
                UnidadMedidaId = productoDto.UnidadMedidaId,
                CostoPromedio = productoDto.CostoPromedio,
                PrecioVenta = productoDto.PrecioVenta,
                StockMinimo = productoDto.StockMinimo,
                StockMaximo = productoDto.StockMaximo,
                FechaCreacion = productoDto.FechaCreacion,
                FechaModificacion = productoDto.FechaModificacion,
                UsuarioCreacionId = productoDto.UsuarioCreacionId,
                UsuarioModificacionId = productoDto.UsuarioModificacionId
            };

            if (id != producto.Id)
            {
                return BadRequest();
            }
            context.Entry(producto).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Descripcion.Trim()))
                {
                    return NotFound();
                }
                else
                {
                    //throw;
                    return BadRequest();
                }
            }
            return NoContent();
        }

        [HttpPost("Producto")]
        public async Task<ActionResult<Producto>> Producto(ProductoDto productoDto)
        {
            List<String> respuesta = new List<String>();
            var resuladovalidacion = _valproducto.Validate(productoDto);
            if (!resuladovalidacion.IsValid)
            {
                foreach (var error in resuladovalidacion.Errors)
                {
                    respuesta.Add(error.ToString());
                }
                return new BadRequestObjectResult(respuesta);
            }

            var producto = new Producto
            {
                Descripcion = productoDto.Descripcion,
                Saldoinicial = productoDto.Saldoinicial,
                SaldoActual = productoDto.SaldoActual,
                UnidadMedidaId = productoDto.UnidadMedidaId,
                CostoPromedio = productoDto.CostoPromedio,
                PrecioVenta = productoDto.PrecioVenta,
                StockMinimo = productoDto.StockMinimo,
                StockMaximo = productoDto.StockMaximo,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioCreacionId = 1,
                UsuarioModificacionId = 1
            };
            context.Producto.Add(producto);
            try
            {
                if (!ProductoExists(producto.Descripcion.Trim())) await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(producto.Descripcion.Trim()))
                {
                    return Conflict();
                }
                //else
                //{
                //    return BadRequest();
                //}
            }

            return CreatedAtAction("GetProducto", new { id = producto.Id }, productoDto);
        }

        [HttpDelete("DeleteProducto/{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            context.Producto.Remove(producto);
            await context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(string descripcion)
        {
            return context.Producto.Any(e => e.Descripcion.Trim() == descripcion);
        }

    }
}
