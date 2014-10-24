using FluentValidation;

namespace CreditCardValidation.Validators
{
    public class CreditCardNumberValidator : AbstractValidator<string>
    {
        public CreditCardNumberValidator()
        {
            RuleFor(creditCardNumber => creditCardNumber).NotNull()
                .WithName("CreditCardNumber");

            RuleFor(creditCardNumber => creditCardNumber).Length(16)
                .WithMessage("Credit card number must have 16 letters");
        }
    }
}
