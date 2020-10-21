USE [ADH_medical_system]
GO
/****** Object:  StoredProcedure [dbo].[spTestRequests_DeleteRequest]    Script Date: 2020-10-21 8:04:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dbo
-- Create date: 2020-10-16
-- Description:	Delete request only if there is no results 
-- =============================================
ALTER PROCEDURE [dbo].[spTestRequests_DeleteRequest]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

   DELETE FROM [dbo].[TestRequests]
      WHERE Id =@Id AND [TestRequests].TesterId IS NULL

END
