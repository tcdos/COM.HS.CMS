USE [ZS.CMS.Web]
GO
/****** Object:  Table [dbo].[znModule]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znModule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[CssName] [nvarchar](50) NULL,
	[LabelName] [nvarchar](255) NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[ParentID] [int] NULL,
	[Path] [ntext] NULL,
	[Layer] [int] NULL,
	[ActionList] [ntext] NULL,
 CONSTRAINT [PK_znModule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znRoleValue]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znRoleValue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[ModuleID] [int] NULL,
	[ActionList] [nvarchar](255) NULL,
 CONSTRAINT [PK_znRoleValue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znRole]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](255) NULL,
 CONSTRAINT [PK_znRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znUser]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPwd] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Purview] [int] NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_ZS_Manage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[znUserRoleView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znUserRoleView]
AS
SELECT     dbo.znUser.ID AS UserID, dbo.znUser.UserName, dbo.znUser.UserPwd, dbo.znUser.RoleID, dbo.znUser.Purview, dbo.znUser.isCheck, dbo.znRole.RoleName, dbo.znRoleValue.ActionList, 
                      dbo.znModule.ID, dbo.znModule.Title, dbo.znModule.CssName, dbo.znModule.LabelName, dbo.znModule.LinkUrl, dbo.znModule.SortID, dbo.znModule.ParentID, dbo.znModule.Path, 
                      dbo.znModule.Layer
FROM         dbo.znUser LEFT OUTER JOIN
                      dbo.znRole ON dbo.znUser.RoleID = dbo.znRole.ID LEFT OUTER JOIN
                      dbo.znRoleValue ON dbo.znRole.ID = dbo.znRoleValue.RoleID LEFT OUTER JOIN
                      dbo.znModule ON dbo.znRoleValue.ModuleID = dbo.znModule.ID
GO
/****** Object:  Table [dbo].[znCategory]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChannelID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[ParentID] [int] NULL,
	[Path] [ntext] NULL,
	[Layer] [int] NULL,
	[SortID] [int] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[isUrl] [int] NULL,
 CONSTRAINT [PK_znCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znSolution]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znSolution](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[ShortTitle] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[Hits] [int] NULL,
	[IdxPic] [nvarchar](255) NULL,
	[SmallPic] [nvarchar](255) NULL,
	[Summary] [ntext] NULL,
	[Content] [ntext] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[isUrl] [int] NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_znSolution] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znSolutionView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znSolutionView]
AS
SELECT     dbo.znSolution.ID, dbo.znSolution.CategoryID, dbo.znSolution.Title, dbo.znSolution.ShortTitle, dbo.znSolution.SortID, dbo.znSolution.Hits, dbo.znSolution.IdxPic, 
                      dbo.znSolution.SmallPic, dbo.znSolution.Summary, dbo.znSolution.[Content], dbo.znSolution.LinkUrl, dbo.znSolution.isUrl, dbo.znSolution.isTop, 
                      dbo.znSolution.isElite, dbo.znSolution.isCheck, dbo.znSolution.UserName, dbo.znSolution.PostTime, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znSolution LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znSolution.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znProduct]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[ShortTitle] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[Hits] [int] NULL,
	[SmallPic] [nvarchar](255) NULL,
	[Summary] [ntext] NULL,
	[Content] [ntext] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[isUrl] [int] NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZS_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znProductView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znProductView]
AS
SELECT     dbo.znProduct.ID, dbo.znProduct.CategoryID, dbo.znProduct.Title, dbo.znProduct.ShortTitle, dbo.znProduct.SortID, dbo.znProduct.Hits, dbo.znProduct.SmallPic, 
                      dbo.znProduct.Summary, dbo.znProduct.[Content], dbo.znProduct.LinkUrl, dbo.znProduct.isUrl, dbo.znProduct.isTop, dbo.znProduct.isElite, dbo.znProduct.isCheck, 
                      dbo.znProduct.UserName, dbo.znProduct.PostTime, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znProduct LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znProduct.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znPage]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znPage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Content] [ntext] NULL,
	[SortID] [int] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[isUrl] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_znPage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znPageView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znPageView]
AS
SELECT     dbo.znPage.ID, dbo.znPage.CategoryID, dbo.znPage.Title, dbo.znPage.[Content], dbo.znPage.SortID, dbo.znPage.LinkUrl, dbo.znPage.isUrl, dbo.znPage.UserName, 
                      dbo.znPage.PostTime, dbo.znPage.isCheck, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znPage LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znPage.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znHR]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znHR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[LimitNum] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[Salary] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Infor] [ntext] NULL,
	[Request] [ntext] NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZS_HR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znHRView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znHRView]
AS
SELECT     dbo.znHR.ID, dbo.znHR.CategoryID, dbo.znHR.Title, dbo.znHR.LimitNum, dbo.znHR.Address, dbo.znHR.Salary, dbo.znHR.Email, dbo.znHR.Infor, dbo.znHR.Request, dbo.znHR.StartDate, 
                      dbo.znHR.isCheck, dbo.znCategory.Title AS CategoryTitle, dbo.znHR.UserName, dbo.znHR.PostTime, dbo.znHR.isElite, dbo.znHR.EndDate, dbo.znHR.isTop
FROM         dbo.znHR LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znHR.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znDownload]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znDownload](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Source] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[Hits] [int] NULL,
	[SmallPic] [nvarchar](255) NULL,
	[Summary] [ntext] NULL,
	[FileUrl] [nvarchar](255) NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZS_Download] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znDownloadView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znDownloadView]
AS
SELECT     dbo.znDownload.ID, dbo.znDownload.CategoryID, dbo.znDownload.Title, dbo.znDownload.Source, dbo.znDownload.SortID, dbo.znDownload.Hits, 
                      dbo.znDownload.SmallPic, dbo.znDownload.Summary, dbo.znDownload.FileUrl, dbo.znDownload.isTop, dbo.znDownload.isElite, dbo.znDownload.isCheck, 
                      dbo.znDownload.UserName, dbo.znDownload.PostTime, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znDownload LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znDownload.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znArticle]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znArticle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Source] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[Hits] [int] NULL,
	[SmallPic] [nvarchar](255) NULL,
	[Summary] [ntext] NULL,
	[Content] [ntext] NULL,
	[LinkUrl] [nvarchar](50) NULL,
	[isUrl] [int] NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZS_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znArticleView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znArticleView]
AS
SELECT     dbo.znArticle.ID, dbo.znArticle.CategoryID, dbo.znArticle.Title, dbo.znArticle.Source, dbo.znArticle.SortID, dbo.znArticle.Hits, dbo.znArticle.SmallPic, 
                      dbo.znArticle.Summary, dbo.znArticle.[Content], dbo.znArticle.LinkUrl, dbo.znArticle.isUrl, dbo.znArticle.isTop, dbo.znArticle.isElite, dbo.znArticle.isCheck, 
                      dbo.znArticle.UserName, dbo.znArticle.PostTime, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znArticle LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znArticle.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znCase]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znCase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Source] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[Hits] [int] NULL,
	[SmallPic] [nvarchar](255) NULL,
	[Summary] [ntext] NULL,
	[Content] [ntext] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[isUrl] [int] NULL,
	[isTop] [int] NULL,
	[isElite] [int] NULL,
	[isCheck] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_znCase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[znCaseView]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[znCaseView]
AS
SELECT     dbo.znCase.ID, dbo.znCase.CategoryID, dbo.znCase.Title, dbo.znCase.Source, dbo.znCase.SortID, dbo.znCase.Hits, dbo.znCase.SmallPic, dbo.znCase.Summary, 
                      dbo.znCase.[Content], dbo.znCase.LinkUrl, dbo.znCase.isUrl, dbo.znCase.isTop, dbo.znCase.isElite, dbo.znCase.isCheck, dbo.znCase.UserName, 
                      dbo.znCase.PostTime, dbo.znCategory.Title AS CategoryTitle
FROM         dbo.znCase LEFT OUTER JOIN
                      dbo.znCategory ON dbo.znCase.CategoryID = dbo.znCategory.ID
GO
/****** Object:  Table [dbo].[znBanner]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znBanner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[SmallPic] [nvarchar](255) NULL,
	[SortID] [int] NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_znBanner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znFeedback]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znFeedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[Author] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Content] [ntext] NULL,
	[PostIP] [nvarchar](50) NULL,
	[PostTime] [nvarchar](50) NULL,
	[ReplyContent] [ntext] NULL,
	[ReplyUserName] [nvarchar](50) NULL,
	[ReplyTime] [nvarchar](50) NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_ZS_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znLink]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[CategoryID] [int] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[LogoUrl] [nvarchar](255) NULL,
	[LinkNote] [ntext] NULL,
	[SortID] [int] NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_znLink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znLog]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[LoginIP] [nvarchar](50) NULL,
	[LoginTime] [nvarchar](50) NULL,
	[Log] [ntext] NULL,
 CONSTRAINT [PK_ZS_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[znResume]    Script Date: 2021/8/14 13:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[znResume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PositionID] [int] NULL,
	[Author] [nvarchar](50) NULL,
	[Sex] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Resume] [ntext] NULL,
	[PostTime] [nvarchar](50) NULL,
	[isCheck] [int] NULL,
 CONSTRAINT [PK_ZS_Resume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[znModule] ON 

INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (49, N'网站内容', N'zs-module-content', N'ZS.CMS.Content', N'', 0, 0, N',49,', 1, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (50, N'新闻资讯', N'icon-article', N'ZS.CMS.Content.Article', N'', 3, 49, N',49,50,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (51, N'新闻管理', N'icon-tree-i', N'ZS.CMS.Content.Article.Manage', N'article/content.aspx', 0, 50, N',49,50,51,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (52, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Article.Category', N'article/category.aspx', 0, 50, N',49,50,52,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (53, N'产品中心', N'icon-product', N'ZS.CMS.Content.Product', N'', 2, 49, N',49,53,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (54, N'产品管理', N'icon-tree-i', N'ZS.CMS.Content.Product.Manage', N'product/content.aspx', 0, 53, N',49,53,54,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (55, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Product.Category', N'product/category.aspx', 0, 53, N',49,53,55,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (56, N'下载中心', N'icon-download', N'ZS.CMS.Content.Download', N'', 2, 49, N',49,56,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (57, N'下载管理', N'icon-tree-i', N'ZS.CMS.Content.Download.Manage', N'download/content.aspx', 0, 56, N',49,56,57,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (58, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Download.Category', N'download/category.aspx', 0, 56, N',49,56,58,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (59, N'人力资源', N'icon-job', N'ZS.CMS.Content.HR', N'', 0, 49, N',49,59,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (60, N'招聘计划', N'icon-tree-i', N'ZS.CMS.Content.HR.Employ', N'hr/employ.aspx', 0, 59, N',49,59,60,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (61, N'招聘类别', N'icon-tree-i', N'ZS.CMS.Content.HR.Category', N'hr/category.aspx', 0, 59, N',49,59,61,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (62, N'应聘简历', N'icon-tree-i', N'ZS.CMS.Content.HR.Resume', N'hr/resume.aspx', 0, 59, N',49,59,62,', 3, N'View,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (63, N'单页管理', N'icon-article', N'ZS.CMS.Content.Page', N'', 0, 49, N',49,63,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (64, N'内容管理', N'icon-tree-i', N'ZS.CMS.Content.Page.Manage', N'page/content.aspx', 0, 63, N',49,63,64,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (65, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Page.Category', N'page/category.aspx', 0, 63, N',49,63,65,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (66, N'功能插件', N'zs-module-plugin', N'ZS.CMS.Plugin', N'', 0, 0, N',66,', 1, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (67, N'在线留言', N'icon-feedback', N'ZS.CMS.Plugin.Feedback', N'', 0, 66, N',66,67,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (68, N'留言管理', N'icon-tree-i', N'ZS.CMS.Plugin.Feedback.Manage', N'feedback/content.aspx', 0, 67, N',66,67,68,', 3, N'View,Delete,Reply')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (69, N'友情链接', N'icon-link', N'ZS.CMS.Plugin.Link', N'', 0, 66, N',66,69,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (70, N'链接管理', N'icon-tree-i', N'ZS.CMS.Plugin.Link.Manage', N'link/content.aspx', 0, 69, N',66,69,70,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (71, N'系统配置', N'zs-module-config', N'ZS.CMS.Config', N'', 0, 0, N',71,', 1, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (72, N'系统管理', N'icon-system-config', N'ZS.CMS.Config.System', N'', 0, 71, N',71,72,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (73, N'模块管理', N'icon-module-config', N'ZS.CMS.Config.System.Module', N'system/module.aspx', 0, 72, N',71,72,73,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (74, N'角色管理', N'icon-user-config', N'ZS.CMS.Config.System.Role', N'system/role.aspx', 0, 72, N',71,72,74,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (75, N'用户管理', N'icon-user', N'ZS.CMS.Config.System.User', N'system/user.aspx', 0, 72, N',71,72,75,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (76, N'日志管理', N'icon-log-config', N'ZS.CMS.Config.System.Log', N'system/log.aspx', 0, 72, N',71,72,76,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (77, N'配置管理', N'icon-set-config', N'ZS.CMS.Config.System.Set', N'system/set.aspx', 0, 72, N',71,72,77,', 3, N'View,Edit')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (82, N'解决方案', N'icon-data', N'ZS.CMS.Content.Solution', N'', 2, 49, N',49,82,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (83, N'内容管理', N'icon-tree-i', N'ZS.CMS.Content.Solution.Manage', N'solution/content.aspx', 0, 82, N',49,82,83,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (84, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Solution.Category', N'solution/category.aspx', 0, 82, N',49,82,84,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (85, N'典型案例', N'icon-case', N'ZS.CMS.Content.Case', N'', 2, 49, N',49,85,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (86, N'内容管理', N'icon-tree-i', N'ZS.CMS.Content.Case.Manage', N'case/content.aspx', 0, 85, N',49,85,86,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (87, N'类别管理', N'icon-tree-i', N'ZS.CMS.Content.Case.Category', N'case/category.aspx', 0, 85, N',49,85,87,', 3, N'View,Add,Edit,Delete')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (89, N'横幅信息', N'icon-img', N'ZS.CMS.Plugin.Banner', N'', 0, 66, N',66,89,', 2, N'View')
INSERT [dbo].[znModule] ([ID], [Title], [CssName], [LabelName], [LinkUrl], [SortID], [ParentID], [Path], [Layer], [ActionList]) VALUES (90, N'横幅管理', N'icon-tree-i', N'ZS.CMS.Plugin.Banner.Manage', N'banner/content.aspx', 0, 89, N',66,89,90,', 3, N'View,Add,Edit,Delete')
SET IDENTITY_INSERT [dbo].[znModule] OFF
GO
SET IDENTITY_INSERT [dbo].[znUser] ON 

INSERT [dbo].[znUser] ([ID], [UserName], [UserPwd], [RoleID], [Purview], [isCheck]) VALUES (3, N'tcdos', N'61EFC3420B12296F42919E764B5E22FC', 0, 0, 1)
SET IDENTITY_INSERT [dbo].[znUser] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'SortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'Hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'SmallPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'Summary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否外链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'isUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固顶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'isTop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'isElite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znArticle', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'频道ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'ChannelID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'Layer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'SortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否外链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znCategory', @level2type=N'COLUMN',@level2name=N'isUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'SortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'Hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'SmallPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'Summary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下载地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'FileUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固顶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'isTop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'isElite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znDownload', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'MemberID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'Author'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'PostIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'ReplyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'ReplyUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'ReplyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znFeedback', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招聘数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'LimitNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'薪酬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'Salary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'Infor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'要求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'Request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znHR', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Logo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'LogoUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'LinkNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'SortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLink', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLog', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLog', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLog', @level2type=N'COLUMN',@level2name=N'LoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLog', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znLog', @level2type=N'COLUMN',@level2name=N'Log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简短名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'ShortTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'SortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'Hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'SmallPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'Summary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否外链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'isUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固顶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'isTop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'isElite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znProduct', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'PositionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'Author'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'Resume'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znResume', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znRole', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首页图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znSolution', @level2type=N'COLUMN',@level2name=N'IdxPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znUser', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znUser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znUser', @level2type=N'COLUMN',@level2name=N'UserPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znUser', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'znUser', @level2type=N'COLUMN',@level2name=N'isCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znArticle"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 314
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 109
               Left = 274
               Bottom = 340
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znArticleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znArticleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znCase"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 339
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 91
               Left = 250
               Bottom = 298
               Right = 392
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znCaseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znCaseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znDownload"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 285
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 87
               Left = 249
               Bottom = 315
               Right = 391
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znDownloadView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znDownloadView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znHR"
            Begin Extent = 
               Top = 81
               Left = 408
               Bottom = 619
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 139
               Left = 776
               Bottom = 612
               Right = 1028
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znHRView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znHRView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znPage"
            Begin Extent = 
               Top = 59
               Left = 56
               Bottom = 274
               Right = 201
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 148
               Left = 257
               Bottom = 345
               Right = 399
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znPageView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znPageView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[4] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znProduct"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 304
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 48
               Left = 268
               Bottom = 270
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znProductView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znProductView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1[56] 3) )"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 10
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znSolution"
            Begin Extent = 
               Top = 35
               Left = 64
               Bottom = 376
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znCategory"
            Begin Extent = 
               Top = 105
               Left = 252
               Bottom = 322
               Right = 394
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znSolutionView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znSolutionView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "znUser"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 253
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znRole"
            Begin Extent = 
               Top = 6
               Left = 218
               Bottom = 177
               Right = 366
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znRoleValue"
            Begin Extent = 
               Top = 48
               Left = 445
               Bottom = 238
               Right = 587
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "znModule"
            Begin Extent = 
               Top = 35
               Left = 641
               Bottom = 273
               Right = 783
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znUserRoleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'znUserRoleView'
GO
