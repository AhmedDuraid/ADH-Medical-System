using FluentValidation;

namespace ADHApi.ViewModels
{
    public class ArticleViewModel
    {
        public string Titel { get; set; }
        public string Body { get; set; }
        public bool Show { get; set; }
    }
    public class ArticleViewModelValidations : AbstractValidator<ArticleViewModel>
    {
        public ArticleViewModelValidations()
        {
            RuleFor(x => x.Titel).NotEmpty().Length(10, 100);
            RuleFor(x => x.Body).NotEmpty().MinimumLength(500);
        }
    }
}
