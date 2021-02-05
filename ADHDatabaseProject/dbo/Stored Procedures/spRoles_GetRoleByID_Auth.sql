-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return role table for the passed ID
-- =============================================
CREATE PROCEDURE [dbo].[spRoles_GetRoleByID_Auth] 
	@RoleID nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,[Name], NormalizedRoleName
	FROM Roles
	WHERE Id = @RoleID
    
END
