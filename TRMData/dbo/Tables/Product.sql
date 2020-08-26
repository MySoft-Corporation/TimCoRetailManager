CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BarCode] INT NULL, 
    [Name] NCHAR(100) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreateDate] DATETIME2 NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NULL
)
