-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Return all lab tests by name 
-- =============================================
CREATE PROCEDURE spLabTests_UpdateTest
	@TestName nvarchar(128)
	,@Description TEXT
	,@TestId nvarchar(128)

AS
BEGIN

	SET NOCOUNT ON;

   UPDATE [dbo].[LabTests]
   SET 
      [TestName] = @TestName
      ,[Description] = @Description
      ,[LastUpdate] =GETDATE()
 WHERE Id = @TestId
END
