-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAssignedPlan_FindByAllDoctorId] 
	@DoctorId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT ASPlan.Id
      ,Patient.Id AS PatientID
	  ,Patient.FirstName AS PatientFirstName
	  ,Patient.LastName AS PatientLastName
      ,ASPlan.PlanId
	  ,[Plan].[Type] AS PlanType
      ,Doctor.Id AS DoctorID
	  ,Doctor.FirstName AS DoctorFirstName
	  ,Doctor.LastName AS DoctorLastName
	  ,ASPlan.StartOn
  FROM [dbo].[AssignedPlan] AS ASPlan
  JOIN Users Doctor ON Doctor.Id = ASPlan.AddedBy
  JOIN Users Patient ON Patient.Id = ASPlan.PatientId
  JOIN dbo.[Plan] ON [Plan].Id = ASPlan.PlanId
  WHERE ASPlan.AddedBy = @DoctorId
END