
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return all users from user table 
-- =============================================
ALTER PROCEDURE [dbo].[spUsers_GetUsers] 
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[UserName]
      ,[Email]
      ,[IsAuthenticated]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[BirthDate]
      ,[PhoneNumber]
      ,[Gender]
      ,[Nationality]
      ,[Address]
      ,[CreateDate]
  FROM [dbo].[Users]

END
