
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	delete artilce by passed Id
-- =============================================
ALTER PROCEDURE [dbo].[spArticles_DeleteArticle]
	@ArticleId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [dbo].[Articles]
		  WHERE Id = @ArticleId
END
