-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	update patient by doctor and patient ids
-- =============================================
CREATE PROCEDURE [dbo].[spPatientNote_UpdatePatientByPatientAndDoctorID] 
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
