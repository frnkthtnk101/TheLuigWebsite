CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(150) NULL,
	[SubTitle] VARCHAR(150) NULL, 
    [Anchor] VARCHAR(MAX) NULL, 
    [ImagePath] VARCHAR(250) NULL,

)
