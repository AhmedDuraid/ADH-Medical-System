SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	return all the Articles
-- =============================================
CREATE PROCEDURE spArticles_FindAllArticles
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
  FROM [dbo].[Articles]
  JOIN Users ON Users.Id = Articles.UserId
END
GO
