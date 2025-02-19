USE [Supermarket]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarketUser]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[password_hash] [char](64) NULL,
	[id_type] [int] NOT NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_country] [int] NOT NULL,
	[name] [nvarchar](64) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[barcode] [varchar](128) NULL,
	[id_category] [int] NOT NULL,
	[id_producer] [int] NOT NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[issue_date] [date] NULL,
	[id_cashier] [int] NOT NULL,
	[total_price] [decimal](18, 0) NOT NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptItem]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_receipt] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[total_price] [decimal](18, 0) NOT NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[supply_date] [date] NULL,
	[expiration_date] [date] NULL,
	[purchase_price] [decimal](18, 0) NOT NULL,
	[selling_price] [decimal](18, 0) NOT NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (2, N'Dairy', 0)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (3, N'Books', 0)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (4, N'Electronics', 1)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (5, N'Home products', 0)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (6, N'Food', 0)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (7, N'Toys', 0)
INSERT [dbo].[Category] ([id], [name], [is_active]) VALUES (8, N'Drinks', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [is_active]) VALUES (1, N'Romania', 1)
INSERT [dbo].[Country] ([id], [name], [is_active]) VALUES (2, N'Germany', 1)
INSERT [dbo].[Country] ([id], [name], [is_active]) VALUES (3, N'France', 1)
INSERT [dbo].[Country] ([id], [name], [is_active]) VALUES (4, N'China', 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[MarketUser] ON 

INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (1, N'Admin1', N'1q2w3e                                                          ', 1, 1)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (2, N'Admin2', N'a1b1c1                                                          ', 1, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (3, N'Cashier1ED', N'cashier123ED                                                    ', 2, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (4, N'Cashier2', N'cashier124ED                                                    ', 2, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (5, N'Cashier3', N'cashier125                                                      ', 2, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (6, N'Cashier4', N'cashier126                                                      ', 2, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (7, N'Cashier5ED', N'cashier127                                                      ', 2, 1)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (8, N'Cashier8ED', N'cashier128ED                                                    ', 2, 0)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (9, N'Cashier9', N'cashier129                                                      ', 2, 1)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (10, N'Cashier10', N'cashier130                                                      ', 2, 1)
INSERT [dbo].[MarketUser] ([id], [name], [password_hash], [id_type], [is_active]) VALUES (11, N'', N'                                                                ', 2, 0)
SET IDENTITY_INSERT [dbo].[MarketUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Producer] ON 

INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (4, 1, N'Producer1ED', 1)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (5, 1, N'Producer2', 0)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (6, 2, N'Producer3', 1)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (7, 3, N'ProducerED', 1)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (8, 1, N'Producer1ED', 0)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (9, 1, N'Producer1ED', 0)
INSERT [dbo].[Producer] ([id], [id_country], [name], [is_active]) VALUES (10, 1, N'Producer1ED', 0)
SET IDENTITY_INSERT [dbo].[Producer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (7, N'Product1ED', N'000111222333', 7, 7, 1)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (8, N'Product2', N'000111222334', 3, 4, 0)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (9, N'Product3', N'000111222335', 2, 4, 0)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (10, N'Product2ED', N'000111222334', 7, 7, 1)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (11, N'Product5ED', N'000111222337', 4, 4, 1)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (12, N'Product6', N'000111222338', 4, 7, 1)
INSERT [dbo].[Product] ([id], [name], [barcode], [id_category], [id_producer], [is_active]) VALUES (14, N'Product7', N'000111222339', 7, 6, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Receipt] ON 

INSERT [dbo].[Receipt] ([id], [issue_date], [id_cashier], [total_price], [is_active]) VALUES (7, CAST(N'2024-05-26' AS Date), 7, CAST(288 AS Decimal(18, 0)), 1)
INSERT [dbo].[Receipt] ([id], [issue_date], [id_cashier], [total_price], [is_active]) VALUES (10, CAST(N'2024-05-28' AS Date), 7, CAST(432 AS Decimal(18, 0)), 1)
INSERT [dbo].[Receipt] ([id], [issue_date], [id_cashier], [total_price], [is_active]) VALUES (11, CAST(N'2024-05-28' AS Date), 7, CAST(576 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Receipt] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceiptItem] ON 

INSERT [dbo].[ReceiptItem] ([id], [id_receipt], [id_product], [quantity], [total_price], [is_active]) VALUES (1, 7, 11, 2, CAST(288 AS Decimal(18, 0)), 1)
INSERT [dbo].[ReceiptItem] ([id], [id_receipt], [id_product], [quantity], [total_price], [is_active]) VALUES (2, 10, 11, 3, CAST(432 AS Decimal(18, 0)), 1)
INSERT [dbo].[ReceiptItem] ([id], [id_receipt], [id_product], [quantity], [total_price], [is_active]) VALUES (3, 11, 11, 4, CAST(576 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[ReceiptItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (1, 7, 0, CAST(N'2024-04-24' AS Date), CAST(N'2025-04-24' AS Date), CAST(75 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (3, 10, 0, CAST(N'2024-06-01' AS Date), CAST(N'2025-06-01' AS Date), CAST(100 AS Decimal(18, 0)), CAST(125 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (4, 10, 150, CAST(N'2024-03-15' AS Date), CAST(N'2025-03-15' AS Date), CAST(150 AS Decimal(18, 0)), CAST(188 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (5, 11, 205, CAST(N'2024-03-01' AS Date), CAST(N'2025-09-01' AS Date), CAST(115 AS Decimal(18, 0)), CAST(144 AS Decimal(18, 0)), 1)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (6, 14, 200, CAST(N'2024-01-01' AS Date), CAST(N'2025-01-01' AS Date), CAST(135 AS Decimal(18, 0)), CAST(169 AS Decimal(18, 0)), 1)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (7, 14, 24, CAST(N'2024-04-25' AS Date), CAST(N'2024-04-26' AS Date), CAST(50 AS Decimal(18, 0)), CAST(63 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (8, 12, 244, CAST(N'2024-05-26' AS Date), CAST(N'2024-10-26' AS Date), CAST(100 AS Decimal(18, 0)), CAST(125 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (9, 12, -1, CAST(N'2023-05-26' AS Date), CAST(N'2024-05-26' AS Date), CAST(50 AS Decimal(18, 0)), CAST(63 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (10, 7, 0, CAST(N'2024-05-26' AS Date), CAST(N'2025-05-26' AS Date), CAST(75 AS Decimal(18, 0)), CAST(94 AS Decimal(18, 0)), 0)
INSERT [dbo].[Stock] ([id], [id_product], [quantity], [supply_date], [expiration_date], [purchase_price], [selling_price], [is_active]) VALUES (11, 7, 0, CAST(N'2024-05-26' AS Date), CAST(N'2025-05-26' AS Date), CAST(75 AS Decimal(18, 0)), CAST(94 AS Decimal(18, 0)), 0)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([id], [name], [is_active]) VALUES (1, N'Admin', 1)
INSERT [dbo].[UserType] ([id], [name], [is_active]) VALUES (2, N'Cashier', 1)
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[MarketUser] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[MarketUser] ADD  DEFAULT ('undefined0000000000000000000000000000000000000000000000000000000') FOR [password_hash]
GO
ALTER TABLE [dbo].[MarketUser] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Producer] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[Producer] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('undefined') FOR [barcode]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Receipt] ADD  DEFAULT (CONVERT([date],getdate())) FOR [issue_date]
GO
ALTER TABLE [dbo].[Receipt] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[ReceiptItem] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Stock] ADD  DEFAULT (CONVERT([date],getdate())) FOR [supply_date]
GO
ALTER TABLE [dbo].[Stock] ADD  DEFAULT (CONVERT([date],getdate())) FOR [expiration_date]
GO
ALTER TABLE [dbo].[Stock] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[UserType] ADD  DEFAULT ('undefined') FOR [name]
GO
ALTER TABLE [dbo].[UserType] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[MarketUser]  WITH CHECK ADD FOREIGN KEY([id_type])
REFERENCES [dbo].[UserType] ([id])
GO
ALTER TABLE [dbo].[Producer]  WITH CHECK ADD FOREIGN KEY([id_country])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([id_category])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([id_producer])
REFERENCES [dbo].[Producer] ([id])
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD FOREIGN KEY([id_cashier])
REFERENCES [dbo].[MarketUser] ([id])
GO
ALTER TABLE [dbo].[ReceiptItem]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ReceiptItem]  WITH CHECK ADD FOREIGN KEY([id_receipt])
REFERENCES [dbo].[Receipt] ([id])
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[Product] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AddCashier]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCashier]
	@name NVARCHAR(64),
	@password_hash CHAR(64)
AS
BEGIN
    INSERT INTO dbo.MarketUser
	VALUES (@name, @password_hash, 2, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
	@name nvarchar(64)
AS
BEGIN
	INSERT INTO dbo.Category
	VALUES(@name, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProducer]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProducer]
	@id_country INT,
	@name NVARCHAR(64)
AS
BEGIN
    INSERT INTO dbo.Producer
	VALUES (@id_country, @name, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
	@id_producer INT,
	@id_category INT,
	@name NVARCHAR(64),
	@barcode VARCHAR(128)
AS
BEGIN
	INSERT INTO dbo.Product
	VALUES (@name, @barcode, @id_category, @id_producer, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[AddReceipt]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddReceipt]
	@id_cashier INT,
	@total_price DECIMAL
AS
BEGIN
	INSERT INTO dbo.Receipt
	VALUES (GETDATE(), @id_cashier, @total_price, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddReceiptItem]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddReceiptItem]
	@id INT,
	@id_product INT,
	@quantity INT,
	@total_price DECIMAL
AS
BEGIN
	INSERT INTO dbo.ReceiptItem
	VALUES (@id, @id_product, @quantity, @total_price, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddStock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStock]
	@id_product INT,
	@quantity INT,
	@supply_date DATE,
	@expiration_date DATE,
	@purchase_price DECIMAL
AS
BEGIN
	INSERT INTO dbo.Stock
	VALUES (@id_product, @quantity, @supply_date, @expiration_date, @purchase_price, @purchase_price * 1.25, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[DeactivateStock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeactivateStock]
	@quantity INT
AS
BEGIN
	IF @quantity = 0
	BEGIN
		UPDATE Stock
		SET is_active = 0;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DecreaseQuantity]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DecreaseQuantity]
	@id_stock INT
AS
BEGIN
	UPDATE Stock
	SET quantity = quantity - 1
	WHERE id = @id_stock AND is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCashier]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCashier]
	@id INT
AS
BEGIN
	UPDATE dbo.MarketUser
	SET is_active = 0
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
	@id INT
AS
BEGIN
	UPDATE dbo.Category
	SET is_active = 0
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProducer]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProducer]
	@id INT
AS
BEGIN
	UPDATE dbo.Producer
	SET is_active = 0
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
	@id INT
AS
BEGIN
	UPDATE dbo.Product
	SET is_active = 0
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStock]
	@id INT
AS
BEGIN
	UPDATE dbo.Stock
	SET is_active = 0
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditCashierName]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCashierName]
	@id INT,
	@name NVARCHAR(64)
AS
BEGIN
	UPDATE dbo.MarketUser
	SET name = @name
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditCashierPassword]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCashierPassword]
	@id INT,
	@password_hash CHAR(64)
AS
BEGIN
	UPDATE dbo.MarketUser
	SET password_hash = @password_hash
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditCategoryName]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCategoryName]
	@id INT,
	@name NVARCHAR(64)
AS
BEGIN
	UPDATE dbo.Category
	SET name = @name
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditProducerName]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditProducerName]
	@id INT,
	@name NVARCHAR(64)
AS
BEGIN
	UPDATE dbo.Producer
	SET name = @name
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditProduct]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditProduct]
	@id INT,
	@id_category INT,
	@id_producer INT,
	@name NVARCHAR(64),
	@barcode VARCHAR(128)
