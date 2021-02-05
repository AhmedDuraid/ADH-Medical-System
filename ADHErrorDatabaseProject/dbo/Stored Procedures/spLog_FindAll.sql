-- =============================================
-- Author:		dbo
-- Create date: 2020-10-22
-- Description:	Return All logs
-- =============================================
CREATE PROCEDURE spLog_FindAll

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [Id]
      ,[Date]
      ,[Message]
      ,[StackTrace]
      ,[Source]
  FROM [dbo].[Log]
END
