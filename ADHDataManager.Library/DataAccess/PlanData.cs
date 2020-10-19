using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PlanData : IPlanData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PlanData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<PlanModel> GetPlans()
        {
            var output = _sqlDataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_FindAll", new { });

            return output;
        }

        public List<PlanModel> GetPlansByType(string planType)
        {
            var Parameters = new { @PlanType = planType };

            var output = _sqlDataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_FindByType", Parameters);

            return output;
        }

        public void AddPlan(PlanModel plan)
        {
            var Parapeters = new
            {
                @Id = plan.Id,
                @Type = plan.Type,
                @Day1 = plan.Day1,
                @Day2 = plan.Day2,
                @Day3 = plan.Day3,
                @Day4 = plan.Day4,
                @Day5 = plan.Day5,
                @Day6 = plan.Day6,
                @Day7 = plan.Day7,
                @Description = plan.Description
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPlans_AddNew", Parapeters);
        }

        public void UpdatePlan(PlanModel plan)
        {
            var Parapeters = new
            {
                @Id = plan.Id,
                @Type = plan.Type,
                @Day1 = plan.Day1,
                @Day2 = plan.Day2,
                @Day3 = plan.Day3,
                @Day4 = plan.Day4,
                @Day5 = plan.Day5,
                @Day6 = plan.Day6,
                @Day7 = plan.Day7,
                @Description = plan.Description
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPlans_UpdatePlan", Parapeters);
        }

        public void DeletePlan(string id)
        {
            var Parapeters = new { @Id = id };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPlans_DeletePlan", Parapeters);
        }
    }
}
