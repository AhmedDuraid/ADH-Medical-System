
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Delete Med
-- =============================================
CREATE PROCEDURE spMedicines_DeleteMed 
	@MedId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM [dbo].[Medicines]
      WHERE Id = @MedId
END
GO
