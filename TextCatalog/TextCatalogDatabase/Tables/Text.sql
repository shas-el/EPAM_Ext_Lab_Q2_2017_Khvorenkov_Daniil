CREATE TABLE [dbo].[Text]
(
	[TextId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TextTitle] NVARCHAR(100) NOT NULL, 
	[TextDescription] NVARCHAR(MAX) NOT NULL,
    [UploaderId] INT NOT NULL, 
    [UploadDate] DATETIME NOT NULL, 
    [FileName] NVARCHAR(50) NOT NULL, 
    [SectionId] INT NOT NULL, 
    CONSTRAINT [FK_Text_ToSection] FOREIGN KEY ([SectionId]) REFERENCES [Section]([SectionId])
)
