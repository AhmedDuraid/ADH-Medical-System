
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spArticles_FindArticles

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

END
GO
