
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-17
-- Description:	Add new patient progress
-- =============================================
CREATE PROCEDURE [dbo].[spPatientProgress_AddNew] 
	@Id nvarchar(128)
	,@Weight float
	,@BMI float
	,@PatientId nvarchar(128)
	,@AddedBy nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[PatientProgress]
           ([Id]
           ,[Weight]
           ,[BMI]
           ,[PatientId]
           ,[AddedBy])
     VALUES
           (@Id
		   ,@Weight
		   ,@BMI
		   ,@PatientId
		   ,@AddedBy)
END
