CREATE TABLE tblEmployee (
    employeeID INT IDENTITY(1,1) PRIMARY KEY,
    Documento INT NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Apellidos NVARCHAR(255) NOT NULL,
    Teléfono NVARCHAR(20) NOT NULL,
    EMail NVARCHAR(255) NOT NULL,
    Dirección NVARCHAR(255) NOT NULL,
    Género NVARCHAR(1) CHECK (Género IN ('M', 'F')) NOT NULL
);