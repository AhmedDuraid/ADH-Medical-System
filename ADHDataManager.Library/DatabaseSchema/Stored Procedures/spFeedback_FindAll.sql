
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	  ,Users.FirstName AS ReaderFirstName
	  ,Users.LastName AS ReaderLastName
  FROM [dbo].[Feedback]
  JOIN Users ON Users.Id = Feedback.ReadedBy
END
GO
