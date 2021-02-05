-- =============================================
-- Author:		dbo
-- Create date: 2020-10-21
-- Description:	get article by id
-- =============================================
CREATE PROCEDURE [dbo].[spArticles_FindArticlesById]
	@ArticleId nvarchar(128)
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
  WHERE Articles.Id = @ArticleId;
END
