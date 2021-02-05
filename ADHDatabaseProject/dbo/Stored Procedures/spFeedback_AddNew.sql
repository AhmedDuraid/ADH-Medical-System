-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spFeedback_AddNew]
	@Id nvarchar(128)
	,@Titel nvarchar(128)
	,@Name nvarchar(256)
	,@Email nvarchar(256)
	,@Phone char(20)
	,@FeedbackBody text
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[Feedback]
           ([Id]
           ,[Titel]
           ,[Name]
           ,[Email]
           ,[Phone]
           ,[FeedbackBody])
     VALUES
           (@Id
           ,@Titel
           ,@Name
           ,@Email
           ,@Phone
           ,@FeedbackBody
           )
END
