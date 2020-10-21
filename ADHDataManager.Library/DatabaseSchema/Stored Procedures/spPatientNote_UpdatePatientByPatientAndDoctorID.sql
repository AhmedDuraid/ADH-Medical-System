USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spPatientNote_UpdatePatientByPatientAndDoctorID]    Script Date: 2020-10-21 3:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	update patient by doctor and patient ids
-- =============================================
ALTER PROCEDURE [dbo].[spPatientNote_UpdatePatientByPatientAndDoctorID] 
	@Id nvarchar(128)
	,@Body text
	,@ShowToPatient bit

AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[PatientNote]
   SET 
      [Body] = @Body
      ,[ShowToPatient] = @ShowToPatient
 WHERE Id =@Id
END
