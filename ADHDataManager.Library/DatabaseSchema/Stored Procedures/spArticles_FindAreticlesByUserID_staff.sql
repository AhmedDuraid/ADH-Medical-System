
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-14
-- Description:	return all articles for given ID
-- =============================================
CREATE PROCEDURE spArticles_FindAreticlesByUserID_staff 
	@UserId nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
  WHERE Articles.UserId = @UserId
END
GO
