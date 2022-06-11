using FluentValidation;

namespace PdIwtA_1b.ASP.DTOs.Validators
{
    public class AddUserDTOValidator : AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().MinimumLength(2).MaximumLength(50);

        }
    }
}
