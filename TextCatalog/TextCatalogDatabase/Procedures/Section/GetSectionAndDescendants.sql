CREATE PROCEDURE [dbo].[GetSectionAndDescendants]
	@sectionId int
AS
	With cte as 
		(Select s.SectionId
			, s.SectionName
			, s.ParentSectionId
		From Section s
		Where SectionId = @sectionId
		Union All
		Select s.SectionId
			, s.SectionName
			, s.ParentSectionId
		From Section s
		Join cte c on s.ParentSectionId = c.SectionId)
	Select SectionId
		, SectionName
		, ParentSectionId
	From cte
