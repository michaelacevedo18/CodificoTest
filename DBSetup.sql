CREATE DATABASE StoreSample;
GO
USE [StoreSample]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20-ene-25 11:24:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ShipperId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[RequiredDate] [datetime2](7) NOT NULL,
	[ShippedDate] [datetime2](7) NULL,
	[Freight] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 20-ene-25 11:24:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[ShipperId] [int] IDENTITY(1,1) NOT NULL,
	[ShipName] [nvarchar](max) NOT NULL,
	[ShipAddress] [nvarchar](max) NOT NULL,
	[ShipCity] [nvarchar](max) NOT NULL,
	[ShipCountry] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250117222746_Migracion1', N'8.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250117233042_Migracion2', N'8.0.12')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (1, N'Cliente A', N'Call1 1 -1', N'Sogamoso', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (3, N'Cliente B', N'Call2 2 -2', N'Tunja', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (4, N'Cliente C', N'Call3 3 -3', N'Quito', N'Ecuador')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (5, N'Cliente D', N'Call4 4 -4', N'Taganga', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (6, N'Cliente E', N'Call5 5 -5', N'Pajarito', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (7, N'Cliente F', N'Call6 6 -6', N'Regatas', N'Argentina')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (8, N'Cliente G', N'Calle 7 -7', N'Buenos Aires', N'Argentina')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (9, N'Cliente H', N'Calle 8 -8', N'Pereira', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (10, N'Cliente I', N'Calle 9 -9', N'Cali', N'Colombia')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (11, N'Cliente J', N'Calle 10 20A', N'Virginia', N'Estados Unidos')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [City], [Country]) VALUES (12, N'Cliente K', N'Calle 11 10B', N'Colorado', N'Estados Unidos')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmpId], [FullName]) VALUES (1, N'Cajero 1 - Javier Mesa')
INSERT [dbo].[Employees] ([EmpId], [FullName]) VALUES (2, N'Cajero 2 - Luisa Gomez')
INSERT [dbo].[Employees] ([EmpId], [FullName]) VALUES (3, N'Cajero 3 - Edwin Perea')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (16, 29, 3, CAST(7500.00 AS Decimal(18, 2)), 22, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (19, 32, 5, CAST(7000.00 AS Decimal(18, 2)), 1, CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (20, 33, 6, CAST(7800.00 AS Decimal(18, 2)), 5, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (21, 33, 5, CAST(1000.00 AS Decimal(18, 2)), 1, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (22, 35, 4, CAST(1200.00 AS Decimal(18, 2)), 7, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (23, 36, 5, CAST(2600.00 AS Decimal(18, 2)), 3, CAST(600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (29, 1, 1, 1, CAST(N'1999-01-19T02:57:47.0690000' AS DateTime2), CAST(N'1999-01-19T02:57:47.0690000' AS DateTime2), CAST(N'1999-01-19T02:57:47.0690000' AS DateTime2), CAST(6800.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (32, 1, 1, 2, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-02T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-03T00:00:00.0000000' AS DateTime2), CAST(7600.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (33, 3, 2, 1, CAST(N'2025-01-02T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-22T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-19T00:00:00.0000000' AS DateTime2), CAST(7600.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (34, 3, 3, 2, CAST(N'2025-01-22T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-31T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-12T00:00:00.0000000' AS DateTime2), CAST(9100.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (35, 1, 1, 2, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-13T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-14T00:00:00.0000000' AS DateTime2), CAST(9100.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (36, 1, 1, 2, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-13T00:00:00.0000000' AS DateTime2), CAST(6900.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (40, 4, 3, 4, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(4500.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [EmployeeId], [ShipperId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (41, 5, 2, 5, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(4900.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (1, N'Estibas plasticas', CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (2, N'Cubrelecho', CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (3, N'Espejo', CAST(3400.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (4, N'Perchero', CAST(2999.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (5, N'Mesa blanca', CAST(1980.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (6, N'Silla rimax', CAST(7800.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice]) VALUES (7, N'Galletas Noel', CAST(9500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Shippers] ON 

INSERT [dbo].[Shippers] ([ShipperId], [ShipName], [ShipAddress], [ShipCity], [ShipCountry]) VALUES (1, N'Servientrega', N'Calle 1 15A -21', N'Sogamoso', N'Colombia')
INSERT [dbo].[Shippers] ([ShipperId], [ShipName], [ShipAddress], [ShipCity], [ShipCountry]) VALUES (2, N'Interrapidísimo', N'Calle 6 15A -43', N'Duitama', N'Colombia')
INSERT [dbo].[Shippers] ([ShipperId], [ShipName], [ShipAddress], [ShipCity], [ShipCountry]) VALUES (3, N'Envía', N'Diagonal 24 No 23- 3', N'Bogotá', N'Colombia')
INSERT [dbo].[Shippers] ([ShipperId], [ShipName], [ShipAddress], [ShipCity], [ShipCountry]) VALUES (4, N'4/72', N'Parque principal', N'Tunja', N'Colombia')
INSERT [dbo].[Shippers] ([ShipperId], [ShipName], [ShipAddress], [ShipCity], [ShipCountry]) VALUES (5, N'Interentrega', N'Calle 16 No 28 A 51', N'Funza', N'Colombia')
SET IDENTITY_INSERT [dbo].[Shippers] OFF
GO
ALTER TABLE [dbo].[Shippers] ADD  DEFAULT (N'') FOR [ShipAddress]
GO
ALTER TABLE [dbo].[Shippers] ADD  DEFAULT (N'') FOR [ShipCity]
GO
ALTER TABLE [dbo].[Shippers] ADD  DEFAULT (N'') FOR [ShipCountry]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmpId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[Shippers] ([ShipperId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers_ShipperId]
GO
