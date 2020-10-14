SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	return articles by user Id
-- =============================================
CREATE PROCEDURE spArticles_GetArticlesByUsername 
	@UserName nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT Articles.Id
      ,[Titel]
      ,[Body]
      ,Articles.CreateDate
      ,[LastUpdate]
	  ,Users.FirstName
	  ,Users.LastName
	  ,Users.UserName
  FROM [dbo].[Articles]
  JOIN Users ON Users.Id = Articles.UserId
  WHERE Users.UserName =@UserName AND Articles.Show = 1
END
GO
