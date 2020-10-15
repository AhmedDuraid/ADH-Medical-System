USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spUsers_FindUserByID]    Script Date: 2020-10-15 1:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return user information
-- =============================================
ALTER PROCEDURE [dbo].[spUsers_FindUserByID] 
	@UserId nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[UserName]
      ,[Email]
      ,[EmailConfirmed]
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
  WHERE Id = @UserId
END
