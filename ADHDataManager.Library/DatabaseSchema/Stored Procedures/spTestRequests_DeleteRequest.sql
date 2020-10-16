
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	add results to test
-- =============================================
CREATE PROCEDURE spTestRequests_DeleteRequest
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

   DELETE FROM [dbo].[TestRequests]
      WHERE Id =@Id AND TesterId = Null
END
GO
