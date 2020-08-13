USE [MyMusicDb]
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([Id], [ArtistName]) VALUES (1, N'Snarky Puppy')
INSERT [dbo].[Artists] ([Id], [ArtistName]) VALUES (3, N'Imogen Heap')
INSERT [dbo].[Artists] ([Id], [ArtistName]) VALUES (4, N'Prago union')
INSERT [dbo].[Artists] ([Id], [ArtistName]) VALUES (7, N'Frou frou')
SET IDENTITY_INSERT [dbo].[Artists] OFF
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (1, 2019, 1, N'Immigrance')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (2, 2016, 1, N'Culcha Vulcha')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (4, 2016, 1, N'Family Dinner, Vol.2')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (5, 2015, 3, N'Speak for Yourself')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (7, 2014, 3, N'Sparks')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (9, 2009, 3, N'Ellipse')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (10, 1998, 3, N'I megaphone')
INSERT [dbo].[Albums] ([Id], [Year], [ArtistId], [AlbumName]) VALUES (14, 2020, 4, N'Perpetuum promile')
SET IDENTITY_INSERT [dbo].[Albums] OFF
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (1, 0, 1, N'Chonks')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (2, 0, 1, N'Bigly Strictness')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (3, 0, 5, N'Headlock')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (5, 0, 7, N'You know where to find me')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (6, 0, 10, N'Getting scared')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (8, 0, 2, N'Test')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (9, 0, 2, N'test2')
INSERT [dbo].[Songs] ([Id], [BPM], [AlbumId], [SongName]) VALUES (10, 0, 14, N'Psanec')
SET IDENTITY_INSERT [dbo].[Songs] OFF
SET IDENTITY_INSERT [dbo].[LocalUsers] ON 

INSERT [dbo].[LocalUsers] ([Id], [FirstName], [LastName], [Username], [HashedPassword], [Salt]) VALUES (1, N'Test', N'User', N'test@user.net', N'rGFmmdG+q8AcPfXzJptN/xbGOZOYolIVLjGVItb3II5f171RVByKYQVAnWiWVnVG/esKv037e7Mn9rkPec/8Fg==', N'808fc5e6d50248848b159012d1d37362')
SET IDENTITY_INSERT [dbo].[LocalUsers] OFF
