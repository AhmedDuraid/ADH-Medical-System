
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Add new test 
-- =============================================
CREATE PROCEDURE [dbo].spLabTests_AddNewTest
	@TestName nvarchar(128)
	,@Description TEXT
	,@TestId nvarchar(128)

AS
BEGIN

	SET NOCOUNT ON;

   INSERT INTO [dbo].[LabTests]
           ([Id]
           ,[TestName]
           ,[Description]
           )
     VALUES
           (@TestId
           ,@TestName
           ,@Description
           ,GETDATE())
END
