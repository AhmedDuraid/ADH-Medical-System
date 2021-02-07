using FluentValidation;

namespace ADHApi.ViewModels
{
    public class LabTestViewModel
    {
        public string TestName { get; set; }
        public string Description { get; set; }
    }

    public class LabTestValidation : AbstractValidator<LabTestViewModel>
    {
        public LabTestValidation()
        {
            RuleFor(x => x.TestName).NotEmpty().Length(5, 128);
            RuleFor(x => x.Description).NotEmpty().Length(10, 250);
        }
    }
}
