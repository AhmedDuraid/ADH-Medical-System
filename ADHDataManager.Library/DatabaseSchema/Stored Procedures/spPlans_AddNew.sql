
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Add new plan
-- =============================================
CREATE PROCEDURE spPlans_AddNew
	@Id nvarchar(128)
	,@Day1 text
	,@Day2 text
	,@Day3 text
	,@Day4 text
	,@Day5 text
	,@Day6 text
	,@Day7 text
	,@Description text
	,@Type nvarchar(125)
AS
BEGIN
	SET NOCOUNT ON;

   INSERT INTO [dbo].[Plan]
           ([Id]
           ,[Day1]
           ,[Day2]
           ,[Day3]
           ,[Day4]
           ,[Day5]
           ,[Day6]
           ,[Day7]
           ,[Description]
           ,[Type])
     VALUES
           (@Id
           ,@Day1
           ,@Day2
           ,@Day3
           ,@Day4
           ,@Day5
           ,@Day6
           ,@Day7
           ,@Description
           ,@Type)
END
GO
