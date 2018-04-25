USE [ssql_housedreaming]
GO

/****** Object:  Table [dbo].[Listing_Residential]    Script Date: 04/25/2018 09:33:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[payment](
	[paymentID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[agencyID] [int] NULL,
	[createDate] [DateTime] NULL,
	[status] [int] NULL,
	[totalAmount] [int] NOT NULL,
	[payDate] [DateTime] NOT NULL
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[paymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

