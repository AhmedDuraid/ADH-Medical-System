﻿using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientProgressData
    {

        private readonly string ConnectionName = "AHDConnection";

        public List<PatientProgressModel> GetPatientProgresses()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_GetProgresses",
                new { }, ConnectionName);
            return output;


        }
        public List<PatientProgressModel> GetPatientProgressesById(int progressID)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @ID = progressID };

            var output = sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_GetProgressByID",
                Parameters, ConnectionName);
            return output;


        }
        public List<PatientProgressModel> GetPatientProgressesByPatientID(int patientID)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @PatientID = patientID };

            var output = sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_GetProgressByPatientID",
                Parameters, ConnectionName);
            return output;


        }
        public void AddProgress(PatientProgressModel progress)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @Weight = progress.weight,
                @BMI = progress.bmi,
                @UserID = progress.user_id,
                @PatientID = progress.patient_Id,
                @AddedBY = progress.added_by
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientProgress_ADDProgress",
                    Parameters, ConnectionName);


        }
    }
}
