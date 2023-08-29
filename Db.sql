USE [AngularJS]
GO
/****** Object:  Table [dbo].[District]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [varchar](100) NULL,
	[DivisionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Division__20EFC6A868019054] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[MaterialId] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nchar](100) NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[PurchaseId] [uniqueidentifier] NOT NULL,
	[SuplierId] [int] NULL,
	[PurchaseStatus] [bit] NULL,
	[PurchaseDate] [date] NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseItem]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseItem](
	[PurchaseItemId] [uniqueidentifier] NOT NULL,
	[PurchaseId] [uniqueidentifier] NULL,
	[MaterialId] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[Tax] [decimal](18, 0) NULL,
 CONSTRAINT [PK_PurchaseItem] PRIMARY KEY CLUSTERED 
(
	[PurchaseItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 8/29/2023 11:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK__UserInfo__1788CC4C76289488] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (1, N'tangail', 1)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (2, N'dhaka', 1)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (3, N'gazipur', 1)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (4, N'Nrganj', 1)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (5, N'valuka', 7)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (6, N'ctg junior', 5)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (7, N'jamalpur', 7)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (8, N'shawrav er ofc', 7)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (9, N'bagura', 9)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (10, N'aam bagan', 9)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (11, N'Bagerhat', 3)
INSERT [dbo].[District] ([DistrictId], [DistrictName], [DivisionId]) VALUES (12, N'Noakhali Sadar', 10)
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Division] ON 

INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (1, N'Dhaka')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (2, N'Barisal')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (3, N'khulna')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (4, N'khulna')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (5, N'chittagong')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (6, N'Rangpur')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (7, N'mymansing')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (8, N'syhlet')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (9, N'rajshahi')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (10, N'nuakhali')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (11, N'faridpur')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (12, N'noton division')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (13, N'as')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (14, N'sd')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (15, N'df')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (16, N'huhh')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (17, N'fus')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (19, N'sesh')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (20, N'1321')
INSERT [dbo].[Division] ([DivisionId], [DivisionName]) VALUES (21, N'123')
SET IDENTITY_INSERT [dbo].[Division] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([MaterialId], [MaterialName]) VALUES (1, N'Red Chilli                                                                                          ')
INSERT [dbo].[Material] ([MaterialId], [MaterialName]) VALUES (2, N'Onion                                                                                               ')
INSERT [dbo].[Material] ([MaterialId], [MaterialName]) VALUES (3, N'Potato                                                                                              ')
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
INSERT [dbo].[Purchase] ([PurchaseId], [SuplierId], [PurchaseStatus], [PurchaseDate]) VALUES (N'877633cf-12f2-4ed1-bf4a-65fac337850b', NULL, NULL, CAST(N'2023-08-29' AS Date))
GO
INSERT [dbo].[PurchaseItem] ([PurchaseItemId], [PurchaseId], [MaterialId], [UnitPrice], [Quantity], [Tax]) VALUES (N'11af1c61-c90d-4a6f-816b-c80fe779c1fd', N'877633cf-12f2-4ed1-bf4a-65fac337850b', 1, CAST(10 AS Decimal(18, 0)), 1, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[PurchaseItem] ([PurchaseItemId], [PurchaseId], [MaterialId], [UnitPrice], [Quantity], [Tax]) VALUES (N'64ed3809-41e1-4d3a-ab45-e0053629cc20', N'877633cf-12f2-4ed1-bf4a-65fac337850b', 2, CAST(20 AS Decimal(18, 0)), 2, CAST(0 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserId], [Phone], [DistrictId], [UserName]) VALUES (23, N'01746034727', 2, N'sakib')
INSERT [dbo].[UserInfo] ([UserId], [Phone], [DistrictId], [UserName]) VALUES (24, N'01400000000', 1, N'sifat BC')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK__District__Divisi__1273C1CD] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([DivisionId])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK__District__Divisi__1273C1CD]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_UserInfo] FOREIGN KEY([SuplierId])
REFERENCES [dbo].[UserInfo] ([UserId])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_UserInfo]
GO
ALTER TABLE [dbo].[PurchaseItem]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItem_Material] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Material] ([MaterialId])
GO
ALTER TABLE [dbo].[PurchaseItem] CHECK CONSTRAINT [FK_PurchaseItem_Material]
GO
ALTER TABLE [dbo].[PurchaseItem]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItem_Purchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[Purchase] ([PurchaseId])
GO
ALTER TABLE [dbo].[PurchaseItem] CHECK CONSTRAINT [FK_PurchaseItem_Purchase]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK__UserInfo__Distri__15502E78] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK__UserInfo__Distri__15502E78]
GO
