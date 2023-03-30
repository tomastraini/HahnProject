using FluentValidation;
using HahnProject.API.RequestEntities;

namespace HahnProject.API.RequestValidator
{
    public class ProductsRValidator : AbstractValidator<ProductsR>
    {
        public ProductsRValidator()
        {
            RuleFor(x => x.description).NotNull().NotEmpty().WithMessage("Description cannot be null!!");
            RuleFor(x => x.stock).NotNull().NotEmpty().WithMessage("Stock cannot be null!!");
            RuleFor(x => x.price).NotNull().NotEmpty().WithMessage("Price cannot be null!!");
            RuleFor(x => x.supplier_id).NotNull().NotEmpty().WithMessage("Supplier type cannot be null!!");
        }

    }
}
