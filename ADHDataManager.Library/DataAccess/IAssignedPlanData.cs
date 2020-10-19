﻿using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IAssignedPlanData
    {
        void AddAssignedPlan(AssignedPlanModel AssignedPlan);
        List<AssignedPlanModel> GetAssignedPlans();
        List<AssignedPlanModel> GetAssignedPlansByDoctorID(string doctorID);
        List<AssignedPlanModel> GetAssignedPlansByPaitnetID(string patientId);
    }
}