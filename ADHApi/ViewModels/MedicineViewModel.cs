using FluentValidation;

namespace ADHApi.ViewModels
{
    public class MedicineViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contraindication { get; set; }
        public string RecommendedDose { get; set; }
    }
    public class MedicineViewModelVlidation : AbstractValidator<MedicineViewModel>
    {
        public MedicineViewModelVlidation()
        {
            RuleFor(x => x.Name).NotEmpty().Length(5, 128);
            RuleFor(x => x.Description).NotEmpty().Length(5, 1000);
            RuleFor(x => x.Contraindication).NotEmpty().Length(5, 1000);
            RuleFor(x => x.RecommendedDose).NotEmpty().Length(5, 256);
        }
    }
}
