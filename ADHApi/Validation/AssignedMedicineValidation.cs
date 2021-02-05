using ADHApi.Models.AssignedMedicine;
using FluentValidation;

namespace ADHApi.Validation
{
    public class AssignedMedicineValidation : AbstractValidator<ApiAddAssignedMedicineModel>
    {
        public AssignedMedicineValidation()
        {
            RuleFor(x => x.DoctoreID).NotEmpty();
            RuleFor(x => x.MedicineId).NotEmpty();
            RuleFor(x => x.PatientId).NotEmpty();
        }
    }
}
