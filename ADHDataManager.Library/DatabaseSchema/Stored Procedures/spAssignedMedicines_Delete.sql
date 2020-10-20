USE [ADH_medical_system]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-20
-- Description:	delete 
-- =============================================
CREATE PROCEDURE [dbo].spAssignedMedicines_Delete
@AssignedId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [dbo].[AssignedMedicines]
	  WHERE Id= @AssignedId
END
