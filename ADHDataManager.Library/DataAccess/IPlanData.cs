using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IPlanData
    {
        void AddPlan(PlanModel plan);
        void DeletePlan(string id);
        List<PlanModel> GetPlans();
        List<PlanModel> GetPlansByType(string planType);
        void UpdatePlan(PlanModel plan);
    }
}