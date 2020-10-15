
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	return all the Articles
-- =============================================
ALTER PROCEDURE [dbo].[spArticles_FindArticlesById_shown]
	@ArticleId nvarchar(128),
	@Show bit
AS
BEGIN

	SET NOCOUNT ON;

   SELECT Articles.Id
      ,[Titel]
      ,[Body]
      ,Articles.CreateDate
      ,[LastUpdate]
      ,[Show]
	  ,Users.FirstName
	  ,Users.LastName
	  ,Users.UserName
  FROM [dbo].[Articles]
  JOIN Users ON Users.Id = Articles.UserId
  WHERE Articles.Id = @ArticleId AND Articles.Show = @Show;
END
