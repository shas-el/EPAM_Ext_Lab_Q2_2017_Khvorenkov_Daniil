CREATE PROCEDURE [dbo].[DeleteSection]
	@sectionId int
AS
	Delete
	From Section
	Where SectionId = @sectionId