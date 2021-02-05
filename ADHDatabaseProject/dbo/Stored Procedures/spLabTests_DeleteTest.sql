-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	delete test
-- =============================================
CREATE PROCEDURE [dbo].[spLabTests_DeleteTest]
	@TestID nvarchar(128)

AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [dbo].[TestRequests]
      WHERE TestId = @TestID

    DELETE FROM [dbo].[LabTests]
      WHERE Id = @TestID
END
