
INSERT [dbo].[AspNetRoleGroupRoles] ([RoleGroupId], [RoleId]) VALUES (N'570F433B-A263-46F9-903E-9CA674257786', N'0CD843EE-8740-490B-8A2E-D1EF39142DA6')
GO
INSERT [dbo].[AspNetRoleGroups] ([Id], [Name]) VALUES (N'570F433B-A263-46F9-903E-9CA674257786', N'MSP ADMINISTRATOR')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0CD843EE-8740-490B-8A2E-D1EF39142DA6', N'ADMINISTRATOR')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7013389C-42D8-4488-989F-DAFFB008F001', N'APPLICATION MANAGER')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'801729C6-586B-4C61-9936-83901C8BAF58', N'PROJECT MANAGER')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9750D8B3-1A1B-4D24-B35E-58EB4DBD94A2', N'APPLICATION USER')
GO

INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afcf8230-7878-4e1d-a550-532fd10769ae', N'vaasushreed@gmail.com', 0, N'AJvjaEODb1vdPf2CYjs+tAsxlw6/RUdLSxqcsbOjF/jTpfzDIgfGSBUb8wZMKJ58wg==', N'21741201-9964-455c-a566-9c30c277ceb4', NULL, 0, 0, NULL, 1, 0, N'admin')

GO


INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afcf8230-7878-4e1d-a550-532fd10769ae', N'0CD843EE-8740-490B-8A2E-D1EF39142DA6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afcf8230-7878-4e1d-a550-532fd10769ae', N'7013389C-42D8-4488-989F-DAFFB008F001')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afcf8230-7878-4e1d-a550-532fd10769ae', N'801729C6-586B-4C61-9936-83901C8BAF58')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afcf8230-7878-4e1d-a550-532fd10769ae', N'9750D8B3-1A1B-4D24-B35E-58EB4DBD94A2')