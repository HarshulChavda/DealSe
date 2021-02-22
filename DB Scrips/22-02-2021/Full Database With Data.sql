USE [DealSe]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](15) NOT NULL,
	[Logo] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[PasswordResetToken] [uniqueidentifier] NULL,
	[InvalidLoginAttemptCount] [tinyint] NOT NULL,
	[LastInvalidLoginAttemptDate] [datetime] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailTemplate]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplate](
	[EmailTemplateId] [int] IDENTITY(1,1) NOT NULL,
	[EmailTemplateName] [nvarchar](50) NOT NULL,
	[EmailTemplateSubject] [nvarchar](100) NOT NULL,
	[EmailTemplateBody] [nvarchar](max) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmailTemplate] PRIMARY KEY CLUSTERED 
(
	[EmailTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[SortDescription] [nvarchar](500) NOT NULL,
	[LongDescription] [nvarchar](max) NULL,
	[TermsAndConditions] [nvarchar](max) NULL,
	[LimitedTimeOffer] [bit] NOT NULL,
	[Approved] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[UserRedeemLimit] [int] NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferBanner]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferBanner](
	[OfferBannerId] [int] IDENTITY(1,1) NOT NULL,
	[OfferId] [int] NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[Approved] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_OfferBanner] PRIMARY KEY CLUSTERED 
(
	[OfferBannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteSetting]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteSetting](
	[SiteSettingId] [int] IDENTITY(1,1) NOT NULL,
	[SiteSettingName] [nvarchar](50) NOT NULL,
	[SiteSettingType] [varchar](10) NOT NULL,
	[SiteSettingValue] [nvarchar](max) NULL,
	[EnforceValidation] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_SiteSetting] PRIMARY KEY CLUSTERED 
