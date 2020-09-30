using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PlanData
    {
        private readonly string DataConnectionName = "AHDConnection";
        public List<PlanModel> GetPlans()
        {
            SqlDataAccess dataAccess = new SqlDataAccess();

            var output = dataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_GetPlans",
                new { }, DataConnectionName);

            return output;
        }

        public List<PlanModel> GetPlanById(int id)
        {
            SqlDataAccess dataAccess = new SqlDataAccess();
            var Parameters = new { @ID = id };

            var output = dataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_GetPlanByID",
                Parameters, DataConnectionName);

            return output;
        }

        public List<PlanModel> GetPlansByType(string planType)
        {
            SqlDataAccess dataAccess = new SqlDataAccess();
            var Parameters = new { @Type = planType };

            var output = dataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_GetPlanByType",
                Parameters, DataConnectionName);

            return output;
        }

        public void AddPlan(PlanModel plan)
        {
            SqlDataAccess dataAccess = new SqlDataAccess();
            var Parapeters = new
            {
                @Type = plan.plan_type,
                @Day1 = plan.day_1,
                @Day2 = plan.day_2,
                @Day3 = plan.day_3,
                @Day4 = plan.day_4,
                @Day5 = plan.day_5,
                @Day6 = plan.day_6,
                @Day7 = plan.day_7,
                @Description = plan.plan_description
            };

            dataAccess.SaveData<dynamic>("dbo.spPlans_AddPlan",
                Parapeters, DataConnectionName);
        }
    }
}
