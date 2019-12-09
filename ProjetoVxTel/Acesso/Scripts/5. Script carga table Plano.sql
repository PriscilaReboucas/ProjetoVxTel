/*
Autor: Priscila
Descrição: Script carga tabela Plano
*/

/*
Autor: Priscila Rebouças
Descrição: Script carga na tabela Plano
*/

USE [BD_VXTEL]
GO

INSERT INTO [dbo].[Plano]
           ([Descricao]
           ,[QuantidadeMinuto])
     VALUES
           ('FaleMais 30'
           ,30)
GO

INSERT INTO [dbo].[Plano]
           ([Descricao]
           ,[QuantidadeMinuto])
     VALUES
           ('FaleMais 60'
           ,60)
GO

INSERT INTO [dbo].[Plano]
           ([Descricao]
           ,[QuantidadeMinuto])
     VALUES
           ('FaleMais 120'
           ,120)
GO


