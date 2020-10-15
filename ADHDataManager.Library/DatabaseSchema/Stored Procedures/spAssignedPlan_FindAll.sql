
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAssignedPlan_FindAll 
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
  FROM [dbo].[AssignedPlan] AS ASPlan
  JOIN Users Doctor ON Doctor.Id = ASPlan.AddedBy
  JOIN Users Patient ON Patient.Id = ASPlan.PatientId
  JOIN dbo.[Plan] ON [Plan].Id = ASPlan.PlanId
END
GO
