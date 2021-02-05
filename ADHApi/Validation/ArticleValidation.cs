using ADHApi.Models.Articles;
using FluentValidation;

namespace ADHApi.Validation
{
    public class ArticleValidation : AbstractValidator<ApiAddArticleModel>
    {
        public ArticleValidation()
        {
            // validate Titel
            RuleFor(x => x.Titel)
                .NotEmpty()
                .Length(10, 100);

            // validate Body
            RuleFor(x => x.Body)
                .NotEmpty()
                .Length(150, 5000);

        }
    }
}
