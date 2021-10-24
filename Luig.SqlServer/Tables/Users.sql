CREATE TABLE [dbo].[Users]
(
	[UserId]       INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserName]     INT NOT NULL,
	[UserPassword] INT NOT NULL,
	[UserRole]     INT NOT NULL
)
