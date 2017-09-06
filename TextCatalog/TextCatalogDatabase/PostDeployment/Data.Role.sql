USE [TextDB]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'admin')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'user')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
