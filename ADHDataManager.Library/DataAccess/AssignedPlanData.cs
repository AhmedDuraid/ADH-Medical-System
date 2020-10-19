using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedPlanData : IAssignedPlanData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public AssignedPlanData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<AssignedPlanModel> GetAssignedPlans()
        {
            var output = _sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindAll", new { });

            return output;
        }


        public List<AssignedPlanModel> GetAssignedPlansByDoctorID(string doctorID)
        {
            var Parameters = new { @DoctorId = doctorID };
            var output = _sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindByAllDoctorId", Parameters);

            return output;
        }

        public List<AssignedPlanModel> GetAssignedPlansByPaitnetID(string patientId)
        {
            var Parameters = new { @PatientID = patientId };
            var output = _sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spAssignedPlan_FindByAllPatientID", Parameters);

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spAssignedPlan_AddNew",
                Parameters);
        }
    }
}
