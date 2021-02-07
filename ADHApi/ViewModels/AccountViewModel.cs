using FluentValidation;
using System;

namespace ADHApi.ViewModels
{
    // For updating Account information 
    public class AccountViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
    }

    public class AccountViewModelValidation : AbstractValidator<AccountViewModel>
    {
        public AccountViewModelValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 128);
            RuleFor(x => x.MiddleName).Length(3, 128);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 128);
            RuleFor(x => x.PhoneNumber).MaximumLength(15);
            RuleFor(x => x.Gender).MaximumLength(10);
            RuleFor(x => x.Nationality).MaximumLength(50);
            RuleFor(x => x.Address).MaximumLength(50);
        }
    }
}
