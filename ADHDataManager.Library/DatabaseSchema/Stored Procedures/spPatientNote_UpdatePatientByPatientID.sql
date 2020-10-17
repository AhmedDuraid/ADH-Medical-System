
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	update patient by patient ID
-- =============================================
CREATE PROCEDURE spPatientNote_UpdatePatientByPatientID 
	@PatientId nvarchar(128)
	,@Body text
	,@ShowToPatient bit

AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[PatientNote]
   SET 
      [Body] = @Body
      ,[ShowToPatient] = @ShowToPatient
 WHERE PatientId = @PatientId
END
GO
