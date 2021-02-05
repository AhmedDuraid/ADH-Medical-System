-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Update med by ID
-- =============================================
CREATE PROCEDURE spMedicines_UpdateMed 
	@Name nvarchar(128)
	,@Description text
	,@Contraindication text
	,@RecommendedDose nvarchar(256)
	,@MedId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [dbo].[Medicines]
   SET 
      [Name] = @Name
      ,[Description] = @Description
      ,[Contraindication] = @Contraindication
      ,[RecommendedDose] = @RecommendedDose
 WHERE Id = @MedId
END
