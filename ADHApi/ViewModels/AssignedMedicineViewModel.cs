using FluentValidation;

namespace ADHApi.ViewModels
{
    public class AssignedMedicineViewModel
    {
        public string MedicineId { get; set; }
        public string PatientId { get; set; }
    }

    public class AssignedMedicineValidation : AbstractValidator<AssignedMedicineViewModel>
    {
        public AssignedMedicineValidation()
        {
            RuleFor(x => x.MedicineId).NotEmpty();
            RuleFor(x => x.PatientId).NotEmpty();
        }
    }
}
