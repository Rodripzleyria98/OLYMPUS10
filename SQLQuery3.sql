CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
	Apellido NVARCHAR(50) NOT NULL,
	Direccion NVARCHAR(100) NOT NULL,
	Telefono NVARCHAR(15) NOT NULL,
	FechaAlta DATE NOT NULL,
	Gmail NVARCHAR(100) NOT NULL,       
    Planes VARCHAR(50) NOT NULL,             
    Precio DECIMAL(10,2) NOT NULL           
);


CREATE TABLE Pagos (
    PagoID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteNombre NVARCHAR(100),
    ClienteApellido NVARCHAR(100),
    FechaPago DATETIME,
    Monto DECIMAL(18,2),
    EstadoPago NVARCHAR(50) -- Ejemplo: 'Pendiente', 'Pagado'
);

ALTER TABLE Pagos
ALTER COLUMN Monto DECIMAL(18,2) NULL;

ALTER TABLE Pagos
ADD FechaRenovacion DATETIME NULL;

UPDATE Pagos
SET FechaRenovacion = DATEADD(MONTH, 1, FechaPago)
WHERE ClienteNombre = @ClienteNombre AND ClienteApellido = @ClienteApellido;

ALTER TABLE Pagos
ADD FechaVencimiento DATETIME NOT NULL DEFAULT GETDATE();
