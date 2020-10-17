
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	update patient by doctor and patient ids
-- =============================================
CREATE PROCEDURE spPatientNote_UpdatePatientByPatientAndDoctorID 
	@PatientId nvarchar(128)
	,@DoctortId nvarchar(128)
	,@Body text
	,@ShowToPatient bit

AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[PatientNote]
   SET 
      [Body] = @Body
      ,[ShowToPatient] = @ShowToPatient
 WHERE PatientId = @PatientId AND AddedBy =@DoctortId
END
GO
