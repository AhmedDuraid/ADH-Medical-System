-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	Return role table by the passed Name
-- =============================================
CREATE PROCEDURE [dbo].[spRoles_GetRoleByName_Auth]
	@NormalizedRoleName nvarchar(256) 
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,[Name],NormalizedRoleName
	FROM Roles
	WHERE NormalizedRoleName=@NormalizedRoleName
END
