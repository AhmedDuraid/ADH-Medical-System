-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Delete request only if there is no results 
-- =============================================
CREATE PROCEDURE [dbo].[spTestRequests_DeleteRequest]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

   DELETE FROM [dbo].[TestRequests]
      WHERE Id =@Id AND [TestRequests].TesterId IS NULL

END
