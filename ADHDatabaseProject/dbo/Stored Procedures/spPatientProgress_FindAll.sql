-- =============================================
-- Author:		dbo
-- Create date: 2020-10-17
-- Description:	return all patient progress
-- =============================================
CREATE PROCEDURE spPatientProgress_FindAll 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Progress.Id
      ,[Date]
      ,[Weight]
      ,[BMI]
      ,[PatientId]
	  ,Patient.FirstName AS PatientFirstName
	  ,Patient.LastName AS PatientLastName
      ,[AddedBy]
	  ,Doctor.FirstName AS DoctorFirstName
	  ,Doctor.LastName AS DoctorLastName
  FROM [dbo].[PatientProgress] AS Progress
  JOIN Users Patient ON Patient.Id = Progress.PatientId
  JOIN Users Doctor ON Doctor.Id = Progress.AddedBy
END
