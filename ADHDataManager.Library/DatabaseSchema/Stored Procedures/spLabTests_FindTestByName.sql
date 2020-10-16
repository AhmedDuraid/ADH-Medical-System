
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Return all lab tests by name 
-- =============================================
CREATE PROCEDURE spLabTests_FindTestByName
	@TestName nvarchar(128)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT [Id]
      ,[TestName]
      ,[Description]
      ,[LastUpdate]
  FROM [dbo].[LabTests]
  WHERE TestName = @TestName
END
GO