AS
BEGIN
	UPDATE dbo.Product
	SET id_category = @id_category, id_producer = @id_producer, name = @name, barcode = @barcode
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditStock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStock]
	@id INT,
	@id_product INT,
	@quantity INT,
	@supply_date DATE,
	@expiration_date DATE,
	@selling_price DECIMAL
AS
BEGIN
	UPDATE dbo.Stock
	SET id_product = @id_product, quantity = @quantity, supply_date = @supply_date, expiration_date = @expiration_date, selling_price = @selling_price
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveBarcodes]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveBarcodes]
AS
BEGIN
	SELECT barcode
	FROM dbo.Product
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveCashiers]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveCashiers]
AS
BEGIN
	SELECT name
	FROM dbo.MarketUser
	WHERE id_type = 2 AND is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveCashiersIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveCashiersIds]
AS
BEGIN
	SELECT id
	FROM dbo.MarketUser
	WHERE id_type = 2 AND is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveCategories]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveCategories]
AS
BEGIN
	SELECT name
	FROM dbo.Category
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveCategoriesIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveCategoriesIds]
AS
BEGIN
	SELECT id
	FROM dbo.Category
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveCountryIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveCountryIds]
AS
BEGIN
	SELECT id
	FROM dbo.Country
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveProducers]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveProducers]
AS
BEGIN
	SELECT name
	FROM dbo.Producer
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveProducersIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveProducersIds]
AS
BEGIN
	SELECT id
	FROM dbo.Producer
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveProducts]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveProducts]
AS
BEGIN
	SELECT name
	FROM dbo.Product
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveProductsIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveProductsIds]
AS
BEGIN
	SELECT id
	FROM dbo.Product
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveStocksIds]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveStocksIds]
AS
BEGIN
	SELECT id
	FROM dbo.Stock
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveStocksProductsBarcodes]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveStocksProductsBarcodes]
AS
BEGIN
	SELECT
		Product.barcode AS productBarcode
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	WHERE
		Stock.is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashierByName]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCashierByName]
	@name NVARCHAR(64)
