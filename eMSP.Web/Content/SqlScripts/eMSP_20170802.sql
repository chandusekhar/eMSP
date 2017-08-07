USE [eVMS]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoleGroupRoles]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleGroupRoles](
	[RoleGroupId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoleGroupRoles] PRIMARY KEY CLUSTERED 
(
	[RoleGroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleGroups]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleGroups](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoleGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblBranches]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranches](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[BranchName] [nvarchar](500) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[StreetLine1] [nvarchar](500) NULL,
	[StreetLine2] [nvarchar](max) NULL,
	[City] [nvarchar](100) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblComments]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblComments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[ShowToAll] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblComments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCommentUsers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCommentUsers](
	[ID] [bigint] NOT NULL,
	[CommentID] [bigint] NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[IsRead] [bit] NULL,
	[ReadBy] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCommentUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCountries]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountries](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Code] [nchar](10) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCountries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCountryStates]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountryStates](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryID] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Code] [nchar](10) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCountryStates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomerLocationBranches]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerLocationBranches](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[BranchID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCustomerLocationBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[WebSite] [nvarchar](200) NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](100) NULL,
	[LogoPath] [nvarchar](max) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCustomers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomerUsers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerUsers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblCustomerUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblIndustries]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIndustries](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblIndustries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblIndustrySkills]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIndustrySkills](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IndustryID] [bigint] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblIndustrySkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLocations]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLocations](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](500) NOT NULL,
	[StreetLine1] [nvarchar](500) NULL,
	[StreetLine2] [nvarchar](max) NULL,
	[City] [nvarchar](100) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblLocations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMSPCustomers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMSPCustomers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MSPID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblMSPCustomers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMSPDetails]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMSPDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](500) NOT NULL,
	[WebSite] [nvarchar](200) NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](100) NULL,
	[LogoPath] [nvarchar](max) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblMSPDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMSPLocationBranches]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMSPLocationBranches](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MSPID] [bigint] NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[BranchID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblMSPLocationBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMSPUsers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMSPUsers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MSPID] [bigint] NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblMSPUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMSPVacancieTypes]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMSPVacancieTypes](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[MSPID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblMSPVacancieTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSupplier]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplier](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[WebSite] [nvarchar](200) NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](100) NULL,
	[LogoPath] [nvarchar](max) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSupplierLocationBranches]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplierLocationBranches](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierID] [bigint] NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[BranchID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblSupplierLocationBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSupplierUsers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplierUsers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierID] [bigint] NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblSupplierUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUserLocationBranches]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserLocationBranches](
	[ID] [bigint] NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[BranchID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblUserLocationBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUserProfile]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserProfile](
	[UserID] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[UserProfilePhotoPath] [nvarchar](max) NULL,
	[RoleGroupId] [nvarchar](128) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](200) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[ZipCode] [nvarchar](50) NULL,
	[TimezoneID] [int] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblUserProfile] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancies]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancies](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VacancyType] [smallint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[SubmissionDueDate] [datetime] NULL,
	[HiringManager] [nvarchar](128) NOT NULL,
	[ReportingManager] [nvarchar](128) NOT NULL,
	[PositionTitle] [nvarchar](500) NOT NULL,
	[VacancyDescription] [nvarchar](max) NOT NULL,
	[YearOfExperience] [nvarchar](200) NOT NULL,
	[ShowCustomerDetailsToSupplier] [bit] NULL,
	[MinPayRate] [decimal](18, 4) NOT NULL,
	[MaxPayRate] [decimal](18, 4) NOT NULL,
	[TargetPayRate] [decimal](18, 4) NOT NULL,
	[PayRateMarkUp] [decimal](9, 4) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancieSkills]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancieSkills](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VacancyID] [bigint] NOT NULL,
	[SkillID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancieSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancyComments]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancyComments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VacancyID] [bigint] NOT NULL,
	[CommentID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancyComments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancyFiles]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancyFiles](
	[ID] [bigint] NOT NULL,
	[VacancyID] [bigint] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancyFiles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancyLocations]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancyLocations](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VacancyID] [bigint] NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancyLocations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVacancySuppliers]    Script Date: 8/6/2017 2:33:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancySuppliers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VacancyID] [bigint] NOT NULL,
	[SupplierID] [bigint] NOT NULL,
	[IsReleased] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[CreatedUserID] [nvarchar](128) NOT NULL,
	[UpdatedTimestamp] [datetime] NULL,
	[UpdatedUserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_tblVacancySuppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tblBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblBranches_tblLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblLocations] ([ID])
