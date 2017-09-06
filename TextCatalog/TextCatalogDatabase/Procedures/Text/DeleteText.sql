CREATE PROCEDURE [DeleteText]
	@textId int
AS
	Delete
	From Rating
	Where TextId = @textId;
	Delete
	From TagToText
	Where TextId = @textId;
	Delete
	From Text
	Where TextId = @textId