AS
BEGIN
	SELECT id
	FROM dbo.MarketUser
	WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashiers]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCashiers]
AS
BEGIN
	SELECT id, name, password_hash
	FROM dbo.MarketUser
	WHERE id_type = 2 AND is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashierSumsInEveryMonth]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCashierSumsInEveryMonth]
	@name NVARCHAR(64),
	@month INT
AS
BEGIN
	SELECT
		MarketUser.name AS cashierName,
		MONTH(Receipt.issue_date) AS receiptMonth,
		DAY(Receipt.issue_date) AS receiptDay,
		SUM(Receipt.total_price) AS sumTotalPrice
	FROM
		Receipt AS receipt
	INNER JOIN
		MarketUser AS marketUser ON marketUser.id = receipt.id_cashier
	WHERE
		marketUser.name = @name AND
		MONTH(Receipt.issue_date) = @month
	GROUP BY
		MarketUser.name, DAY(Receipt.issue_date), MONTH(Receipt.issue_date);
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE [dbo].[GetCategories]
AS
BEGIN
	SELECT id, name
	FROM dbo.Category
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetLastReceiptId]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLastReceiptId]
AS
BEGIN
	SELECT TOP 1 id
	FROM dbo.Receipt
	ORDER BY id DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMarketUsers]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarketUsers]
