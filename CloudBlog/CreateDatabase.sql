CREATE DATABASE [AzureWorkshop]

GO

USE [AzureWorkshop]
GO

--|--------------------------------------------------------------------------------
--| [BlogPostsInsert] - Insert Procedure Script for BlogPosts
--|--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[BlogPostsInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dbo].[BlogPostsInsert]
GO

CREATE PROCEDURE [dbo].[BlogPostsInsert]
(
	@Id int = NULL OUTPUT,
	@Title nvarchar(200),
	@Text nvarchar(MAX),
	@Author nvarchar(200),
	@DateCreated datetime
)
AS
	SET NOCOUNT ON

	INSERT INTO [BlogPosts]
	(
		[Title],
		[Text],
		[Author],
		[DateCreated]
	)
	VALUES
	(
		@Title,
		@Text,
		@Author,
		@DateCreated
	)

	SELECT @Id = SCOPE_IDENTITY();

	RETURN @@Error
GO

--|--------------------------------------------------------------------------------
--| [BlogPostsUpdate] - Update Procedure Script for BlogPosts
--|--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[BlogPostsUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dbo].[BlogPostsUpdate]
GO

CREATE PROCEDURE [dbo].[BlogPostsUpdate]
(
	@Id int,
	@Title nvarchar(200),
	@Text nvarchar(MAX),
	@Author nvarchar(200),
	@DateCreated datetime
)
AS
	SET NOCOUNT ON
	
	UPDATE [BlogPosts]
	SET
		[Title] = @Title,
		[Text] = @Text,
		[Author] = @Author,
		[DateCreated] = @DateCreated
	WHERE 
		[Id] = @Id

	RETURN @@Error
GO

--|--------------------------------------------------------------------------------
--| [BlogPostsDelete] - Update Procedure Script for BlogPosts
--|--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[BlogPostsDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dbo].[BlogPostsDelete]
GO

CREATE PROCEDURE [dbo].[BlogPostsDelete]
(
	@Id int
)
AS
	SET NOCOUNT ON

	DELETE 
	FROM   [BlogPosts]
	WHERE  
		[Id] = @Id

	RETURN @@Error
GO

