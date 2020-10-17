SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-17
-- Description:	return patient information by id
-- =============================================
CREATE PROCEDURE spUsersRole_FindPatinetById
	@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
      [UserId]
      ,[UserName]
      ,[Email]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[BirthDate]
      ,[PhoneNumber]
      ,[Gender]
      ,[Nationality]
      ,[Address]
	  ,Roles.[Name] AS RoleName
  FROM [dbo].[UserRoles]
  JOIN Users Patient ON Patient.Id = UserRoles.UserId
  JOIN Roles ON Roles.Id = UserRoles.RoleId
  WHERE Roles.[Name] = 'Patient' AND UserId = @UserId


END
GO
