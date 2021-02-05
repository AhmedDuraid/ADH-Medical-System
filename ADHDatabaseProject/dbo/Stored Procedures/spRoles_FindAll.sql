-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	Reaturn all roles
-- =============================================
CREATE PROCEDURE [dbo].spRoles_FindAll 

AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,[Name] FROM Roles;
END
