
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Return all lab tests 
-- =============================================
CREATE PROCEDURE spLabTests_FindAll

AS
BEGIN

	SET NOCOUNT ON;

    SELECT [Id]
      ,[TestName]
      ,[Description]
      ,[LastUpdate]
  FROM [dbo].[LabTests]
END
GO
