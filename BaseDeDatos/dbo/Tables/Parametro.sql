﻿CREATE TABLE [dbo].[Parametro]
(
	Id_Parametro INT NOT NULL IDENTITY(1,1) 
	CONSTRAINT PK_PROVEEDOR PRIMARY KEY CLUSTERED(Id_Parametro),
	Codigo VARCHAR(250) NOT NULL
	,Descripcion VARCHAR(250) NULL
	,Valor VARCHAR(250) NOT NULL
	,Estado BIT NOT NULL
)
WITH(DATA_COMPRESSION = PAGE)
GO


