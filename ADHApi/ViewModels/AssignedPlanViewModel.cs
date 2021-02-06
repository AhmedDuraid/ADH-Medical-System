using FluentValidation;
using System;

namespace ADHApi.ViewModels
{
    public class AssignedPlanViewModel
    {
        public string PatientID { get; set; }
        public string PlanId { get; set; }
        public DateTime StartOn { get; set; }
    }
    public class AssignedPlanValidation : AbstractValidator<AssignedPlanViewModel>
    {
        public AssignedPlanValidation()
        {
            RuleFor(x => x.PatientID).NotEmpty();
            RuleFor(x => x.PlanId).NotEmpty();
            RuleFor(x => x.StartOn).NotEmpty();
        }
    }
}
