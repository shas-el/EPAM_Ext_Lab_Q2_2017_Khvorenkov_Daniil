CREATE TABLE [dbo].[TagCategory]
(
	[CategoryId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [CategoryName] NVARCHAR(50) NOT NULL UNIQUE
)
