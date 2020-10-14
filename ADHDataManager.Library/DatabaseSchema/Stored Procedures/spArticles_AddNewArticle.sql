SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spArticles_AddNewArticle 
	@Id nvarchar(128)
	,@Titel nvarchar(256)
	,@Body text
	,@UserId nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Articles]
           ([Id]
           ,[Titel]
           ,[Body]
           ,[UserId])
     VALUES
           (
		   @Id
		   ,@Titel
		   ,@Body
		   ,@UserId
		   )
END
GO
