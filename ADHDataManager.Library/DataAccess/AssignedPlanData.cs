using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedPlanData
    {
        private readonly string ConnectionName = "AHDConnection";

        public List<AssignedPlanModel> GetAssignedPlans()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spPlansAssigned_GetAssignedPlans",
                new { }, ConnectionName);

            return output;
        }

        public List<AssignedPlanModel> GetAssignedPlansByPaitnetID(int patientId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @PatientID = patientId };

            var output = sqlDataAccess.LoadData<AssignedPlanModel, dynamic>("dbo.spPlansAssigned_GetAssignedPlansByPatientID",
                Parameters, ConnectionName);

            return output;
        }

        public void AddAssignedPlan(AssignedPlanModel AssignedPlan)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @PatientID = AssignedPlan.patient_Id,
                @PlanID = AssignedPlan.plan_id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPlansAssigned_AddAssignedPlan",
                Parameters, ConnectionName);
        }
    }
}
