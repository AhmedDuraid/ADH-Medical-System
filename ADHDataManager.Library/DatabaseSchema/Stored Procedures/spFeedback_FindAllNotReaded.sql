USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spFeedback_FindAllNotReaded]    Script Date: 2020-10-20 2:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spFeedback_FindAllNotReaded]
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
