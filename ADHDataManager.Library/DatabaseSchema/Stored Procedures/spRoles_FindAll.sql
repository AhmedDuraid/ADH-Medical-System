USE [ADH_medical_system]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
