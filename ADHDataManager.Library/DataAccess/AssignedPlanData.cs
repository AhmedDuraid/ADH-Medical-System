using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedPlanData
    {
        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        SqlDataAccess sqlDataAccess;
        public AssignedPlanData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(connectionName);
        }


        public List<AssignedPlanModel> GetAssignedPlans()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindAll",
                new { }, _connectionString);

            return output;
        }


        public List<AssignedPlanModel> GetAssignedPlansByDoctorID(string doctorID)
        {
            var Parameters = new { @DoctorId = doctorID };

            var output = sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindByAllDoctorId",
                Parameters, _connectionString);

            return output;
        }

        public List<AssignedPlanModel> GetAssignedPlansByPaitnetID(string patientId)
        {
            var Parameters = new { @PatientID = patientId };

            var output = sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindByAllPatientID",
                Parameters, _connectionString);

            return output;
        }

        public void AddAssignedPlan(AssignedPlanModel AssignedPlan)
        {
            var Parameters = new
            {
                @Id = AssignedPlan.Id,
                @PatientId = AssignedPlan.PatientID,
                @PlanId = AssignedPlan.PlanId,
                @AddedBy = AssignedPlan.DoctorID,
                @StartOn = AssignedPlan.StartOn
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spAssignedPlan_AddNew",
                Parameters, _connectionString);
        }
    }
}
