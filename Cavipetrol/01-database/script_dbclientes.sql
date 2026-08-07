-- =============================================================================
-- SCRIPT DE CREACIÓN DE BASE DE DATOS, TABLA Y STORED PROCEDURE
-- Proyecto: Prueba Técnica Fullstack (.NET / Angular) - Cavipetrol
-- Motor: SQL Server 2019+
-- =============================================================================

USE master;
GO

-- 1. Creación de la Base de Datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DBClientes')
BEGIN
    CREATE DATABASE DBClientes;
END
GO

USE DBClientes;
GO

-- 2. Creación de la Tabla Clientes
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Clientes;
END
GO

CREATE TABLE dbo.Clientes (
    -- Campos Obligatorios según especificación PDF
    IdCliente INT IDENTITY(1,1) NOT NULL,
    Identificacion VARCHAR(20) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    FechaCreacion DATETIME NOT NULL CONSTRAINT DF_Clientes_FechaCreacion DEFAULT GETDATE(),
    FechaActualizacion DATETIME NULL,
    
    -- Campos Extendidos (Soporte para Dashboard Analítico)
    Genero CHAR(1) NULL,
    FechaNacimiento DATE NULL,
    Estado NVARCHAR(20) NOT NULL CONSTRAINT DF_Clientes_Estado DEFAULT 'Activo',
    Categoria NVARCHAR(30) NOT NULL CONSTRAINT DF_Clientes_Categoria DEFAULT 'Estándar',

    CONSTRAINT PK_Clientes PRIMARY KEY CLUSTERED (IdCliente ASC),
    CONSTRAINT UQ_Clientes_Identificacion UNIQUE NONCLUSTERED (Identificacion ASC)
);
GO

-- Indexación adicional para optimizar la búsqueda por documento
CREATE NONCLUSTERED INDEX IX_Clientes_Identificacion_Lookup 
ON dbo.Clientes (Identificacion)
INCLUDE (Nombre, Apellido, Email, FechaCreacion, FechaActualizacion, Genero, Estado, Categoria);
GO

-- 3. Stored Procedure de Consulta por Número de Identificación (Requerimiento Backend #2)
IF OBJECT_ID('dbo.sp_ObtenerClientePorIdentificacion', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenerClientePorIdentificacion;
END
GO

CREATE PROCEDURE dbo.sp_ObtenerClientePorIdentificacion
    @Identificacion VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCliente,
        Identificacion,
        Nombre,
        Apellido,
        Email,
        FechaCreacion,
        FechaActualizacion,
        Genero,
        FechaNacimiento,
        Estado,
        Categoria
    FROM dbo.Clientes WITH (NOLOCK)
    WHERE Identificacion = @Identificacion;
END;
GO

-- 4. Inserción de Datos de Prueba (Seed Data)
INSERT INTO dbo.Clientes (Identificacion, Nombre, Apellido, Email, Genero, FechaNacimiento, Estado, Categoria)
VALUES 
('12345678', 'Carlos', 'Mendoza', 'carlos.mendoza@cavipetrol.com', 'M', '1985-04-12', 'Activo', 'VIP'),
('10987654', 'María Fernanda', 'Gómez', 'maria.gomez@cavipetrol.com', 'F', '1992-08-25', 'Activo', 'Frecuente'),
('11223344', 'Juan Pablo', 'Martínez', 'juan.martinez@cavipetrol.com', 'M', '2012-05-10', 'Activo', 'Estándar');
GO

-- Prueba de Ejecución del Stored Procedure
EXEC dbo.sp_ObtenerClientePorIdentificacion @Identificacion = '12345678';
GO
