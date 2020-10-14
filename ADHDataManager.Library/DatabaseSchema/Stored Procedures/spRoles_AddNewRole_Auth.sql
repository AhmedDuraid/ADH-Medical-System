SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	INSERT INTO Roles (Id,[Name],NormalizedRoleName) VALUES (@RoleID,@RoleName,@NormalizedRoleName);
END
