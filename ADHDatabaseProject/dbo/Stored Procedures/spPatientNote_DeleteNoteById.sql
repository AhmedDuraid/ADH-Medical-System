-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	DELETE patient note 
-- =============================================
CREATE PROCEDURE spPatientNote_DeleteNoteById
	@NoteId nvarchar(128)


AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [dbo].[PatientNote]
      WHERE Id = @NoteId
END
