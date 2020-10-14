
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return userRole table by the passed UserId + the role name and user name, Auth system
-- =============================================
CREATE PROCEDURE [dbo].[spUserRole_GetUserRoleById_Auth]
	@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		UserRoles.RoleId,
		UserRoles.UserId,
		Roles.Name,
		Users.UserName
	FROM UserRoles
	JOIN Roles ON Roles.Id = UserRoles.RoleId 
	JOIN Users ON Users.Id = UserRoles.UserId
	WHERE UserRoles.UserId = @UserId;	
END
