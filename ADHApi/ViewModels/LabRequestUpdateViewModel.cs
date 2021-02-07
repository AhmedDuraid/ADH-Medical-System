using FluentValidation;

namespace ADHApi.ViewModels
{
    public class LabRequestUpdateViewModel
    {
        public string Id { get; set; }
        public string Result { get; set; }
    }

    public class LabRequestUpdateValidation : AbstractValidator<LabRequestUpdateViewModel>
    {
        public LabRequestUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Result).NotEmpty().MaximumLength(1000);
        }
    }
}
