USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spArticles_FindArticlesById_shown]    Script Date: 2020-10-21 8:49:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
