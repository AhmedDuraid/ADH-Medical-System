using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PlanData
    {
        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess dataAccess;

        public PlanData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(connectionName);
            dataAccess = new SqlDataAccess();
        }

        public List<PlanModel> GetPlans()
        {
            var output = dataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_FindAll",
                new { }, _connectionString);

            return output;
        }

        public List<PlanModel> GetPlansByType(string planType)
        {
            var Parameters = new { @PlanType = planType };

            var output = dataAccess.LoadData<PlanModel, dynamic>("dbo.spPlans_FindByType",
                Parameters, _connectionString);

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

            dataAccess.SaveData<dynamic>("dbo.spPlans_AddNew",
                Parapeters, _connectionString);
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

            dataAccess.SaveData<dynamic>("dbo.spPlans_UpdatePlan",
                Parapeters, _connectionString);
        }

        public void DeletePlan(string id)
        {
            var Parapeters = new { @Id = id };

            dataAccess.SaveData<dynamic>("dbo.spPlans_DeletePlan",
                Parapeters, _connectionString);
        }
    }
}
