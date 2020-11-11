using FluentValidation;

namespace ADHUIServer.Models.Users
{
    public class RegisterUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RoleType { get; set; }
    }

    public class RegisterValidation : AbstractValidator<RegisterUserModel>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).EmailAddress().Length(10, 100).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).Equal(x => x.ConfirmPassword);
            RuleFor(x => x.ConfirmPassword).MinimumLength(6).NotEmpty();
            RuleFor(x => x.FirstName).Length(3, 30).NotEmpty();
            RuleFor(x => x.LastName).Length(3, 30).NotEmpty();
            RuleFor(x => x.UserName).MinimumLength(6).NotEmpty();
            RuleFor(x => x.RoleType).Length(3, 30).NotEmpty();
        }
    }
}
