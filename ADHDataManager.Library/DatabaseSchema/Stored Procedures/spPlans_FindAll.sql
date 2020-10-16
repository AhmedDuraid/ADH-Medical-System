
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	return all plans
-- =============================================
CREATE PROCEDURE spPlans_FindAll 
AS
BEGIN
	SET NOCOUNT ON;

   SELECT [Id]
      ,[Day1]
      ,[Day2]
      ,[Day3]
      ,[Day4]
      ,[Day5]
      ,[Day6]
      ,[Day7]
      ,[Description]
      ,[Type]
  FROM [dbo].[Plan]
END
GO
