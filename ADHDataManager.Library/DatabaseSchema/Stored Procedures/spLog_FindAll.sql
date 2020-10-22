
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-22
-- Description:	Return All logs
-- =============================================
CREATE PROCEDURE spLog_FindAll

AS
BEGIN

	SET NOCOUNT ON;

   SELECT [Id]
      ,[Date]
      ,[Message]
      ,[StackTrace]
      ,[Source]
  FROM [dbo].[Log]
END
GO
