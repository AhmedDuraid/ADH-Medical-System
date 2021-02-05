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
