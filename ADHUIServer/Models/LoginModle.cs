using FluentValidation;


namespace ADHUIServer.Models
{
    public class LoginModle
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginValidation : AbstractValidator<LoginModle>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotNull().Length(6, 120);
            RuleFor(x => x.Password).NotNull().Length(6, 120);
        }

    }
}
