USE [ADH_Log]
GO
/****** Object:  StoredProcedure [dbo].[spLog_AddNew]    Script Date: 2020-10-22 6:16:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-22
-- Description:	insert new log
-- =============================================
ALTER PROCEDURE [dbo].[spLog_AddNew]
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
