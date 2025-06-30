using FluentValidation.Validators;
using FluentValidation;
using SyncDeal.Exceptions;

namespace SyncDeal.Application.UseCases.User.Register
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";
        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_IS_REQUIRED);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_MUST_CONTAIN_8_CHARACTERS);
                return false;
            }

            return true;
        }
    }
}
