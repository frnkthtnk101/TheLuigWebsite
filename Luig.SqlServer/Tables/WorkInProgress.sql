CREATE TABLE [dbo].[WorkInProgress]
(
	[WIPId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] NUMERIC(1) NULL, 
    [Message] NVARCHAR(255) NULL,
)
