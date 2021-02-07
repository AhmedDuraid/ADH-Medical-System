using FluentValidation;

namespace ADHApi.ViewModels
{
    public class PatientProgressViewModel
    {
        public float Weight { get; set; }
        public float BMI { get; set; }
    }

    public class PatientProgressViewModelValidation : AbstractValidator<PatientProgressViewModel>
    {
        public PatientProgressViewModelValidation()
        {
            RuleFor(x => x.Weight).NotEmpty();
            RuleFor(x => x.BMI).NotEmpty();
        }
    }
}
