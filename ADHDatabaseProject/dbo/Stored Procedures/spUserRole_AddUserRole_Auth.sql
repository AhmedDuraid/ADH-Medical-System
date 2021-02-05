-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	add new user to user role table, Auth system 
-- =============================================
CREATE PROCEDURE [dbo].[spUserRole_AddUserRole_Auth] 
	@UserId nvarchar(256),
	@RoleId nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO UserRoles (UserId,RoleId)
	VALUES (@UserId,@RoleId)
END
