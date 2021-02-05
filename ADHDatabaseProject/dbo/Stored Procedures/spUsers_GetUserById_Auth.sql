-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return user from user table, Auth system
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_GetUserById_Auth] 
	@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		Id
		,UserName
		,Email
		,EmailConfirmed
		,PasswordHash
		,NormalizedUserName
		,AuthenticationType
		,IsAuthenticated 
	FROM Users
	where Id = @UserId
END
