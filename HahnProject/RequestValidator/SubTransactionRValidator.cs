using FluentValidation;
using HahnProject.API.RequestEntities;

namespace HahnProject.API.RequestValidator
{
    public class SubTransactionRValidator : AbstractValidator<SubTransactionR>
    {
        public SubTransactionRValidator()
        {
            RuleFor(x => x.product_id).NotNull().NotEmpty().WithMessage("Person cannot be null!!");
            RuleFor(x => x.transaction_id).NotNull().NotEmpty().WithMessage("Person cannot be null!!");
            RuleFor(x => x.amount).NotNull().NotEmpty().WithMessage("Person cannot be null!!");

        }

    }
}
