-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spFeedback_FindAllNotReaded]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Feedback.Id
      ,[Titel]
      ,[Name]
      ,Feedback.Email
      ,[Phone]
      ,[FeedbackBody]
      ,[Date]
      ,[HasBeenRead]
      ,[UpdatedDate]
      ,[ReadedBy] AS ReaderId
  FROM [dbo].[Feedback]
  WHERE HasBeenRead = 0;
END
