-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	update article by the pass Id
-- =============================================
CREATE PROCEDURE [dbo].[spArticles_UpdateArticles]
	@ArticleId nvarchar(128)
	,@Titel nvarchar(256)
	,@Body  text
	,@Show bit
	,@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

   UPDATE [dbo].[Articles]
	SET 
		[Titel] = @Titel
		,[Body] =@Body
		,[LastUpdate] = GETDATE()
		,[Show] = @Show
	WHERE Id = @ArticleId AND UserId = @UserId
END
