USE [Inova.Farm]
GO

INSERT INTO [dbo].[User]
           ([Name],[FarmName],[MainFruit],[Login],[Password])
     VALUES
           ('Teste','Fazenda Teste','Uva','teste@teste.com','123456')
GO

INSERT INTO [dbo].[Fruit]
           ([Name],[Especie])
     VALUES('Uva','N�o identificado')
GO

INSERT INTO [dbo].[ProductionPhase]
           ([FaseFenologica],[KCNumber],[FruitId])
     VALUES('produ��o' ,0.0, 1)
GO

INSERT INTO [dbo].[ProductionPhase]
           ([FaseFenologica],[KCNumber],[FruitId])
     VALUES('cultivo' ,0.0, 1)
GO