(
	[SiteSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[StoreTypeId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Logo] [nvarchar](50) NULL,
	[RegistrationType] [tinyint] NOT NULL,
	[GoogleId] [nvarchar](max) NULL,
	[FacebookId] [nvarchar](max) NULL,
	[MobileNo1] [nvarchar](10) NULL,
	[MobileNo2] [nvarchar](10) NULL,
	[Address1] [nvarchar](500) NOT NULL,
	[Address2] [nvarchar](500) NULL,
	[Address3] [nvarchar](500) NULL,
	[Latitude] [decimal](11, 8) NOT NULL,
	[Longitude] [decimal](11, 8) NOT NULL,
	[OwnerName] [nvarchar](100) NOT NULL,
	[OwnerMobileNo] [nvarchar](10) NOT NULL,
	[About] [nvarchar](2000) NULL,
	[Approved] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreSuggestedOffer]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreSuggestedOffer](
	[StoreSuggestedOfferId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[SuggestedOfferId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[OfferImage] [nchar](10) NULL,
 CONSTRAINT [PK_StoreSuggestedOffer] PRIMARY KEY CLUSTERED 
(
	[StoreSuggestedOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreTime]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreTime](
	[StoreTimeId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[MondayOpenHours] [nvarchar](10) NULL,
	[MondayCloseHours] [nvarchar](10) NULL,
	[TuesdayOpenHours] [nvarchar](10) NULL,
	[TuesdayCloseHours] [nvarchar](10) NULL,
	[WednesdayOpenHours] [nvarchar](10) NULL,
	[WednesdayCloseHours] [nvarchar](10) NULL,
	[ThursdayOpenHours] [nvarchar](10) NULL,
	[ThursdayCloseHours] [nvarchar](10) NULL,
	[FridayOpenHours] [nvarchar](10) NULL,
	[FridayCloseHours] [nvarchar](10) NULL,
	[SaturdayOpenHours] [nvarchar](10) NULL,
	[SaturdayCloseHours] [nvarchar](10) NULL,
	[SundayOpenHours] [nvarchar](10) NULL,
	[SundayCloseHours] [nvarchar](10) NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_StoreTime] PRIMARY KEY CLUSTERED 
(
	[StoreTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreType]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreType](
	[StoreTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_StoreType] PRIMARY KEY CLUSTERED 
(
	[StoreTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuggestedOffer]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuggestedOffer](
	[SuggestedOfferId] [int] IDENTITY(1,1) NOT NULL,
	[StoreTypeId] [int] NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SortDescription] [nvarchar](500) NOT NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[OfferImage] [nchar](10) NULL,
 CONSTRAINT [PK_SuggestedOffer] PRIMARY KEY CLUSTERED 
(
	[SuggestedOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[RegistrationType] [tinyint] NOT NULL,
	[GoogleId] [nvarchar](max) NULL,
	[FacebookId] [nvarchar](max) NULL,
	[Photo] [nvarchar](50) NULL,
	[Gender] [tinyint] NULL,
	[MaritalStatus] [tinyint] NULL,
	[DOB] [datetime] NULL,
	[Address1] [nvarchar](500) NULL,
	[Address2] [nvarchar](500) NULL,
	[Address3] [nvarchar](500) NULL,
	[Approved] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[DeviceID] [varchar](max) NULL,
	[DeviceType] [varchar](max) NULL,
	[Latitude] [decimal](18, 10) NULL,
	[Longitude] [decimal](18, 10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUsedOffer]    Script Date: 22-02-2021 00:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUsedOffer](
	[UserUsedOfferId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OfferId] [int] NOT NULL,
	[CouponCode] [nvarchar](50) NOT NULL,
	[Latitude] [decimal](11, 8) NULL,
	[Longitude] [decimal](11, 8) NULL,
	[IsRedeem] [bit] NOT NULL,
	[RedeemDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_UserUsedOffer] PRIMARY KEY CLUSTERED 
(
	[UserUsedOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 
GO
INSERT [dbo].[Admin] ([AdminId], [FirstName], [LastName], [Email], [MobileNo], [Logo], [Password], [AddedDate], [UpdatedDate], [PasswordResetToken], [InvalidLoginAttemptCount], [LastInvalidLoginAttemptDate]) VALUES (1, N'Admin', N'User', N'harshul.codeart@gmail.com', N'9876543210', N'637456629353103631.png', N'7f2765757d527eaeeb14fb706039bac7', CAST(N'2020-12-14T00:00:00.000' AS DateTime), CAST(N'2021-01-08T00:37:38.780' AS DateTime), N'c4c8e12a-8fa1-4cb0-a19a-18fbf1cc72e4', 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (1, 1, N'CTM', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (2, 1, N'Maninagar', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (3, 1, N'Ramol', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (4, 1, N'Isanpur', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (5, 1, N'Naroda', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (6, 1, N'Jivraj', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (7, 1, N'Shivranjni', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (8, 1, N'Vadaj', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (9, 1, N'Nikol', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (10, 1, N'Khokhra', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (11, 1, N'Amraivadi', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (12, 1, N'Hatkeswar', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (13, 1, N'Shyamal', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (14, 1, N'Iskon', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (15, 1, N'Gota', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (16, 1, N'Bapunagar', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (17, 1, N'Shyam Shikhar', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (18, 1, N'Navarangpura', CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Area] ([AreaId], [CityId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (19, 1, N'Krishnanagar', CAST(N'2021-02-16T00:42:12.000' AS DateTime), CAST(N'2021-02-16T00:43:00.480' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 
GO
INSERT [dbo].[City] ([CityId], [StateId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (1, 1, N'Ahmedabad', CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2021-02-14T04:41:55.680' AS DateTime), 1)
GO
INSERT [dbo].[City] ([CityId], [StateId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (2, 1, N'Rajkot', CAST(N'2021-02-14T04:21:40.363' AS DateTime), CAST(N'2021-02-14T04:41:55.680' AS DateTime), 1)
GO
INSERT [dbo].[City] ([CityId], [StateId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (3, 1, N'Surat', CAST(N'2021-02-14T04:24:43.417' AS DateTime), CAST(N'2021-02-14T04:41:55.680' AS DateTime), 1)
GO
INSERT [dbo].[City] ([CityId], [StateId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (4, 1, N'Gandhinagar', CAST(N'2021-02-14T04:26:15.000' AS DateTime), CAST(N'2021-02-16T00:03:56.660' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([CountryId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (1, N'India', CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2021-01-08T00:46:40.503' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailTemplate] ON 
GO
INSERT [dbo].[EmailTemplate] ([EmailTemplateId], [EmailTemplateName], [EmailTemplateSubject], [EmailTemplateBody], [AddedDate], [UpdatedDate]) VALUES (1, N'ForgotPassword', N'Forgot Password', N'<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Hi {{NAME}},</p>
<p>Reset your password&nbsp;by clicking the following link:</p>
<p>{{VERIFICATIONLINK}}</p>
</body>
</html>', CAST(N'2021-01-08T00:48:33.000' AS DateTime), CAST(N'2021-01-08T00:48:37.683' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EmailTemplate] OFF
GO
SET IDENTITY_INSERT [dbo].[Offer] ON 
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (2, 2, N'Get 50% Off ', CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2021-12-22T00:00:00.000' AS DateTime), N'Get 50% Off ', N'Get 50% Off ', N'Get 50% Off ', 0, 1, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (3, 2, N'Get 1 On 1', CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2021-12-22T00:00:00.000' AS DateTime), N'Get 1 On 1', N'Get 1 On 1', N'Get 1 On 1', 0, 1, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (6, 2, N'Get 40% Off', CAST(N'2020-12-26T00:00:00.000' AS DateTime), CAST(N'2021-12-26T00:00:00.000' AS DateTime), N'Get 40% Off', N'Get 40% Off', N'Get 40% Off', 0, 0, 1, CAST(N'2020-12-26T00:05:29.367' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (8, 4, N'string', CAST(N'2021-02-13T21:10:08.440' AS DateTime), CAST(N'2021-02-13T21:10:08.440' AS DateTime), N'string', N'string', N'string', 0, 0, 1, CAST(N'2021-02-14T02:41:26.487' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1007, 4, N'string', CAST(N'2021-02-17T18:23:41.277' AS DateTime), CAST(N'2021-02-17T18:23:41.277' AS DateTime), N'string', N'string', N'string', 0, 0, 1, CAST(N'2021-02-17T23:53:51.190' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1008, 4, N'string', CAST(N'2021-02-17T19:47:50.030' AS DateTime), CAST(N'2021-02-17T19:47:50.030' AS DateTime), N'string', N'string', N'string', 0, 0, 1, CAST(N'2021-02-18T01:17:59.697' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1015, 4, N'Sai First Offer', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'24% Discount', N'Offer From Mobile', N'This is term and condition', 0, 0, 1, CAST(N'2021-02-18T01:38:59.290' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1016, 4, N'Offer Title', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'Offer Description', N'Offer Long Description', N'This is term and condition', 0, 0, 1, CAST(N'2021-02-19T01:01:27.897' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1017, 4, N'Offer Title', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'Offer Description', N'Offer Long Description', N'This is term and condition', 0, 0, 1, CAST(N'2021-02-19T01:05:24.473' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1018, 4, N'Offer Title', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'Offer Description', N'Offer Long Description', N'This is term and condition', 0, 0, 1, CAST(N'2021-02-19T01:09:49.100' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1019, 4, N'Offer Title', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'Offer Description', N'Offer Long Description', N'This is term and condition', 0, 0, 1, CAST(N'2021-02-19T01:12:45.490' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Offer] ([OfferId], [StoreId], [Name], [StartDate], [EndDate], [SortDescription], [LongDescription], [TermsAndConditions], [LimitedTimeOffer], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate], [UserRedeemLimit]) VALUES (1020, 4, N'Today''s Offer', CAST(N'2021-02-15T18:31:30.727' AS DateTime), CAST(N'2021-02-15T18:31:30.727' AS DateTime), N'Get 10% Off', N'Get Flat 10% Off On Your Total Bill Amount', N'123456', 0, 0, 1, CAST(N'2021-02-21T00:20:16.147' AS DateTime), NULL, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Offer] OFF
GO
SET IDENTITY_INSERT [dbo].[OfferBanner] ON 
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1, 6, N'637445380484734528.jpg', 0, 1, CAST(N'2020-12-26T00:07:36.140' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (2, 8, N'637488673043325638.pdf', 0, 1, CAST(N'2021-02-14T02:41:44.350' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1003, 1015, N'637492900335798736.png', 0, 1, CAST(N'2021-02-19T00:07:13.583' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1004, 1016, N'637492932881944283.jpg', 0, 1, CAST(N'2021-02-19T01:01:28.197' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1005, 1017, N'637492935300046545.jpg', 0, 1, CAST(N'2021-02-19T01:05:30.007' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1006, 1018, N'637492937894641327.jpg', 0, 1, CAST(N'2021-02-19T01:09:49.467' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1007, 1019, N'637492939655320882.jpg', 0, 1, CAST(N'2021-02-19T01:12:45.533' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1008, 1019, N'637492939655771595.jpg', 0, 1, CAST(N'2021-02-19T01:12:45.577' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1009, 1019, N'637492939656301080.jpg', 0, 1, CAST(N'2021-02-19T01:12:45.630' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1010, 1019, N'637492939656675169.jpg', 0, 1, CAST(N'2021-02-19T01:12:45.677' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1011, 1020, N'637494636164849213.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.487' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1012, 1020, N'637494636165241642.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.523' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1013, 1020, N'637494636165425255.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.543' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1014, 1020, N'637494636165630933.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.563' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1015, 1020, N'637494636165817620.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.583' AS DateTime), 0, NULL)
GO
INSERT [dbo].[OfferBanner] ([OfferBannerId], [OfferId], [Image], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1016, 1020, N'637494636165999545.jpg', 0, 1, CAST(N'2021-02-21T00:20:16.600' AS DateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[OfferBanner] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteSetting] ON 
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (1, N'SMTPHost', N'1', N'smtpout.asia.secureserver.net', 1, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2020-04-06T19:30:30.323' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (2, N'SMTPPort', N'4', N'3535', 1, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2020-04-06T19:30:39.737' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (3, N'SMTPEmail', N'3', N'support@codearts.in', 1, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2020-04-06T19:31:01.527' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (4, N'SMTPSenderName', N'1', N'DealSe', 0, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2021-01-08T00:55:05.320' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (5, N'SMTPPassword', N'1', N'Codearts@2017', 0, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2020-04-06T19:31:26.913' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (6, N'SMTPSSL', N'5', N'True', 1, CAST(N'2019-12-28T22:40:32.657' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (7, N'SMTPUser', N'1', N'support@codearts.in', 1, CAST(N'2019-12-28T22:40:32.000' AS DateTime), CAST(N'2020-04-06T19:31:11.993' AS DateTime))
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (8, N'SMTPUseDefaultCredentials', N'5', N'False', 1, CAST(N'2019-12-28T22:40:32.657' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (9, N'IncorrectLoginLockMinutes', N'1', N'30', 1, CAST(N'2020-04-05T20:02:45.230' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (10, N'IncorrectLoginLockAttemptLimit', N'1', N'3', 1, CAST(N'2020-04-05T20:02:45.230' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (11, N'CGST', N'1', N'9.0', 0, CAST(N'2020-05-14T21:52:23.340' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (12, N'OTSSMSAmount', N'4', N'0.75', 1, CAST(N'2020-08-01T12:57:01.330' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (13, N'PromotionalSMS', N'4', N'0.50', 1, CAST(N'2020-08-01T12:57:22.350' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (14, N'PopUpPromotional', N'4', N'1.0', 1, CAST(N'2020-08-01T12:57:46.290' AS DateTime), NULL)
GO
INSERT [dbo].[SiteSetting] ([SiteSettingId], [SiteSettingName], [SiteSettingType], [SiteSettingValue], [EnforceValidation], [AddedDate], [UpdatedDate]) VALUES (15, N'DealSeCommission', N'4', N'5', 1, CAST(N'2020-08-29T00:00:00.000' AS DateTime), CAST(N'2021-01-08T00:55:52.247' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SiteSetting] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([StateId], [CountryId], [Name], [AddedDate], [UpdatedDate], [Active]) VALUES (1, 1, N'Gujrat', CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2021-02-14T04:39:06.517' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Store] ON 
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (2, 1, 1, N'Jai Ambe', N'JaiAmbe@gmail.com', NULL, 3, NULL, NULL, N'9876543210', NULL, N'Test', NULL, NULL, CAST(1.11111111 AS Decimal(11, 8)), CAST(2.22222222 AS Decimal(11, 8)), N'Harshul', N'8460403453', NULL, 1, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (3, 1, 1, N'TEst', N'Test@gmail.com', N'637444464140821552.jpg', 0, NULL, NULL, N'1234567890', N'1234567890', N'67 AVNISH SOCIETY C.T.M CROSS ROAD', N'CTM', NULL, CAST(1.11111111 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), N'HH', N'8460403453', NULL, 0, 1, CAST(N'2020-12-24T22:40:43.010' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (4, 7, 1, N'Hshop', N'harshankmp3@gmail.com', N'', 0, NULL, NULL, NULL, NULL, N'60,Avnish,Ctm  ', NULL, NULL, CAST(72.22465560 AS Decimal(11, 8)), CAST(22.23135600 AS Decimal(11, 8)), N'Harshank Sananse', N'9016871962', NULL, 0, 1, CAST(N'2021-02-14T02:30:29.530' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (1006, 1, 1, N'1', N'1@gmail.com', N'', 0, NULL, NULL, N'999999999', N'999999999', N'1', N'1', N'1', CAST(111.00000000 AS Decimal(11, 8)), CAST(222.00000000 AS Decimal(11, 8)), N'111', N'999999999', N'21', 0, 1, CAST(N'2021-02-18T01:14:18.457' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (1007, 1, 1, N'MontuStore', N'montu@gmail.com', N'637494652370033781.jpeg', 0, NULL, NULL, N'9876543210', NULL, N'Avnish, C.T.M', NULL, NULL, CAST(23.03000000 AS Decimal(11, 8)), CAST(72.26626262 AS Decimal(11, 8)), N'Montu Shontu', N'9016871962', NULL, 0, 1, CAST(N'2021-02-21T00:47:17.010' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (1008, 1, 1, N'MontuStore', N'montu@gmail.com', N'637494654480156229.jpeg', 0, NULL, NULL, N'9876543210', NULL, N'Avnish, C.T.M', NULL, NULL, CAST(23.03000000 AS Decimal(11, 8)), CAST(72.26626262 AS Decimal(11, 8)), N'Montu Shontu', N'9016871962', NULL, 0, 1, CAST(N'2021-02-21T00:50:57.273' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Store] ([StoreId], [StoreTypeId], [AreaId], [Name], [Email], [Logo], [RegistrationType], [GoogleId], [FacebookId], [MobileNo1], [MobileNo2], [Address1], [Address2], [Address3], [Latitude], [Longitude], [OwnerName], [OwnerMobileNo], [About], [Approved], [Active], [AddedDate], [UpdatedDate], [Deleted], [DeletedDate]) VALUES (1009, 2, 1, N'Montu1', N'montu1@gmail.com', N'637494656425632241.png', 0, NULL, NULL, NULL, NULL, N'CTM', NULL, NULL, CAST(23.26656500 AS Decimal(11, 8)), CAST(72.26656000 AS Decimal(11, 8)), N'Montu1', N'9856464656', N'N/A', 0, 1, CAST(N'2021-02-21T00:54:02.577' AS DateTime), NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Store] OFF
GO
SET IDENTITY_INSERT [dbo].[StoreType] ON 
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1, N'Grocerey', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (2, N'Saloon', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (3, N'Restaurant', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (4, N'Electronics', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (5, N'Health', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (6, N'Gifts', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (7, N'Clothing ', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[StoreType] ([StoreTypeId], [Name], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (8, N'Travel', 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[StoreType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [AreaId], [FirstName], [LastName], [MobileNo], [Email], [RegistrationType], [GoogleId], [FacebookId], [Photo], [Gender], [MaritalStatus], [DOB], [Address1], [Address2], [Address3], [Approved], [Active], [AddedDate], [Deleted], [DeletedDate], [DeviceID], [DeviceType], [Latitude], [Longitude]) VALUES (1, 1, N'Harsank', N'Sananse', N'9016871962', N'harsankmp3@gmail.com', 3, NULL, NULL, NULL, 1, 0, NULL, N'CTM', NULL, NULL, 1, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUsedOffer] ON 
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (1, 1, 2, N'xyz123', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (2, 1, 3, N'xyz123', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (3, 1, 2, N'xyz1234', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (4, 1, 2, N'xyz12345', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (5, 1, 2, N'xyz123456', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (6, 1, 2, N'xyz1234567', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[UserUsedOffer] ([UserUsedOfferId], [UserId], [OfferId], [CouponCode], [Latitude], [Longitude], [IsRedeem], [RedeemDate], [Active], [AddedDate], [Deleted], [DeletedDate]) VALUES (7, 1, 2, N'xyz12345678', CAST(2.22222222 AS Decimal(11, 8)), CAST(1.11111111 AS Decimal(11, 8)), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserUsedOffer] OFF
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_InvalidLoginAttemptCount]  DEFAULT ((0)) FOR [InvalidLoginAttemptCount]
GO
ALTER TABLE [dbo].[Offer] ADD  CONSTRAINT [DF_Offer_LimitedTimeOffer]  DEFAULT ((0)) FOR [LimitedTimeOffer]
GO
ALTER TABLE [dbo].[Offer] ADD  CONSTRAINT [DF_Offer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[OfferBanner] ADD  CONSTRAINT [DF_OfferBanner_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Store] ADD  CONSTRAINT [DF_Store_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[StoreSuggestedOffer] ADD  CONSTRAINT [DF_StoreSuggestedOffer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[StoreTime] ADD  CONSTRAINT [DF_StoreTime_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[StoreType] ADD  CONSTRAINT [DF_StoreType_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[SuggestedOffer] ADD  CONSTRAINT [DF_SuggestedOffer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[UserUsedOffer] ADD  CONSTRAINT [DF_UserUsedOffer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_City]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([StoreId])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Store]
GO
ALTER TABLE [dbo].[OfferBanner]  WITH CHECK ADD  CONSTRAINT [FK_OfferBanner_Offer] FOREIGN KEY([OfferId])
REFERENCES [dbo].[Offer] ([OfferId])
GO
ALTER TABLE [dbo].[OfferBanner] CHECK CONSTRAINT [FK_OfferBanner_Offer]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([AreaId])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Area]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_StoreType] FOREIGN KEY([StoreTypeId])
REFERENCES [dbo].[StoreType] ([StoreTypeId])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_StoreType]
GO
ALTER TABLE [dbo].[StoreSuggestedOffer]  WITH CHECK ADD  CONSTRAINT [FK_StoreSuggestedOffer_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([StoreId])
GO
ALTER TABLE [dbo].[StoreSuggestedOffer] CHECK CONSTRAINT [FK_StoreSuggestedOffer_Store]
GO
ALTER TABLE [dbo].[StoreSuggestedOffer]  WITH CHECK ADD  CONSTRAINT [FK_StoreSuggestedOffer_SuggestedOffer] FOREIGN KEY([SuggestedOfferId])
REFERENCES [dbo].[SuggestedOffer] ([SuggestedOfferId])
GO
ALTER TABLE [dbo].[StoreSuggestedOffer] CHECK CONSTRAINT [FK_StoreSuggestedOffer_SuggestedOffer]
GO
ALTER TABLE [dbo].[StoreTime]  WITH CHECK ADD  CONSTRAINT [FK_StoreTime_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([StoreId])
GO
ALTER TABLE [dbo].[StoreTime] CHECK CONSTRAINT [FK_StoreTime_Store]
GO
ALTER TABLE [dbo].[SuggestedOffer]  WITH CHECK ADD  CONSTRAINT [FK_SuggestedOffer_StoreType] FOREIGN KEY([StoreTypeId])
REFERENCES [dbo].[StoreType] ([StoreTypeId])
GO
ALTER TABLE [dbo].[SuggestedOffer] CHECK CONSTRAINT [FK_SuggestedOffer_StoreType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([AreaId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Area]
GO
ALTER TABLE [dbo].[UserUsedOffer]  WITH CHECK ADD  CONSTRAINT [FK_UserUsedOffer_Offer] FOREIGN KEY([OfferId])
REFERENCES [dbo].[Offer] ([OfferId])
GO
ALTER TABLE [dbo].[UserUsedOffer] CHECK CONSTRAINT [FK_UserUsedOffer_Offer]
GO
ALTER TABLE [dbo].[UserUsedOffer]  WITH CHECK ADD  CONSTRAINT [FK_UserUsedOffer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserUsedOffer] CHECK CONSTRAINT [FK_UserUsedOffer_User]
GO
/****** Object:  StoredProcedure [dbo].[GetAllArea]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllArea] 1
CREATE PROCEDURE [dbo].[GetAllArea]
@CityId int
AS
BEGIN

SELECT	A.AreaId,
		A.[Name],
		A.[AddedDate],
		A.[Active]
  FROM Area A
  Inner Join [City] C On C.CityId = A.CityId
  Where C.CityId = @CityId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCity]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllCity] 1
CREATE PROCEDURE [dbo].[GetAllCity]
@StateId int
AS
BEGIN

SELECT 
		C.[CityId],
		Country.[Name] 'CountryName',
		S.[Name] 'StateName',
		C.[Name],
		C.[AddedDate],
		C.[Active]
FROM City C
  Inner Join [State] S On C.StateId = S.StateId
  Inner Join [Country] Country On Country.CountryId = S.CountryId
  Where C.StateId = @StateId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCountry]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllCountry] 
CREATE PROCEDURE [dbo].[GetAllCountry]
AS
BEGIN

SELECT [CountryId]
      ,[Name]
      ,[AddedDate]
	  ,[Active]
  FROM [Country]
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllState]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllState] 1
CREATE PROCEDURE [dbo].[GetAllState]
@CountryId int
AS
BEGIN

SELECT 
	  S.StateId
      ,S.[Name]
      ,S.[AddedDate]
	  ,S.[Active]
  FROM [State] S
  Where S.CountryId = @CountryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStoreType]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllStoreType] 
CREATE PROCEDURE [dbo].[GetAllStoreType]
AS
BEGIN

SELECT [StoreTypeId]
      ,[Name]
      ,[AddedDate]
	  ,[Active]
  FROM [StoreType]
  Where Deleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetNearByPlaces]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetNearByPlaces 6,1,1.11111111,2.22222222,0,0
CREATE PROCEDURE [dbo].[GetNearByPlaces]
@OfferID int,
@CateGoryID int,
@UserLatitude decimal(11,8),
@UserLongitude decimal(11,8),
@PageIndex int,
@PageSize int 
AS
BEGIN

	Declare @NearByPlaces as nvarchar(MAX)='';

	IF (@PageIndex <> 0 and @PageSize <> 0)
		 Begin
			set @NearByPlaces = (Select  (Select 
				O.OfferId as OfferID,
				O.[Name] as Title,
				S.[Logo] as StoreImage,
				S.[Name] as StoreName,
				A.[Name] as AreaName,
				O.SortDescription as ShortDescription,
				O.LongDescription as OfferNote 
				from Offer O
				inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
				inner join StoreType ST on S.StoreTypeId=ST.StoreTypeId and ST.StoreTypeId=@CateGoryID and ST.Deleted=0 and ST.Active=1
				inner join Area A on S.AreaId=A.AreaId and A.Active=1
				where OfferId=@OfferID
				and
				O.Deleted=0 and O.Active=1 and O.Approved=1
				and
				(SELECT 
				Cast(geography::Point(@UserLatitude,@UserLongitude, 4326).STDistance(geography::Point(S.Latitude,S.Longitude, 4326))/1000 As decimal)
				) < 25 
				order by O.AddedDate
				OFFSET @PageSize * (@PageIndex - 1) ROWS
				FETCH NEXT @PageSize ROWS ONLY
				for json PATH
				) as 'NearByPlaces')
		 END
	ELSE
		 Begin
			set @NearByPlaces =	(Select (Select 
				O.OfferId as OfferID,
				O.[Name] as Title,
				S.[Logo] as StoreImage,
				S.[Name] as StoreName,
				A.[Name] as AreaName,
				O.SortDescription as ShortDescription,
				O.LongDescription as OfferNote 
				from Offer O
				inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
				inner join StoreType ST on S.StoreTypeId=ST.StoreTypeId and ST.StoreTypeId=@CateGoryID and ST.Deleted=0 and ST.Active=1
				inner join Area A on S.AreaId=A.AreaId and A.Active=1
				where OfferId=@OfferID
				and
				O.Deleted=0 and O.Active=1 and O.Approved=1
				and
				(SELECT 
				Cast(geography::Point(@UserLatitude,@UserLongitude, 4326).STDistance(geography::Point(S.Latitude,S.Longitude, 4326))/1000 As decimal)
				) < 25 
				for json PATH
				) as 'NearByPlaces')
		 End

		 
		select ROW_NUMBER() OVER (Order By @NearByPlaces) SrNo,
		@NearByPlaces as 'NearByPlaces'
END



GO
/****** Object:  StoredProcedure [dbo].[GetOfferDetails]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetOfferDetails 6
CREATE PROCEDURE [dbo].[GetOfferDetails]
@OfferID int
AS
BEGIN
	
	Select 
	O.OfferId as OfferID,
	O.[Name] as Title,
	S.[Name] as StoreName,
	S.Address1 as StoreAddress,
	O.StartDate as StartDate,
	O.EndDate as EndDate,
	S.MobileNo1 as StoreContact,
	S.OwnerMobileNo as StoreOwnerContact,
	O.SortDescription as ShortDescription,
	S.Latitude as StoreLatitude,
	S.Longitude as StoreLongitude,
	O.TermsAndConditions as TermsAndConditions,
	(select OB.OfferBannerId,[Image] from OfferBanner OB 
	where OB.OfferId=@OfferID and OB.Active=1 and OB.Approved=1 and OB.Deleted=0 for json PATH) as 'OfferImages',
	(select (
		select
			MondayOpenHours,
			MondayCloseHours,
			TuesdayOpenHours,
			TuesdayCloseHours,
			WednesdayOpenHours,
			WednesdayCloseHours,
			ThursdayOpenHours,
			ThursdayCloseHours,
			FridayOpenHours,
			FridayCloseHours,
			SaturdayOpenHours,
			SaturdayCloseHours,
			SundayOpenHours,
			SundayCloseHours 
		from StoreTime ST where ST.Active=1 and ST.Deleted=0 for Json PATH) 
	) as 'StoreTimes'
	from Offer O 
	inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
	where O.OfferId=@OfferID and
	O.Deleted=0 and O.Active=1 and O.Approved=1
END


GO
/****** Object:  StoredProcedure [dbo].[GetOfferListByStoreId]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetOfferListByStoreId 2,1,10
CREATE PROCEDURE [dbo].[GetOfferListByStoreId]
(	
	@StoreId int,
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select *,
	(Select OfferBannerId,Image 'OfferImage' from (
Select Image,OfferBannerId From OfferBanner OB Where OB.Deleted = 0 And Result.OfferId = OB.OfferId) AS jsonresult FOR json auto) 'OfferImagesList'
	From(Select 
	O.OfferId,
	O.[Name] 'Name',
	(Select (convert(varchar, O.StartDate, 106) + ' - ' + convert(varchar, O.EndDate, 106))) 'EffectiveDateRange',
	O.SortDescription,
	O.Active
	From Offer O
	where O.Deleted = 0
	order by O.AddedDate Desc
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY) as Result
	    
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferHistory]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetUserUsedOfferHistory 1
CREATE PROCEDURE [dbo].[GetUserUsedOfferHistory]
(@UserID int,
@PageIndex int,
@PageSize int
)
AS
BEGIN

select * from (Select 
USO.OfferId as OfferID,
O.[Name] as Title,
S.Logo as [Image],
S.[Name] as StoreName,
A.[Name] as AreaName,
S.Address1 as StoreAddress,
O.SortDescription as ShortDescription,
O.LongDescription as OfferNote
from UserUsedOffer USO 
inner join Offer O on USO.OfferId=O.OfferId  and O.Deleted=0  
inner join Store S on O.StoreId=S.StoreId and S.Deleted=0
inner join Area A on S.AreaId=A.AreaId
where USO.Active=1 and USO.IsRedeem=1 and USO.Deleted=0 
order by O.AddedDate Desc
OFFSET @PageSize * (@PageIndex - 1) ROWS
FETCH NEXT @PageSize ROWS ONLY) as Result

END

GO
/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferListByStore]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetUserUsedOfferListByStore 2,1,10
CREATE PROCEDURE [dbo].[GetUserUsedOfferListByStore]
(	
	@StoreId int,
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select 
	UUO.UserUsedOfferId,
	U.FirstName + ' ' + U.LastName 'UserName',
	O.Name 'OfferName',
	UUO.RedeemDate
	from UserUsedOffer UUO
	inner join [User] U on U.UserId = UUO.UserId
	inner join [Offer] O on O.OfferId = UUO.OfferId
	where O.StoreId = @StoreId and UUO.IsRedeem = 1 and UUO.Active = 1 and UUO.Deleted = 0
	order by UUo.AddedDate
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
	    
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAreaStatusByIDs]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAreaStatusByIDs] 
@AreaIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [Area] set Active = 1,UpdatedDate = GetDate()  where AreaId in (Select Item FROM dbo.SplitString(@AreaIds, ','))
end
else
begin
	update [Area] set Active = 0,UpdatedDate = GetDate()  where AreaId in (Select Item FROM dbo.SplitString(@AreaIds, ','))
end
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCityStatusByIDs]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCityStatusByIDs] 
@CityIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [City] set Active = 1,UpdatedDate = GetDate()  where CityId in (Select Item FROM dbo.SplitString(@CityIds, ','))
end
else
begin
	update [City] set Active = 0,UpdatedDate = GetDate()  where CityId in (Select Item FROM dbo.SplitString(@CityIds, ','))
end
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCountryStatusByIDs]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCountryStatusByIDs] 
@CountryIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update Country set Active = 1,UpdatedDate = GetDate()  where CountryId in (Select Item FROM dbo.SplitString(@CountryIds, ','))
end
else
begin
	update Country set Active = 0,UpdatedDate = GetDate()  where CountryId in (Select Item FROM dbo.SplitString(@CountryIds, ','))
end
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStateStatusByIDs]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStateStatusByIDs] 
@StateIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [State] set Active = 1,UpdatedDate = GetDate()  where StateId in (Select Item FROM dbo.SplitString(@StateIds, ','))
end
else
begin
	update [State] set Active = 0,UpdatedDate = GetDate()  where StateId in (Select Item FROM dbo.SplitString(@StateIds, ','))
end
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStoreTypeStatusByIDs]    Script Date: 22-02-2021 00:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStoreTypeStatusByIDs] 
@StoreTypeIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update StoreType set Active = 1 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
else if(@Status = 'InActive')
begin
	update StoreType set Active = 0 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
else
begin
	update StoreType set Deleted = 0 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
END
GO
