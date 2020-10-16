SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	return Med data by medicine name
-- =============================================
CREATE PROCEDURE spMedicines_FindMedByName
	@MedName nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[contraindication]
      ,[RecommendedDose]
  FROM [dbo].[Medicines]
  WHERE [Name] = @MedName
END
GO
