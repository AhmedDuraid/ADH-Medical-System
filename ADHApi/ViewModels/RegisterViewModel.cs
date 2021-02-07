using FluentValidation;

namespace ADHApi.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RoleType { get; set; }
    }

    public class RegisterViewModelValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidation()
        {

            RuleFor(x => x.Email).NotEmpty().MaximumLength(256).EmailAddress();

            // TODO Compare password and ConfirmPassword 
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(6);

            RuleFor(x => x.FirstName).NotEmpty().Length(3, 128);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 128);
            RuleFor(x => x.UserName).NotEmpty().Length(10, 256);
        }
    }
}
