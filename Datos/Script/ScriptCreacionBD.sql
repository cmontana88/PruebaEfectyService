IF NOT EXISTS(SELECT 1 FROM sys.sysdatabases WHERE name = 'PruebaEfecty')
BEGIN
	CREATE DATABASE PruebaEfecty
END
GO

USE PruebaEfecty
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'TipoDocumento')
BEGIN
	CREATE TABLE TipoDocumento (
		Id			INT IDENTITY,
		Valor		VARCHAR(20),
		CONSTRAINT PK_TipoDocumento PRIMARY KEY (Id)
	)
END
GO

INSERT INTO TipoDocumento VALUES('Cedula de Ciudadania'), ('Registro Civil'), ('Tarjeta de Identidad')

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'Persona')
BEGIN
	CREATE TABLE Persona (
		Id					INT IDENTITY,
		Nombres				VARCHAR(50),
		Apellidos			VARCHAR(50),
		TipoDocumento		INT,
		FechaNacimiento		DATETIME,
		ValoraGanar			DECIMAL(20, 2),
		EstadoCivil			BIT,
		CONSTRAINT PK_Customer PRIMARY KEY (Id),
		CONSTRAINT	FK_TipoDocumento FOREIGN KEY (TipoDocumento) REFERENCES TipoDocumento(Id),
	)
END
GO




