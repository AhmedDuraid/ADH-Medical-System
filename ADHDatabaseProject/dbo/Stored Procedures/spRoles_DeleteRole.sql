-- =============================================
-- Author:		dbo
-- Create date: 2020-10-19
-- Description:	DELETE role
-- =============================================
CREATE PROCEDURE [dbo].spRoles_DeleteRole 
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM UserRoles
		WHERE RoleId = @Id

	DELETE FROM [dbo].[Roles]
      WHERE Id = @Id
END
