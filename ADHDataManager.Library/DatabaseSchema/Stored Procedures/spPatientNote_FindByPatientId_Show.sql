
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	return patient notes by patient Id
-- =============================================
CREATE PROCEDURE spPatientNote_FindByPatientId_Show 
	@PatientId nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Note.[Id]
      ,[Date]
      ,[Body]
      ,[PatientId]
	  ,Patient.FirstName AS PatientFirstName
	  ,Patient.LastName AS PatientLastName
      ,[AddedBy]
	  ,Doctor.FirstName AS DoctorFirstName
	  ,Doctor.LastName AS DoctorLastName
      ,[ShowToPatient]
  FROM [dbo].[PatientNote] AS Note
  JOIN Users Patient ON Patient.Id = Note.PatientId
  JOIN Users Doctor ON Doctor.Id = Note.AddedBy
  WHERE PatientId = @PatientId AND ShowToPatient = 1
END
GO
