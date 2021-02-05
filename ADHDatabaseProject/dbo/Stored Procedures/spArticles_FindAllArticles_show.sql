-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	return all the Articles
-- =============================================
CREATE PROCEDURE [dbo].[spArticles_FindAllArticles_show]
@Show bit
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
  WHERE Articles.Show = @Show;
END
