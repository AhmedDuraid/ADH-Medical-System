USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spRoles_AddNewRole_Auth]    Script Date: 2020-10-19 6:38:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
