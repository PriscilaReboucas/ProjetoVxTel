USE [BD_VXTEL]
GO

/*
Autor: Priscila Rebouças
Descrição: Script para criação da tabela Plano
*/

CREATE TABLE [dbo].[Plano](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[QuantidadeMinuto] [int] NOT NULL,
 CONSTRAINT [PK_Plano] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


