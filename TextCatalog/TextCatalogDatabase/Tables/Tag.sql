CREATE TABLE [dbo].[Tag]
(
	[TagId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TagName] NVARCHAR(50) NOT NULL, 
    [TagDescription] NTEXT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Tag_ToTagCategory] FOREIGN KEY ([CategoryId]) REFERENCES [TagCategory]([CategoryId])
)
