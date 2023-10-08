CREATE TABLE tblEmployee (
    employeeID INT IDENTITY(1,1) PRIMARY KEY,
    Documento INT NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Apellidos NVARCHAR(255) NOT NULL,
    Tel�fono NVARCHAR(20) NOT NULL,
    EMail NVARCHAR(255) NOT NULL,
    Direcci�n NVARCHAR(255) NOT NULL,
    G�nero NVARCHAR(1) CHECK (G�nero IN ('M', 'F')) NOT NULL
);