AS
BEGIN
	SELECT name
	FROM dbo.MarketUser
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMarketUsersPasswords]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarketUsersPasswords]
AS
BEGIN
	SELECT password_hash
	FROM dbo.MarketUser
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducers]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducers]
AS
BEGIN
	SELECT id, id_country, name
	FROM dbo.Producer
	WHERE is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducersProductsCategories]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducersProductsCategories]
	@producer_name NVARCHAR(64)
AS
BEGIN
	SELECT
		Producer.name AS producerName,
		Product.name AS productName,
		Category.name AS categoryName
	FROM
		Producer AS producer
	INNER JOIN
		Product AS product ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Producer.is_active = 1 AND
		Producer.name = @producer_name
	GROUP BY
		producer.name, category.name, product.name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByBarcode]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByBarcode]
	@barcode VARCHAR(128)
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Product.barcode AS productBarcode,
		Stock.expiration_date AS productExpirationDate,
		Producer.name AS productProducer,
		Category.name AS productCategory
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	INNER JOIN
		Producer AS producer ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Product.barcode = @barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByCategory]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByCategory]
	@category_name NVARCHAR(64)
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Product.barcode AS productBarcode,
		Stock.expiration_date AS productExpirationDate,
		Producer.name AS productProducer,
		Category.name AS productCategory
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	INNER JOIN
		Producer AS producer ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Category.name = @category_name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByExpirationDate]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByExpirationDate]
	@date DATE
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Product.barcode AS productBarcode,
		Stock.expiration_date AS productExpirationDate,
		Producer.name AS productProducer,
		Category.name AS productCategory
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	INNER JOIN
		Producer AS producer ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Stock.expiration_date = @date;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByName]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByName]
	@name NVARCHAR(64)
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Product.barcode AS productBarcode,
		Stock.expiration_date AS productExpirationDate,
		Producer.name AS productProducer,
		Category.name AS productCategory
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	INNER JOIN
		Producer AS producer ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Product.name = @name
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByProducer]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByProducer]
	@producer_name NVARCHAR(64)
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Product.barcode AS productBarcode,
		Stock.expiration_date AS productExpirationDate,
		Producer.name AS productProducer,
		Category.name AS productCategory
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	INNER JOIN
		Producer AS producer ON producer.id = product.id_producer
	INNER JOIN
		Category AS category ON category.id = product.id_category
	WHERE
		Producer.name = @producer_name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
	SELECT
		Product.id,
		Producer.name AS producerName,
		Category.name AS categoryName,
		Product.name,
		Product.barcode
	FROM
		Product AS product
	INNER JOIN
		Category AS category ON product.id_category = category.id
	INNER JOIN
		Producer AS producer ON product.id_producer = producer.id
	WHERE Product.is_active = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetQuantity]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetQuantity]
	@productId INT
