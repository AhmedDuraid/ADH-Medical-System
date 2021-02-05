-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	return test by doctor Id with patient and doctor information
-- =============================================
CREATE PROCEDURE [spTestRequests_FindAllByDoctorId]
	@DoctorID  nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

   SELECT Request.Id
      ,Request.Date
      ,Request.PatientId
	  ,Patient.FirstName AS PatientFirstName
	  ,Patient.LastName AS PatientLastName
      ,Request.TestId
	  ,LabTests.TestName
	  ,LabTests.[Description]
      ,Request.Result
      ,Request.CreatorID
	  ,Doctor.FirstName AS DoctorFirstName
	  ,Doctor.LastName AS DoctorLastName
  FROM [dbo].[TestRequests] AS Request
  JOIN Users Patient ON Patient.Id = Request.PatientId
  JOIN Users Doctor ON Doctor.Id = Request.CreatorID
  JOIN LabTests ON LabTests.Id = Request.TestId
  WHERE Request.CreatorID = @DoctorID
END
