using FluentValidation;
using SyncDeal.Communication.Requests;
using SyncDeal.Exceptions;

namespace SyncDeal.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMAIL_IS_REQUIRED)
                .EmailAddress()
                .When(user => !string.IsNullOrWhiteSpace(user.Email), ApplyConditionTo.CurrentValidator)
                .WithMessage(ResourceErrorMessages.INVALID_EMAIL);
            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserDTO>());
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.NAME_IS_REQUIRED);
        }
    }
}
