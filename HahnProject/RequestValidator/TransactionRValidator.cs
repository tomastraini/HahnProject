using FluentValidation;
using HahnProject.API.RequestEntities;

namespace HahnProject.API.RequestValidator
{
    public class TransactionRValidator : AbstractValidator<TransactionR>
    {
        public TransactionRValidator()
        {
            RuleFor(x => x.person).NotNull().NotEmpty().WithMessage("Person cannot be null!!");

        }

    }
}
