using FluentValidation;
using HahnProject.API.RequestEntities;
using System.Net;

namespace HahnProject.API.RequestValidator
{
    public class PersonRValidator : AbstractValidator<PersonR>
    {
        public PersonRValidator()
        {
            RuleFor(x => x.person_type).NotNull().NotEmpty().WithMessage("Person type cannot be null!!");
            RuleFor(x => x.balance).NotNull().WithMessage("Balance cannot be null!!");
            RuleFor(x => x.business_name).NotNull().NotEmpty().WithMessage("Business name cannot be null!!");

        }

    }
}
