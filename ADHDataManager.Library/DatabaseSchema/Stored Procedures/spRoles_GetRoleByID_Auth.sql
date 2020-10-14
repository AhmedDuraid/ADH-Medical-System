
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return role table for the passed ID
-- =============================================
ALTER PROCEDURE [dbo].[spRoles_GetRoleByID_Auth] 
	@RoleID nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,[Name], NormalizedRoleName
	FROM Roles
	WHERE Id = @RoleID
    
END
