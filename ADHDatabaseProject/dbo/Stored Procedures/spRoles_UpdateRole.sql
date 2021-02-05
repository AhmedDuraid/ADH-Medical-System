-- =============================================
-- Author:		dbo
-- Create date: 2020-10-19
-- Description:	Update role by Id
-- =============================================
CREATE PROCEDURE [dbo].spRoles_UpdateRole 
	@Name nvarchar(256)
	,@NormalizedRoleName nvarchar(256)
	,@Id nvarchar (128)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Roles]
	SET [Name] =@Name
		,[NormalizedRoleName] =@NormalizedRoleName 
	WHERE Id= @Id
END
