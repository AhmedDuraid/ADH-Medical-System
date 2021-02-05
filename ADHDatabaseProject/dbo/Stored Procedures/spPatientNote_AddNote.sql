-- =============================================
-- Author:		dob
-- Create date: 2020-10-17
-- Description:	add new patient note
-- =============================================
CREATE PROCEDURE [dbo].[spPatientNote_AddNote] 
	@Id nvarchar(128)
	,@Body text
	,@PatientId nvarchar(128)
	,@AddedBy nvarchar(128)
	,@ShowToPatient bit
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[PatientNote]
           ([Id]
           ,[Body]
           ,[PatientId]
           ,[AddedBy]
           ,[ShowToPatient])
     VALUES
           (@Id
		   ,@Body
		   ,@PatientId
		   ,@AddedBy
		   ,@ShowToPatient)
END
