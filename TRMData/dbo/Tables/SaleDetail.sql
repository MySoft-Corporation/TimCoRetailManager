CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SaleId] NCHAR(10) NULL, 
    [ProductId] INT NULL, 
    [Quantity] INT NULL, 
    [PurchasePrice] MONEY NULL, 
    [Tax] MONEY NULL
)
