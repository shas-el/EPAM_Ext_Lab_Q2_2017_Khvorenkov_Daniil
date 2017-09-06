USE [TextDB]
GO
SET IDENTITY_INSERT [dbo].[Text] ON 
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (1, N'Text1', N'Tex1 description', 3, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'3Text1', 1)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (2, N'Text2', N'Text2 description', 5, CAST(N'2017-05-01T00:00:00.000' AS DateTime), N'5Text2', 5)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (3, N'Text3', N'Text3', 9, CAST(N'2017-06-07T00:00:00.000' AS DateTime), N'9Text3', 3)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (5, N'Text4', N'Text4 description', 3, CAST(N'2017-07-05T00:00:00.000' AS DateTime), N'3Text4', 4)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (6, N'Text5', N'Text5 description', 5, CAST(N'2017-08-08T00:00:00.000' AS DateTime), N'5Text5', 1)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (7, N'NewText', N'NewText description', 13, CAST(N'2017-09-06T19:09:06.763' AS DateTime), N'13NewText06.09.2017 19:09:06', 5)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (8, N'fjdnfgn', N'sdnsgngdiongdgdnosdgno', 13, CAST(N'2017-09-06T19:13:06.280' AS DateTime), N'13fjdnfgn06.09.2017 19:13:06', 1)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (9, N'ggg', N'gzdghs', 13, CAST(N'2017-09-06T19:13:11.657' AS DateTime), N'13ggg06.09.2017 19:13:11', 5)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (10, N'fgasasdasda', N';l;;kl;kl', 13, CAST(N'2017-09-06T19:13:20.220' AS DateTime), N'13fgasasdasda06.09.2017 19:13:20', 4)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (11, N'ｍｆｆごｆｇｍのｍ', N'ｄｍｋしｆｊｄｆじょｖｂｊヴぃｂ', 13, CAST(N'2017-09-06T19:13:34.773' AS DateTime), N'13ｍｆｆごｆｇｍのｍ06.09.2017 19:13:34', 6)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (12, N'dfdfdf', N'ddfgdfgdfgfg', 13, CAST(N'2017-09-06T19:13:50.760' AS DateTime), N'13dfdfdf06.09.2017 19:13:50', 1)
GO
INSERT [dbo].[Text] ([TextId], [TextTitle], [TextDescription], [UploaderId], [UploadDate], [FileName], [SectionId]) VALUES (13, N'asdaddasasd', N'aaaastttttttt', 13, CAST(N'2017-09-06T19:13:56.930' AS DateTime), N'13asdaddasasd06.09.2017 19:13:56', 1)
GO
SET IDENTITY_INSERT [dbo].[Text] OFF
GO
