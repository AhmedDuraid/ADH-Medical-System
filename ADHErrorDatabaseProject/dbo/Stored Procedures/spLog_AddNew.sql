-- =============================================
-- Author:		dbo
-- Create date: 2020-10-22
-- Description:	insert new log
-- =============================================
CREATE PROCEDURE [dbo].[spLog_AddNew]
	@Message nvarchar(max)
	,@StackTrace nvarchar(max)
	,@Source nvarchar(max)


AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO [dbo].[Log]
           (
           [Message]
           ,[StackTrace]
           ,[Source])
     VALUES
           (@Message
		   ,@StackTrace
		   ,@Source)
END
