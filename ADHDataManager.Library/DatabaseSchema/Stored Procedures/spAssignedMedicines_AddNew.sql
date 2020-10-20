USE [ADH_medical_system]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spAssignedMedicines_AddNew]

	@Id nvarchar(128)
	,@PatientId nvarchar(128)
	,@MedicineId nvarchar(128)
	,@AddedBy nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO [dbo].[AssignedMedicines]
           ([Id]
           ,[PatientId]
           ,[MedicineId]
           ,[AddedBy])
     VALUES
           (@Id
		   ,@PatientId
		   ,@MedicineId
		   ,@AddedBy)
END
