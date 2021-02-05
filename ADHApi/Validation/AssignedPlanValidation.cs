using ADHApi.Models.AssignedPlan;
using FluentValidation;

namespace ADHApi.Validation
{
    public class AssignedPlanValidation : AbstractValidator<ApiCreateAssignedPlanModel>
    {
        public AssignedPlanValidation()
        {
            RuleFor(x => x.PatientID).NotEmpty();
            RuleFor(x => x.PlanId).NotEmpty();
            RuleFor(x => x.StartOn).NotEmpty();
        }
    }
}
