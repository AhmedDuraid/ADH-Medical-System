-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	delete user by Id
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_DeleteUser] 
	@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM AssignedMedicines
      WHERE AssignedMedicines.PatientId = @UserId OR AssignedMedicines.AddedBy = @UserId

	DELETE FROM Articles
		WHERE Articles.UserId = @UserId;

	DELETE FROM AssignedPlan
		WHERE AssignedPlan.PatientId = @UserId OR AssignedPlan.AddedBy = @UserId;

	DELETE FROM Feedback
		WHERE Feedback.ReadedBy = @UserId ;

	DELETE FROM PatientProgress
		WHERE PatientProgress.PatientId= @UserId OR PatientProgress.AddedBy=@UserId;

	DELETE FROM PatientNote
		WHERE PatientNote.PatientId = @UserId OR PatientNote.AddedBy= @UserId;

	DELETE FROM TestRequests
		WHERE TestRequests.PatientId = @UserId OR TestRequests.CreatorID= @UserId OR TestRequests.TesterId = @UserId

	DELETE FROM UserRoles
		WHERE UserRoles.UserId = @UserId;
 
	DELETE FROM [dbo].[Users]
		WHERE Id = @UserId
	 
END
