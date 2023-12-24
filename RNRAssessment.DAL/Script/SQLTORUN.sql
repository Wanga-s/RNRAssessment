USE [RnrDb]
GO
/****** Object:  Table [dbo].[Breakdowns]    Script Date: 2023/12/24 17:27:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breakdowns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BreakdownReference] [nvarchar](max) unique NULL,
	[CompanyName] [nvarchar](max) NULL,
	[DriverName] [nvarchar](max) NULL,
	[RegistrationNumber] [nvarchar](max) NULL,
	[BreakdownDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Breakdowns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO