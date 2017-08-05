USE [eVMS]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/5/2017 6:02:00 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleGroupRoles]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleGroups]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblBranches]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblCountries]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblCountryStates]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblLocations]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblMSPDetails]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblMSPLocationBranches]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblMSPUsers]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblUserLocationBranches]    Script Date: 8/5/2017 6:02:01 PM ******/
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
/****** Object:  Table [dbo].[tblUserProfile]    Script Date: 8/5/2017 6:02:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserProfile](
	[UserID] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
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
ALTER TABLE [dbo].[tblCountryStates]  WITH CHECK ADD  CONSTRAINT [FK_tblCountryStates_tblCountries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tblCountries] ([ID])
GO
ALTER TABLE [dbo].[tblCountryStates] CHECK CONSTRAINT [FK_tblCountryStates_tblCountries]
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
