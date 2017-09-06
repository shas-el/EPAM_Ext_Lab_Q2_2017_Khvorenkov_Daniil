USE [TextDB]
GO
SET IDENTITY_INSERT [dbo].[Section] ON 
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (1, N'TopSection', NULL)
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (2, N'Section1', 1)
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (3, N'Subsection11', 2)
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (4, N'Subsection12', 2)
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (5, N'Section2', 1)
GO
INSERT [dbo].[Section] ([SectionId], [SectionName], [ParentSectionId]) VALUES (6, N'Section3', 1)
GO
SET IDENTITY_INSERT [dbo].[Section] OFF
GO
