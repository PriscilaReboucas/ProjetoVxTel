USE [BD_VXTEL]
GO
/*
Autor: Priscila Rebouças
Descrição : Script criação tabela Chamada

*/

CREATE TABLE [dbo].[Chamada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoDDDOrigem] [int] NOT NULL,
	[CodigoDDDDestino] [int] NOT NULL,
	[ValorMinuto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ChaAmada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Chamada]  WITH CHECK ADD  CONSTRAINT [FK_Chamada_DDD_Codigo_Destino] FOREIGN KEY([CodigoDDDDestino])
REFERENCES [dbo].[DDD] ([Codigo])
GO

ALTER TABLE [dbo].[Chamada] CHECK CONSTRAINT [FK_Chamada_DDD_Codigo_Destino]
GO

ALTER TABLE [dbo].[Chamada]  WITH CHECK ADD  CONSTRAINT [FK_Chamada_DDD_Codigo_Origem] FOREIGN KEY([CodigoDDDOrigem])
REFERENCES [dbo].[DDD] ([Codigo])
GO

ALTER TABLE [dbo].[Chamada] CHECK CONSTRAINT [FK_Chamada_DDD_Codigo_Origem]
GO


