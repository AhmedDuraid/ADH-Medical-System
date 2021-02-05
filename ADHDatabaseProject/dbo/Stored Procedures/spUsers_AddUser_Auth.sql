-- =============================================
-- Author:		dbo
-- Create date: 2020-10-13
-- Description:	adding new user to user table, Auth system 
-- =============================================
CREATE PROCEDURE [dbo].[spUsers_AddUser_Auth] 
	@UserId nvarchar(128)
	,@UserName nvarchar(256)
	,@Email nvarchar (256)
	,@Password nvarchar(MAX),
	@NormalizedUserName nvarchar(256),
	@FirstName nvarchar(128),
	@LastName nvarchar(128),
	@NormalizedEmail nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Users(
		Id
		,UserName
		,Email
		,PasswordHash
		,NormalizedUserName
		,FirstName
		,LastName
		,NormalizedEmail
		)
		VALUES (
		@UserId
		,@UserName
		,@Email
		,@Password
		,@NormalizedUserName
		,@FirstName
		,@LastName
		,@NormalizedEmail
		)
END
