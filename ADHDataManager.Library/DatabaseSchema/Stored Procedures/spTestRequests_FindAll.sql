USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spTestRequests_FindAll]    Script Date: 2020-10-21 7:38:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	return all test requests with patient and doctor information
-- =============================================
ALTER PROCEDURE [dbo].[spTestRequests_FindAll]

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
	  ,Request.ResultDate
	  ,Request.TesterId
  FROM [dbo].[TestRequests] AS Request
  JOIN Users Patient ON Patient.Id = Request.PatientId
  JOIN Users Doctor ON Doctor.Id = Request.CreatorID
  JOIN LabTests ON LabTests.Id = Request.TestId
END
