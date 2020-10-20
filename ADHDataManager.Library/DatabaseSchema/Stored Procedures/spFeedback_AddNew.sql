USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spFeedback_AddNew]    Script Date: 2020-10-20 2:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spFeedback_AddNew]
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
