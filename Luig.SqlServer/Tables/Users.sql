CREATE TABLE [dbo].[Users]
(
	[UserId]       INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserName]     VARCHAR(MAX) NOT NULL,
	[UserPassword] VARCHAR(MAX) NOT NULL,
	[UserRole]     INT NOT NULL
)
