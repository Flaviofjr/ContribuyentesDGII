-- Seed data with safeguards to avoid duplicate key and identity errors
-- Inserts are ordered so foreign keys are satisfied: Estatus, TipoPersonas, Contribuyentes, ComprobantesFiscales, then __EFMigrationsHistory

-- ESTATUS (identity) - insert only if not exists
IF NOT EXISTS (SELECT 1 FROM [dbo].[Estatus] WHERE IdEstatus =1)
BEGIN
 SET IDENTITY_INSERT [dbo].[Estatus] ON;
 INSERT INTO [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion])
 VALUES (1, N'activo', CAST(N'2023-05-15T16:39:55.487' AS DateTime), CAST(N'2023-05-15T16:39:55.487' AS DateTime));
 SET IDENTITY_INSERT [dbo].[Estatus] OFF;
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Estatus] WHERE IdEstatus =2)
BEGIN
 SET IDENTITY_INSERT [dbo].[Estatus] ON;
 INSERT INTO [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion])
 VALUES (2, N'inactivo', CAST(N'2023-05-15T16:41:39.897' AS DateTime), CAST(N'2023-05-15T16:41:39.897' AS DateTime));
 SET IDENTITY_INSERT [dbo].[Estatus] OFF;
END

-- TIPOPERSONAS (identity)
IF NOT EXISTS (SELECT 1 FROM [dbo].[TipoPersonas] WHERE IdTipoPersona =1)
BEGIN
 SET IDENTITY_INSERT [dbo].[TipoPersonas] ON;
 INSERT INTO [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion])
 VALUES (1, N'PERSONA FISICA', CAST(N'2023-05-15T16:48:13.930' AS DateTime), CAST(N'2023-05-15T16:48:13.930' AS DateTime));
 SET IDENTITY_INSERT [dbo].[TipoPersonas] OFF;
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[TipoPersonas] WHERE IdTipoPersona =2)
BEGIN
 SET IDENTITY_INSERT [dbo].[TipoPersonas] ON;
 INSERT INTO [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion])
 VALUES (2, N'PERSONA JURIDICA', CAST(N'2023-05-15T16:49:22.450' AS DateTime), CAST(N'2023-05-15T16:49:22.450' AS DateTime));
 SET IDENTITY_INSERT [dbo].[TipoPersonas] OFF;
END

-- CONTRIBUYENTES (depends on TipoPersonas and Estatus)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Contribuyentes] WHERE RncCedula = N'123456789')
BEGIN
 INSERT INTO [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula])
 VALUES (N'FARMACIA TU SALUD',2,2, CAST(N'2023-05-15T20:45:36.217' AS DateTime), CAST(N'2023-05-15T20:45:36.217' AS DateTime), N'123456789');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Contribuyentes] WHERE RncCedula = N'98754321012')
BEGIN
 INSERT INTO [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula])
 VALUES (N'JUAN PEREZ',1,1, CAST(N'2023-05-15T20:44:35.700' AS DateTime), CAST(N'2023-05-15T20:44:35.700' AS DateTime), N'98754321012');
END

-- COMPROBANTESFISCALES (depends on Contribuyentes)
IF NOT EXISTS (SELECT 1 FROM [dbo].[ComprobantesFiscales] WHERE NCF = N'E310000000001')
BEGIN
 INSERT INTO [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula])
 VALUES (N'E310000000001', CAST(200.00 AS Decimal(18,2)), CAST(36.00 AS Decimal(18,2)), CAST(N'2023-05-15T22:47:52.863' AS DateTime), CAST(N'2023-05-15T22:47:52.863' AS DateTime), N'98754321012');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ComprobantesFiscales] WHERE NCF = N'E310000000002')
BEGIN
 INSERT INTO [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula])
 VALUES (N'E310000000002', CAST(1000.00 AS Decimal(18,2)), CAST(180.00 AS Decimal(18,2)), CAST(N'2023-05-15T23:04:25.487' AS DateTime), CAST(N'2023-05-15T23:04:25.487' AS DateTime), N'98754321012');
END

-- __EFMigrationsHistory entries (insert only if not exists)
IF NOT EXISTS (SELECT 1 FROM [dbo].[__EFMigrationsHistory] WHERE [MigrationId] = N'20230515051547_InitialCreate')
BEGIN
 INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515051547_InitialCreate', N'7.0.5');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[__EFMigrationsHistory] WHERE [MigrationId] = N'20230515214830_DroppingFKeys')
BEGIN
 INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515214830_DroppingFKeys', N'7.0.5');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[__EFMigrationsHistory] WHERE [MigrationId] = N'20230515221720_ReversingEverything')
BEGIN
 INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515221720_ReversingEverything', N'7.0.5');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[__EFMigrationsHistory] WHERE [MigrationId] = N'20230516003714_AddingAgain')
BEGIN
 INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516003714_AddingAgain', N'7.0.5');
END
