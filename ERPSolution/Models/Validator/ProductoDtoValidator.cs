using ERPSolution.Models.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models.Validator
{
    public class ProductoDtoValidator:AbstractValidator<ProductoDto>
    {
        public ProductoDtoValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().Length(5, 300)
            .WithMessage("Por favor Digite La descripcion del producto Minimo 5 Caracteres");
            RuleFor(x => x.PrecioVenta).NotEmpty().GreaterThan(0)
                .WithMessage("Por El precio de Venta no puede ser 0");
            RuleFor(x => x.CostoPromedio).NotEmpty().GreaterThan(0)
                .WithMessage("Por favor Costo promedio no puede ser 0");
            RuleFor(x => x.PrecioVenta).NotEmpty().GreaterThan(0)
                .WithMessage("Por precio de venta no puede ser 0");
            RuleFor(x => x.StockMinimo).NotEmpty().GreaterThan(0)
                .WithMessage("Por favor Stock Minimo no puede ser 0");
        }
        private bool ValidaPrecioVenta(int PrecioVenta,int CostoPromedio)
        {
            return (CostoPromedio<PrecioVenta);
        }
    }
}