AS
BEGIN
	SELECT TOP 1 quantity
	FROM Stock
	WHERE id_product = @productId AND is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockId]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockId]
	@id_product INT
AS
BEGIN
	SELECT TOP 1 id
	FROM dbo.Stock
	WHERE id_product = @id_product AND is_active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockProductByBarcode]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockProductByBarcode]
	@barcode VARCHAR(128)
AS
BEGIN
	SELECT
		Product.id AS productId,
		Product.name AS productName,
		Stock.selling_price AS stockSellingPrice
	FROM
		Product AS product
	INNER JOIN
		Stock AS stock ON stock.id_product = product.id
	WHERE
		Product.barcode = @barcode AND Stock.is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockPurchasePrice]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockPurchasePrice]
	@id INT
AS
BEGIN
	SELECT purchase_price
	FROM dbo.Stock
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStocks]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStocks]
AS
BEGIN
	SELECT
		Stock.id,
		Product.name AS productName,
		Stock.quantity,
		Stock.supply_date,
		Stock.expiration_date,
		Stock.purchase_price,
		Stock.selling_price
	FROM
		Stock AS stock
	INNER JOIN
		Product AS product ON product.id = stock.id_product
	WHERE
		stock.is_active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetSumByCategory]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSumByCategory]
	@category_name NVARCHAR(64)
AS
BEGIN
	SELECT
		SUM(stock.selling_price)
	FROM
		Stock AS stock
	INNER JOIN
		Product AS product ON stock.id_product = product.id
	INNER JOIN
		Category AS category ON product.id_category = category.id
	WHERE
		category.name = @category_name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTheBiggestReceipt]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTheBiggestReceipt]
	@date DATE
AS
BEGIN
	SELECT TOP 1
		Receipt.id AS receiptId,
		MarketUser.name AS cashier,
		Receipt.total_price AS receiptTotalPrice
	FROM
		Receipt AS receipt
    INNER JOIN
		MarketUser AS marketUser ON marketUser.id = receipt.id_cashier
	WHERE
		receipt.issue_date = @date
	ORDER BY receipt.total_price DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 03.02.2025 16:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStock]
AS
BEGIN
	UPDATE dbo.Stock
	SET is_active = 0
	WHERE quantity = 0 OR expiration_date < GETDATE();
END
GO
