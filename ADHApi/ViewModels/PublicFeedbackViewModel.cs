using FluentValidation;

namespace ADHApi.ViewModels
{
    public class PublicFeedbackViewModel
    {
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackBody { get; set; }
    }

    public class PublicFeedbackValidation : AbstractValidator<PublicFeedbackViewModel>
    {
        public PublicFeedbackValidation()
        {
            RuleFor(x => x.Titel).NotEmpty().Length(10, 100);
            RuleFor(x => x.Name).NotEmpty().Length(10, 256);
            RuleFor(x => x.Email).NotEmpty().Length(10, 256);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
            RuleFor(x => x.FeedbackBody).NotEmpty().Length(100, 500);
        }
    }
}
