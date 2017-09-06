CREATE PROCEDURE [dbo].[GetRootSection]
AS
	Select SectionId
		, SectionName
		, ParentSectionId
	From Section
	Where ParentSectionId is Null
