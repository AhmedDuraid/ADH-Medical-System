
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	update plan
-- =============================================
CREATE PROCEDURE spPlans_UpdatePlan
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

   UPDATE [dbo].[Plan]
   SET 
      [Day1] = @Day1
      ,[Day2] = @Day2
      ,[Day3] =@Day3
      ,[Day4] = @Day4
      ,[Day5] = @Day5
      ,[Day6] = @Day6
      ,[Day7] = @Day7
      ,[Description] = @Description
      ,[Type] = @Type
 WHERE Id=@Id
END
GO
