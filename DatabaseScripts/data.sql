INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'29f19299-31f5-46ca-a818-7a3621cdce72', N'admin@rentahouse.com', N'ADMIN@RENTAHOUSE.COM', N'admin@rentahouse.com', N'ADMIN@RENTAHOUSE.COM', 0, N'AQAAAAEAACcQAAAAEEi984hOpZI0nv3ebUbihtbMEEvQgWubUZCYBhBUXkR0Qdp7F8P1cTwZZgYyLqTTnQ==', N'NUWLNP6BL3ZJOPI7WNIF2HW3DVDEBGRZ', N'fb804cab-c6a5-43a1-b91e-dd3ecefe714f', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[HouseOwner] ON
INSERT INTO [dbo].[HouseOwner] ([Id], [Name], [ContactNumber]) VALUES (1, N'Samson Kent', N'02123456789')
INSERT INTO [dbo].[HouseOwner] ([Id], [Name], [ContactNumber]) VALUES (2, N'Harry Reynolds', N'02134562222')
SET IDENTITY_INSERT [dbo].[HouseOwner] OFF
SET IDENTITY_INSERT [dbo].[House] ON
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (1, 2, N'230A Great South Road Auckland ')
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (2, 2, N'670A  Queen Street Auckland')
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (3, 1, N'570A Victoria Street  Auckland ')
SET IDENTITY_INSERT [dbo].[House] OFF
SET IDENTITY_INSERT [dbo].[Tenant] ON
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (1, N'Devon McDondald', N'0210982345')
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (2, N'Frank Stephen', N'02134568903')
SET IDENTITY_INSERT [dbo].[Tenant] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (1, 1, 1, CAST(160.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (2, 2, 1, CAST(700.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (3, 2, 2, CAST(650.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Contract] OFF


