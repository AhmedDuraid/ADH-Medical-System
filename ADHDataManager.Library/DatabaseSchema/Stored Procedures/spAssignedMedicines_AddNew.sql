
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAssignedMedicines_AddNew

	@Id nvarchar(128)
	,@PatientId nvarchar(128)
	,@MedicineId nvarchar(128)
	,@AddedBy nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[AassignedMedicines]
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
GO
