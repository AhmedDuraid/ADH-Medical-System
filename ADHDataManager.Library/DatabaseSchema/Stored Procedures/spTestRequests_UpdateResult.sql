
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	add results to test
-- =============================================
CREATE PROCEDURE spTestRequests_UpdateResult
	@Id nvarchar(128)
	,@TesterId nvarchar(128)
	,@Results text
AS
BEGIN
	SET NOCOUNT ON;

   UPDATE [dbo].[TestRequests]
   SET
      [Result] = @Results
      ,[ResultDate] = GETDATE()
      ,[TesterId] = @TesterId
 WHERE Id = @Id
END
GO
