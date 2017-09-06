CREATE TABLE [dbo].[Rating]
(
    [UserId] INT NOT NULL, 
    [TextId] INT NOT NULL, 
	CONSTRAINT [PK_Rating] PRIMARY KEY ([UserId], [TextId]),
    [Positive] BIT NOT NULL, 
    [RatingDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Rating_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Rating_ToText] FOREIGN KEY ([TextId]) REFERENCES [Text]([TextId])
)
