USE [TextDB]
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 
GO
INSERT [dbo].[Tag] ([TagId], [TagName], [TagDescription], [CategoryId]) VALUES (1, N'Tag1', N'Tag1 description', 1)
GO
INSERT [dbo].[Tag] ([TagId], [TagName], [TagDescription], [CategoryId]) VALUES (2, N'Tag2', N'Tag2 description', 1)
GO
INSERT [dbo].[Tag] ([TagId], [TagName], [TagDescription], [CategoryId]) VALUES (3, N'Tag3', N'Tag3 description', 2)
GO
INSERT [dbo].[Tag] ([TagId], [TagName], [TagDescription], [CategoryId]) VALUES (4, N'Tag4', N'Tag4 description', 3)
GO
INSERT [dbo].[Tag] ([TagId], [TagName], [TagDescription], [CategoryId]) VALUES (5, N'Tag5', N'Tag5 description', 2)
GO
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
