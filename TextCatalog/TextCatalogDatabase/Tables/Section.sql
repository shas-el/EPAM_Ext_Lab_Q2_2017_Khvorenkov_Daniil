CREATE TABLE [dbo].[Section]
(
	[SectionId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [SectionName] NVARCHAR(50) NOT NULL, 
    [ParentSectionId] INT NULL, 
    CONSTRAINT [FK_Section_ToSection] FOREIGN KEY ([ParentSectionId]) REFERENCES [Section]([SectionId])
)