GO
ALTER TABLE [dbo].[tblBranches] CHECK CONSTRAINT [FK_tblBranches_tblLocations]
GO
ALTER TABLE [dbo].[tblCommentUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblCommentUsers_tblComments] FOREIGN KEY([CommentID])
REFERENCES [dbo].[tblComments] ([ID])
GO
ALTER TABLE [dbo].[tblCommentUsers] CHECK CONSTRAINT [FK_tblCommentUsers_tblComments]
GO
ALTER TABLE [dbo].[tblCommentUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblCommentUsers_tblUserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUserProfile] ([UserID])
GO
ALTER TABLE [dbo].[tblCommentUsers] CHECK CONSTRAINT [FK_tblCommentUsers_tblUserProfile]
GO
ALTER TABLE [dbo].[tblCountryStates]  WITH CHECK ADD  CONSTRAINT [FK_tblCountryStates_tblCountries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tblCountries] ([ID])
GO
ALTER TABLE [dbo].[tblCountryStates] CHECK CONSTRAINT [FK_tblCountryStates_tblCountries]
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerLocationBranches_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[tblBranches] ([ID])
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches] CHECK CONSTRAINT [FK_tblCustomerLocationBranches_tblBranches]
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerLocationBranches_tblCustomers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomers] ([ID])
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches] CHECK CONSTRAINT [FK_tblCustomerLocationBranches_tblCustomers]
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerLocationBranches_tblLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblLocations] ([ID])
GO
ALTER TABLE [dbo].[tblCustomerLocationBranches] CHECK CONSTRAINT [FK_tblCustomerLocationBranches_tblLocations]
GO
ALTER TABLE [dbo].[tblCustomerUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerUsers_tblCustomers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomers] ([ID])
GO
ALTER TABLE [dbo].[tblCustomerUsers] CHECK CONSTRAINT [FK_tblCustomerUsers_tblCustomers]
GO
ALTER TABLE [dbo].[tblCustomerUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerUsers_tblUserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUserProfile] ([UserID])
GO
ALTER TABLE [dbo].[tblCustomerUsers] CHECK CONSTRAINT [FK_tblCustomerUsers_tblUserProfile]
GO
ALTER TABLE [dbo].[tblIndustrySkills]  WITH CHECK ADD  CONSTRAINT [FK_tblIndustrySkills_tblIndustries] FOREIGN KEY([IndustryID])
REFERENCES [dbo].[tblIndustries] ([ID])
GO
ALTER TABLE [dbo].[tblIndustrySkills] CHECK CONSTRAINT [FK_tblIndustrySkills_tblIndustries]
GO
ALTER TABLE [dbo].[tblMSPCustomers]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPCustomers_tblCustomers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomers] ([ID])
GO
ALTER TABLE [dbo].[tblMSPCustomers] CHECK CONSTRAINT [FK_tblMSPCustomers_tblCustomers]
GO
ALTER TABLE [dbo].[tblMSPCustomers]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPCustomers_tblMSPDetails] FOREIGN KEY([MSPID])
REFERENCES [dbo].[tblMSPDetails] ([ID])
GO
ALTER TABLE [dbo].[tblMSPCustomers] CHECK CONSTRAINT [FK_tblMSPCustomers_tblMSPDetails]
GO
ALTER TABLE [dbo].[tblMSPLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPLocationBranches_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[tblBranches] ([ID])
GO
ALTER TABLE [dbo].[tblMSPLocationBranches] CHECK CONSTRAINT [FK_tblMSPLocationBranches_tblBranches]
GO
ALTER TABLE [dbo].[tblMSPLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPLocationBranches_tblLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblLocations] ([ID])
GO
ALTER TABLE [dbo].[tblMSPLocationBranches] CHECK CONSTRAINT [FK_tblMSPLocationBranches_tblLocations]
GO
ALTER TABLE [dbo].[tblMSPLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPLocationBranches_tblMSPDetails] FOREIGN KEY([MSPID])
REFERENCES [dbo].[tblMSPDetails] ([ID])
GO
ALTER TABLE [dbo].[tblMSPLocationBranches] CHECK CONSTRAINT [FK_tblMSPLocationBranches_tblMSPDetails]
GO
ALTER TABLE [dbo].[tblMSPUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPUsers_tblMSPDetails] FOREIGN KEY([MSPID])
REFERENCES [dbo].[tblMSPDetails] ([ID])
GO
ALTER TABLE [dbo].[tblMSPUsers] CHECK CONSTRAINT [FK_tblMSPUsers_tblMSPDetails]
GO
ALTER TABLE [dbo].[tblMSPUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPUsers_tblUserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUserProfile] ([UserID])
GO
ALTER TABLE [dbo].[tblMSPUsers] CHECK CONSTRAINT [FK_tblMSPUsers_tblUserProfile]
GO
ALTER TABLE [dbo].[tblMSPVacancieTypes]  WITH CHECK ADD  CONSTRAINT [FK_tblMSPVacancieTypes_tblMSPDetails] FOREIGN KEY([MSPID])
REFERENCES [dbo].[tblMSPDetails] ([ID])
GO
ALTER TABLE [dbo].[tblMSPVacancieTypes] CHECK CONSTRAINT [FK_tblMSPVacancieTypes_tblMSPDetails]
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierLocationBranches_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[tblBranches] ([ID])
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches] CHECK CONSTRAINT [FK_tblSupplierLocationBranches_tblBranches]
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierLocationBranches_tblLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblLocations] ([ID])
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches] CHECK CONSTRAINT [FK_tblSupplierLocationBranches_tblLocations]
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierLocationBranches_tblSupplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[tblSupplier] ([ID])
GO
ALTER TABLE [dbo].[tblSupplierLocationBranches] CHECK CONSTRAINT [FK_tblSupplierLocationBranches_tblSupplier]
GO
ALTER TABLE [dbo].[tblSupplierUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierUsers_tblSupplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[tblSupplier] ([ID])
GO
ALTER TABLE [dbo].[tblSupplierUsers] CHECK CONSTRAINT [FK_tblSupplierUsers_tblSupplier]
GO
ALTER TABLE [dbo].[tblSupplierUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierUsers_tblUserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUserProfile] ([UserID])
GO
ALTER TABLE [dbo].[tblSupplierUsers] CHECK CONSTRAINT [FK_tblSupplierUsers_tblUserProfile]
GO
ALTER TABLE [dbo].[tblUserLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblUserLocationBranches_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[tblBranches] ([ID])
GO
ALTER TABLE [dbo].[tblUserLocationBranches] CHECK CONSTRAINT [FK_tblUserLocationBranches_tblBranches]
GO
ALTER TABLE [dbo].[tblUserLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblUserLocationBranches_tblLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblLocations] ([ID])
GO
ALTER TABLE [dbo].[tblUserLocationBranches] CHECK CONSTRAINT [FK_tblUserLocationBranches_tblLocations]
GO
ALTER TABLE [dbo].[tblUserLocationBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblUserLocationBranches_tblUserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUserProfile] ([UserID])
GO
ALTER TABLE [dbo].[tblUserLocationBranches] CHECK CONSTRAINT [FK_tblUserLocationBranches_tblUserProfile]
GO
ALTER TABLE [dbo].[tblUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_tblUserProfile_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblUserProfile] CHECK CONSTRAINT [FK_tblUserProfile_AspNetUsers]
GO
ALTER TABLE [dbo].[tblVacancies]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancies_tblCustomers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomers] ([ID])
GO
ALTER TABLE [dbo].[tblVacancies] CHECK CONSTRAINT [FK_tblVacancies_tblCustomers]
GO
ALTER TABLE [dbo].[tblVacancies]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancies_tblMSPVacancieTypes] FOREIGN KEY([VacancyType])
REFERENCES [dbo].[tblMSPVacancieTypes] ([ID])
GO
ALTER TABLE [dbo].[tblVacancies] CHECK CONSTRAINT [FK_tblVacancies_tblMSPVacancieTypes]
GO
ALTER TABLE [dbo].[tblVacancieSkills]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancieSkills_tblIndustrySkills] FOREIGN KEY([SkillID])
REFERENCES [dbo].[tblIndustrySkills] ([ID])
GO
ALTER TABLE [dbo].[tblVacancieSkills] CHECK CONSTRAINT [FK_tblVacancieSkills_tblIndustrySkills]
GO
ALTER TABLE [dbo].[tblVacancieSkills]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancieSkills_tblVacancies] FOREIGN KEY([VacancyID])
REFERENCES [dbo].[tblVacancies] ([ID])
GO
ALTER TABLE [dbo].[tblVacancieSkills] CHECK CONSTRAINT [FK_tblVacancieSkills_tblVacancies]
GO
ALTER TABLE [dbo].[tblVacancyComments]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancyComments_tblComments] FOREIGN KEY([CommentID])
REFERENCES [dbo].[tblComments] ([ID])
GO
ALTER TABLE [dbo].[tblVacancyComments] CHECK CONSTRAINT [FK_tblVacancyComments_tblComments]
GO
ALTER TABLE [dbo].[tblVacancyComments]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancyComments_tblVacancies] FOREIGN KEY([VacancyID])
REFERENCES [dbo].[tblVacancies] ([ID])
GO
ALTER TABLE [dbo].[tblVacancyComments] CHECK CONSTRAINT [FK_tblVacancyComments_tblVacancies]
GO
ALTER TABLE [dbo].[tblVacancyFiles]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancyFiles_tblVacancies] FOREIGN KEY([VacancyID])
REFERENCES [dbo].[tblVacancies] ([ID])
GO
ALTER TABLE [dbo].[tblVacancyFiles] CHECK CONSTRAINT [FK_tblVacancyFiles_tblVacancies]
GO
ALTER TABLE [dbo].[tblVacancyLocations]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancyLocations_tblCustomerLocationBranches] FOREIGN KEY([LocationID])
REFERENCES [dbo].[tblCustomerLocationBranches] ([ID])
GO
ALTER TABLE [dbo].[tblVacancyLocations] CHECK CONSTRAINT [FK_tblVacancyLocations_tblCustomerLocationBranches]
GO
ALTER TABLE [dbo].[tblVacancyLocations]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancyLocations_tblVacancies] FOREIGN KEY([VacancyID])
REFERENCES [dbo].[tblVacancies] ([ID])
GO
ALTER TABLE [dbo].[tblVacancyLocations] CHECK CONSTRAINT [FK_tblVacancyLocations_tblVacancies]
GO
ALTER TABLE [dbo].[tblVacancySuppliers]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancySuppliers_tblSupplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[tblSupplier] ([ID])
GO
ALTER TABLE [dbo].[tblVacancySuppliers] CHECK CONSTRAINT [FK_tblVacancySuppliers_tblSupplier]
GO
ALTER TABLE [dbo].[tblVacancySuppliers]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancySuppliers_tblVacancies] FOREIGN KEY([VacancyID])
REFERENCES [dbo].[tblVacancies] ([ID])
GO
ALTER TABLE [dbo].[tblVacancySuppliers] CHECK CONSTRAINT [FK_tblVacancySuppliers_tblVacancies]
GO
