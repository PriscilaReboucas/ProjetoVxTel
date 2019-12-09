/*
Autor: Priscila Rebouças
Descrição: Script carga na tabela Chamada
*/

USE [BD_VXTEL]
GO
	
INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (11
           ,16
           ,'1.90')
GO

INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (16
           ,11
           ,'2.90')
GO

INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (11
           ,17
           ,'1.70')
GO
INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (17
           ,11
           ,'2.70')
GO

INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (11
           ,18
           ,'0.90')
GO

INSERT INTO [dbo].[Chamada]
           ([CodigoDDDOrigem]
           ,[CodigoDDDDestino]
           ,[ValorMinuto])
     VALUES
           (18
           ,11
           ,'1.90')
GO




