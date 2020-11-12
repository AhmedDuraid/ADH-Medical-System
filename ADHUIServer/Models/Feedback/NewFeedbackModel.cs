using FluentValidation;

namespace ADHUIServer.Models.Feedback
{
    public class NewFeedbackModel
    {
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackBody { get; set; }
    }

    public class FeedbackValidation : AbstractValidator<NewFeedbackModel>
    {
        public FeedbackValidation()
        {
            RuleFor(x => x.Titel).Length(6, 50).NotEmpty();
            RuleFor(x => x.Name).Length(6, 50).NotEmpty();
            RuleFor(x => x.Email).Length(6, 50).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).Length(8, 13).NotEmpty();
            RuleFor(x => x.FeedbackBody).Length(20, 300).NotEmpty();
        }
    }
}
