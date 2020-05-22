using FluentValidation;
using MediatoR.CQRS;

namespace MediatoR.Validators
{
    public class TestCommandValidator : AbstractValidator<TestCommand>
    {
        public TestCommandValidator()
        {
            RuleFor(command => command.Age).GreaterThanOrEqualTo(18).WithMessage("Must be 18 or older");
            RuleFor(command => command.Name).NotEmpty();
        }
    }
}