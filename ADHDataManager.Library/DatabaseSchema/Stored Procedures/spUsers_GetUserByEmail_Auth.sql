
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	return user information using his Email, Auth system 
-- =============================================
ALTER PROCEDURE [dbo].[spUsers_GetUserByEmail_Auth]
	@NormalizedEmail nvarchar (256)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		[UserName]
	  ,[Email]
	  ,[EmailConfirmed]
	  ,[PasswordHash]
	  ,[NormalizedUserName]
	  ,[NormalizedEmail]
	  ,[AuthenticationType]
	  ,[IsAuthenticated]
	  ,[FirstName]
	  ,NormalizedEmail
	  FROM Users WHERE NormalizedEmail = @NormalizedEmail
END
