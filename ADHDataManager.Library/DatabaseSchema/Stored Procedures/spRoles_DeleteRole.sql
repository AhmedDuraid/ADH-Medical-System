USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spRoles_FindAll]    Script Date: 2020-10-19 7:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
