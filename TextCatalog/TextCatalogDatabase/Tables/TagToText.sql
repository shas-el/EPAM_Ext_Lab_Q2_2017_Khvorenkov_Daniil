CREATE TABLE [dbo].[TagToText]
(
	[TagId] INT NOT NULL , 
    [TextId] INT NOT NULL, 
    PRIMARY KEY ([TagId], [TextId]), 
    CONSTRAINT [FK_TagToText_ToTag] FOREIGN KEY ([TagId]) REFERENCES [Tag]([TagId]), 
    CONSTRAINT [FK_TagToText_ToText] FOREIGN KEY ([TextId]) REFERENCES [Text]([TextId])
)
