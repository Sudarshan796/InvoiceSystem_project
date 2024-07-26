USE [InvoiceSystem]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 25-Jul-24 12:23:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[CategoryId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[InvoiceNumber] [varchar](100) NULL,
	[ReferenceNumber] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


