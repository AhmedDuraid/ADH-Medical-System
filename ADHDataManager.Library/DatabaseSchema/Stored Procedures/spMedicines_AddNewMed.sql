SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Add new med
-- =============================================
CREATE PROCEDURE spMedicines_AddNewMed
	@Id nvarchar
	,@Name nvarchar(128)
	,@Description text
	,@Contraindication text
	,@RecommendedDose nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[Medicines]
           ([Id]
           ,[Name]
           ,[Description]
           ,[Contraindication]
           ,[RecommendedDose])
     VALUES
           (@Id
		   ,@Name
		   ,@Description
		   ,@Contraindication
		   ,@RecommendedDose)
END
GO
