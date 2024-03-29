USE [master]
GO
/****** Object:  Database [HahnWarehouse]    Script Date: 30/03/2023 13:12:10 ******/
CREATE DATABASE [HahnWarehouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HahnWarehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HahnWarehouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HahnWarehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HahnWarehouse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HahnWarehouse] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HahnWarehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HahnWarehouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HahnWarehouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HahnWarehouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HahnWarehouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HahnWarehouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [HahnWarehouse] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HahnWarehouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HahnWarehouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HahnWarehouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HahnWarehouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HahnWarehouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HahnWarehouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HahnWarehouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HahnWarehouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HahnWarehouse] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HahnWarehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HahnWarehouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HahnWarehouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HahnWarehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HahnWarehouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HahnWarehouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HahnWarehouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HahnWarehouse] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HahnWarehouse] SET  MULTI_USER 
GO
ALTER DATABASE [HahnWarehouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HahnWarehouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HahnWarehouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HahnWarehouse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HahnWarehouse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HahnWarehouse] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HahnWarehouse] SET QUERY_STORE = OFF
GO
USE [HahnWarehouse]
GO
/****** Object:  Table [dbo].[person]    Script Date: 30/03/2023 13:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[person](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[business_name] [nvarchar](60) NULL,
	[balance] [decimal](18, 0) NULL,
	[creation_date] [datetime] NULL,
	[person_type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[person_type]    Script Date: 30/03/2023 13:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[person_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 30/03/2023 13:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](60) NULL,
	[price] [decimal](18, 0) NULL,
	[stock] [decimal](18, 0) NULL,
	[supplier_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sub_transactions]    Script Date: 30/03/2023 13:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sub_transactions](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[transaction_id] [bigint] NULL,
	[product_id] [bigint] NULL,
	[amount] [decimal](18, 0) NULL,
	[total] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 30/03/2023 13:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[person] [bigint] NULL,
	[transaction_began] [datetime] NULL,
	[total] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[person] ON 
GO
INSERT [dbo].[person] ([id], [business_name], [balance], [creation_date], [person_type]) VALUES (15, N'Microsoft', CAST(0 AS Decimal(18, 0)), CAST(N'2023-03-23T13:30:33.977' AS DateTime), 1)
GO
INSERT [dbo].[person] ([id], [business_name], [balance], [creation_date], [person_type]) VALUES (16, N'Hittech', CAST(0 AS Decimal(18, 0)), CAST(N'2023-03-23T13:30:41.147' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[person] OFF
GO
SET IDENTITY_INSERT [dbo].[person_type] ON 
GO
INSERT [dbo].[person_type] ([id], [type]) VALUES (1, N'Client')
GO
INSERT [dbo].[person_type] ([id], [type]) VALUES (2, N'Supplier')
GO
SET IDENTITY_INSERT [dbo].[person_type] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 
GO
INSERT [dbo].[products] ([id], [description], [price], [stock], [supplier_id]) VALUES (1, N'Intel i5', CAST(150 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)), 16)
GO
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[transactions] ON 
GO
INSERT [dbo].[transactions] ([id], [person], [transaction_began], [total]) VALUES (1, 15, CAST(N'2023-03-23T13:37:46.777' AS DateTime), CAST(0 AS Decimal(18, 0)))
GO
INSERT [dbo].[transactions] ([id], [person], [transaction_began], [total]) VALUES (2, 16, CAST(N'2023-03-23T14:05:26.443' AS DateTime), CAST(0 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[transactions] OFF
GO
ALTER TABLE [dbo].[person]  WITH CHECK ADD FOREIGN KEY([person_type])
REFERENCES [dbo].[person_type] ([id])
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD FOREIGN KEY([supplier_id])
REFERENCES [dbo].[person] ([id])
GO
ALTER TABLE [dbo].[sub_transactions]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[sub_transactions]  WITH CHECK ADD FOREIGN KEY([transaction_id])
REFERENCES [dbo].[transactions] ([id])
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD FOREIGN KEY([person])
REFERENCES [dbo].[person] ([id])
GO
/****** Object:  Trigger [dbo].[updatetotal]    Script Date: 30/03/2023 13:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[updatetotal] ON [dbo].[sub_transactions]
AFTER INSERT, DELETE
AS
BEGIN
	DECLARE @totalsub AS DECIMAL
	DECLARE @id_transaction AS BIGINT
	DECLARE @person_id AS BIGINT
	DECLARE @person_type AS INT
	DECLARE @product_id AS INT
	
	IF EXISTS(SELECT * FROM inserted)
	BEGIN
		SET @id_transaction = (SELECT i.transaction_id FROM inserted i)
		SET @totalsub = (SELECT SUM(s.total) FROM sub_transactions s WHERE transaction_id = @id_transaction)
		SET @totalsub = IIF(@totalsub IS NULL, 0, @totalsub)
		SET @product_id = (SELECT product_id FROM inserted)

		-- GET THE ID OF THE PERSON
		SET @person_id = (SELECT DISTINCT person FROM transactions
		WHERE id = @id_transaction)
		
		SET @person_type = (SELECT person_type from person where id = @person_id)

		-- UPDATE TOTAL IN TRANSACTION TABLE
		UPDATE transactions SET total = @totalsub WHERE id = @id_transaction

		-- UPDATE THE BALANCE OF THE PERSON DEPENDING ON IF IT IS CLIENT OR SUPPLIER
		UPDATE person SET balance = IIF(@totalsub IS NULL, 0, IIF(@person_type = 1, -@totalsub, @totalsub))
		WHERE id = @person_id

		-- CHANGE THE STOCK AMOUNT IN THE PRODUCTS TABLE

		UPDATE products SET stock = stock - (SELECT I.amount FROM inserted I) WHERE products.id = @product_id
	END

	IF EXISTS(SELECT * FROM deleted)
	BEGIN
		SET @id_transaction = (SELECT i.transaction_id FROM deleted i)
		SET @totalsub = (SELECT SUM(s.total) FROM sub_transactions s WHERE transaction_id = @id_transaction)
		SET @totalsub = IIF(@totalsub IS NULL, 0, @totalsub)
		SET @product_id = (SELECT product_id FROM deleted)

		-- GET THE ID OF THE PERSON
		SET @person_id = (SELECT DISTINCT person FROM transactions
		WHERE id = @id_transaction)
		
		SET @person_type = (SELECT person_type from person where id = @person_id)

		-- UPDATE TOTAL IN TRANSACTION TABLE
		UPDATE transactions SET total = @totalsub WHERE id = @id_transaction

		-- UPDATE THE BALANCE OF THE PERSON DEPENDING ON IF IT IS CLIENT OR SUPPLIER
		UPDATE person SET balance = IIF(@totalsub IS NULL, 0, IIF(@person_type = 1, -@totalsub, @totalsub)) WHERE id = @person_id

		-- CHANGE THE STOCK AMOUNT IN THE PRODUCTS TABLE

		UPDATE products SET stock = stock + (SELECT I.amount FROM deleted I) WHERE products.id = @product_id
	END
END
GO
ALTER TABLE [dbo].[sub_transactions] ENABLE TRIGGER [updatetotal]
GO
/****** Object:  Trigger [dbo].[deletesubtransactions]    Script Date: 30/03/2023 13:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[deletesubtransactions]
ON [dbo].[transactions]
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @transaction_id BIGINT
	SET @transaction_id = (SELECT d.id from deleted d)
	DELETE FROM sub_transactions WHERE transaction_id = @transaction_id
	DELETE FROM transactions WHERE id = @transaction_id
END
GO
ALTER TABLE [dbo].[transactions] ENABLE TRIGGER [deletesubtransactions]
GO
USE [master]
GO
ALTER DATABASE [HahnWarehouse] SET  READ_WRITE 
GO
