using ADHApi.Models.Feedback;
using FluentValidation;

namespace ADHApi.Validation
{
    public class FeedbackValidation : AbstractValidator<ApiCreateFeedbackModel>
    {
        public FeedbackValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .Length(10, 100);
            RuleFor(x => x.Titel)
                .NotEmpty()
                .Length(10, 100);
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(10, 150);
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.FeedbackBody)
                .NotEmpty()
                .Length(50, 500);
        }
    }
}
