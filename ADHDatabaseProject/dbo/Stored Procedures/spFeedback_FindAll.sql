-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spFeedback_FindAll
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [Id]
      ,[Titel]
      ,[Name]
      ,[Email]
      ,[Phone]
      ,[FeedbackBody]
      ,[Date]
      ,[HasBeenRead]
      ,[UpdatedDate]
      ,[ReadedBy]
  FROM [dbo].[Feedback]
END
