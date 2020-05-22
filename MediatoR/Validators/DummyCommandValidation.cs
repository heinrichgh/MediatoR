using FluentValidation;
using MediatoR.CQRS;

namespace MediatoR.Validators
{
    public class DummyCommandValidator : AbstractValidator<DummyCommand>
    {
        public DummyCommandValidator()
        {
            RuleFor(command => command.Damage).GreaterThanOrEqualTo(0).WithMessage("Damage must be a positive number");
            RuleFor(command => command.Car).NotEmpty();
        }
    }
}