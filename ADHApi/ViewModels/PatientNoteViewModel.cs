using FluentValidation;

namespace ADHApi.ViewModels
{
    public class PatientNoteViewModel
    {
        public string Body { get; set; }
        public bool ShowToPatient { get; set; }
        public string PatientId { get; set; }
    }
    public class PatientNoteViewModelValidation : AbstractValidator<PatientNoteViewModel>
    {
        public PatientNoteViewModelValidation()
        {
            RuleFor(x => x.Body).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ShowToPatient).NotEmpty();
            RuleFor(x => x.ShowToPatient).NotEmpty();
        }
    }
}
