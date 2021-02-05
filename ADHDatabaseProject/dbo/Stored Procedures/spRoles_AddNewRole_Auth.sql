-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	add new role to role table 
-- =============================================
CREATE PROCEDURE [dbo].[spRoles_AddNewRole_Auth] 
	@RoleID nvarchar(128),
	@RoleName nvarchar(256),
	@NormalizedRoleName nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Roles (Id,[Name],NormalizedRoleName) VALUES (@RoleID,@RoleName,@NormalizedRoleName);
END
