USE [BDPulsacion]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 4/03/2020 9:57:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Identificacion] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Sexo] [nvarchar](2) NULL,
	[Edad] [int] NULL,
	[Pulsacion] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

