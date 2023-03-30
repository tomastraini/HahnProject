using FluentValidation;
using HahnProject.API.RequestEntities;

namespace HahnProject.API.RequestValidator
{
    public class PersonTypeRValidator : AbstractValidator<PersonTypeR>
    {
        public PersonTypeRValidator()
        {
            RuleFor(x => x.type).NotNull().NotEmpty().WithMessage("Person type cannot be null!!");

        }

    }
}
