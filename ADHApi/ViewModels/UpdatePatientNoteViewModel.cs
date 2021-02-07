using FluentValidation;

namespace ADHApi.ViewModels
{
    public class UpdatePatientNoteViewModel
    {
        public string Body { get; set; }
        public bool ShowToPatient { get; set; }
    }

    public class UpdatePatientNoteValidation : AbstractValidator<UpdatePatientNoteViewModel>
    {
        public UpdatePatientNoteValidation()
        {
            RuleFor(x => x.Body).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ShowToPatient).NotEmpty();
        }
    }
}
