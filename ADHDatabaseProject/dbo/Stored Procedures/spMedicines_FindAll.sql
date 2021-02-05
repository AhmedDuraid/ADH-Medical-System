-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	return Med data
-- =============================================
CREATE PROCEDURE spMedicines_FindAll
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[contraindication]
      ,[RecommendedDose]
  FROM [dbo].[Medicines]
END
