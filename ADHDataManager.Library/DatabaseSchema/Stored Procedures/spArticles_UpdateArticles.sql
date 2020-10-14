
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	update article by the pass Id
-- =============================================
CREATE PROCEDURE spArticles_UpdateArticles
	@ArticleId nvarchar(128)
	,@Titel nvarchar(256)
	,@Body  text
	,@Show bit
AS
BEGIN

	SET NOCOUNT ON;

   UPDATE [dbo].[Articles]
	SET 
		[Titel] = @Titel
		,[Body] =@Body
		,[LastUpdate] = GETDATE()
		,[Show] = @Show
	WHERE Id = @ArticleId
END
GO
