-- Seed data extracted from Contribuyentes-DB.sql
-- Contains only INSERT statements

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515051547_InitialCreate', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515214830_DroppingFKeys', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230515221720_ReversingEverything', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516003714_AddingAgain', N'7.0.5')

INSERT [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'E310000000001', CAST(200.00 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(N'2023-05-15T22:47:52.863' AS DateTime), CAST(N'2023-05-15T22:47:52.863' AS DateTime), N'98754321012')
INSERT [dbo].[ComprobantesFiscales] ([NCF], [Monto], [Itbis18], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'E310000000002', CAST(1000.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), CAST(N'2023-05-15T23:04:25.487' AS DateTime), CAST(N'2023-05-15T23:04:25.487' AS DateTime), N'98754321012')

INSERT [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'FARMACIA TU SALUD', 2, 2, CAST(N'2023-05-15T20:45:36.217' AS DateTime), CAST(N'2023-05-15T20:45:36.217' AS DateTime), N'123456789')
INSERT [dbo].[Contribuyentes] ([Nombre], [IdTipoPersona], [IdEstatus], [FechaCreacion], [UltimaFechaModificacion], [RncCedula]) VALUES (N'JUAN PEREZ', 1, 1, CAST(N'2023-05-15T20:44:35.700' AS DateTime), CAST(N'2023-05-15T20:44:35.700' AS DateTime), N'98754321012')

INSERT [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion]) VALUES (1, N'activo', CAST(N'2023-05-15T16:39:55.487' AS DateTime), CAST(N'2023-05-15T16:39:55.487' AS DateTime))
INSERT [dbo].[Estatus] ([IdEstatus], [Descripcion], [FechaCreacion], [UltimaFechaModificacion]) VALUES (2, N'inactivo', CAST(N'2023-05-15T16:41:39.897' AS DateTime), CAST(N'2023-05-15T16:41:39.897' AS DateTime))

INSERT [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion]) VALUES (1, N'PERSONA FISICA', CAST(N'2023-05-15T16:48:13.930' AS DateTime), CAST(N'2023-05-15T16:48:13.930' AS DateTime))
INSERT [dbo].[TipoPersonas] ([IdTipoPersona], [DescripcionPersona], [FechaCreacion], [UltimaFechaModificacion]) VALUES (2, N'PERSONA JURIDICA', CAST(N'2023-05-15T16:49:22.450' AS DateTime), CAST(N'2023-05-15T16:49:22.450' AS DateTime))
