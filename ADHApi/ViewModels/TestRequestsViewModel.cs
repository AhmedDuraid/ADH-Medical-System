using FluentValidation;

namespace ADHApi.ViewModels
{
    public class TestRequestsViewModel
    {
        public string PatientId { get; set; }
        public string TestId { get; set; }
    }

    public class TestRequestsValidation : AbstractValidator<TestRequestsViewModel>
    {
        public TestRequestsValidation()
        {
            RuleFor(x => x.PatientId).NotEmpty().MaximumLength(128);
            RuleFor(x => x.TestId).NotEmpty().MaximumLength(128);
        }
    }
}
