CREATE DATABASE SistemaMantenimiento;
GO
USE SistemaMantenimiento;
GO
CREATE TABLE Usuarios(UsuarioID INT IDENTITY(1,1) PRIMARY KEY,Nombre NVARCHAR(100) NOT NULL,CorreoElectronico NVARCHAR(150) NOT NULL UNIQUE,Telefono NVARCHAR(30) NULL,Clave NVARCHAR(200) NOT NULL CONSTRAINT DF_Usuarios_Clave DEFAULT('123456'));
CREATE TABLE Equipos(EquipoID INT IDENTITY(1,1) PRIMARY KEY,TipoEquipo NVARCHAR(80) NOT NULL,Modelo NVARCHAR(80) NOT NULL,UsuarioID INT NOT NULL,CONSTRAINT FK_Equipos_Usuarios FOREIGN KEY(UsuarioID) REFERENCES Usuarios(UsuarioID));
CREATE TABLE Tecnicos(TecnicoID INT IDENTITY(1,1) PRIMARY KEY,Nombre NVARCHAR(100) NOT NULL,Especialidad NVARCHAR(100) NOT NULL);
CREATE TABLE Reparaciones(ReparacionID INT IDENTITY(1,1) PRIMARY KEY,EquipoID INT NOT NULL,FechaSolicitud DATE NOT NULL,Estado NVARCHAR(40) NOT NULL,CONSTRAINT FK_Reparaciones_Equipos FOREIGN KEY(EquipoID) REFERENCES Equipos(EquipoID));
CREATE TABLE DetallesReparacion(DetalleID INT IDENTITY(1,1) PRIMARY KEY,ReparacionID INT NOT NULL,Descripcion NVARCHAR(1000) NOT NULL,FechaInicio DATE NOT NULL,FechaFin DATE NULL,CONSTRAINT FK_Detalles_Reparaciones FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID));
CREATE TABLE Asignaciones(AsignacionID INT IDENTITY(1,1) PRIMARY KEY,ReparacionID INT NOT NULL,TecnicoID INT NOT NULL,FechaAsignacion DATE NOT NULL,CONSTRAINT FK_Asignaciones_Reparaciones FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID),CONSTRAINT FK_Asignaciones_Tecnicos FOREIGN KEY(TecnicoID) REFERENCES Tecnicos(TecnicoID));
GO

-- Procedimientos almacenados CRUD solicitados por el enunciado.
CREATE OR ALTER PROCEDURE dbo.Usuarios_Listar AS SELECT UsuarioID,Nombre,CorreoElectronico,Telefono FROM Usuarios ORDER BY UsuarioID;
GO
CREATE OR ALTER PROCEDURE dbo.Usuarios_Guardar @Nombre NVARCHAR(100),@CorreoElectronico NVARCHAR(150),@Telefono NVARCHAR(30)=NULL AS INSERT INTO Usuarios(Nombre,CorreoElectronico,Telefono) VALUES(@Nombre,@CorreoElectronico,@Telefono);
GO
CREATE OR ALTER PROCEDURE dbo.Usuarios_Editar @UsuarioID INT,@Nombre NVARCHAR(100),@CorreoElectronico NVARCHAR(150),@Telefono NVARCHAR(30)=NULL AS UPDATE Usuarios SET Nombre=@Nombre,CorreoElectronico=@CorreoElectronico,Telefono=@Telefono WHERE UsuarioID=@UsuarioID;
GO
CREATE OR ALTER PROCEDURE dbo.Usuarios_Eliminar @UsuarioID INT AS DELETE FROM Usuarios WHERE UsuarioID=@UsuarioID;
GO
CREATE OR ALTER PROCEDURE dbo.Equipos_Listar AS SELECT e.EquipoID,e.TipoEquipo,e.Modelo,e.UsuarioID,u.Nombre AS NombreUsuario FROM Equipos e INNER JOIN Usuarios u ON u.UsuarioID=e.UsuarioID ORDER BY e.EquipoID;
GO
CREATE OR ALTER PROCEDURE dbo.Equipos_Guardar @TipoEquipo NVARCHAR(80),@Modelo NVARCHAR(80),@UsuarioID INT AS INSERT INTO Equipos(TipoEquipo,Modelo,UsuarioID) VALUES(@TipoEquipo,@Modelo,@UsuarioID);
GO
CREATE OR ALTER PROCEDURE dbo.Equipos_Editar @EquipoID INT,@TipoEquipo NVARCHAR(80),@Modelo NVARCHAR(80),@UsuarioID INT AS UPDATE Equipos SET TipoEquipo=@TipoEquipo,Modelo=@Modelo,UsuarioID=@UsuarioID WHERE EquipoID=@EquipoID;
GO
CREATE OR ALTER PROCEDURE dbo.Equipos_Eliminar @EquipoID INT AS DELETE FROM Equipos WHERE EquipoID=@EquipoID;
GO
CREATE OR ALTER PROCEDURE dbo.Tecnicos_Listar AS SELECT TecnicoID,Nombre,Especialidad FROM Tecnicos ORDER BY TecnicoID;
GO
CREATE OR ALTER PROCEDURE dbo.Tecnicos_Guardar @Nombre NVARCHAR(100),@Especialidad NVARCHAR(100) AS INSERT INTO Tecnicos(Nombre,Especialidad) VALUES(@Nombre,@Especialidad);
GO
CREATE OR ALTER PROCEDURE dbo.Tecnicos_Editar @TecnicoID INT,@Nombre NVARCHAR(100),@Especialidad NVARCHAR(100) AS UPDATE Tecnicos SET Nombre=@Nombre,Especialidad=@Especialidad WHERE TecnicoID=@TecnicoID;
GO
CREATE OR ALTER PROCEDURE dbo.Tecnicos_Eliminar @TecnicoID INT AS DELETE FROM Tecnicos WHERE TecnicoID=@TecnicoID;
GO
CREATE OR ALTER PROCEDURE dbo.Reparaciones_Listar AS SELECT r.ReparacionID,r.EquipoID,e.TipoEquipo,r.FechaSolicitud,r.Estado FROM Reparaciones r INNER JOIN Equipos e ON e.EquipoID=r.EquipoID ORDER BY r.ReparacionID;
GO
CREATE OR ALTER PROCEDURE dbo.Reparaciones_Guardar @EquipoID INT,@FechaSolicitud DATE,@Estado NVARCHAR(40) AS INSERT INTO Reparaciones(EquipoID,FechaSolicitud,Estado) VALUES(@EquipoID,@FechaSolicitud,@Estado);
GO
CREATE OR ALTER PROCEDURE dbo.Reparaciones_Editar @ReparacionID INT,@EquipoID INT,@FechaSolicitud DATE,@Estado NVARCHAR(40) AS UPDATE Reparaciones SET EquipoID=@EquipoID,FechaSolicitud=@FechaSolicitud,Estado=@Estado WHERE ReparacionID=@ReparacionID;
GO
CREATE OR ALTER PROCEDURE dbo.Reparaciones_Eliminar @ReparacionID INT AS DELETE FROM Reparaciones WHERE ReparacionID=@ReparacionID;
GO
CREATE OR ALTER PROCEDURE dbo.DetallesReparacion_Listar AS SELECT DetalleID,ReparacionID,Descripcion,FechaInicio,FechaFin FROM DetallesReparacion ORDER BY DetalleID;
GO
CREATE OR ALTER PROCEDURE dbo.DetallesReparacion_Guardar @ReparacionID INT,@Descripcion NVARCHAR(1000),@FechaInicio DATE,@FechaFin DATE=NULL AS INSERT INTO DetallesReparacion(ReparacionID,Descripcion,FechaInicio,FechaFin) VALUES(@ReparacionID,@Descripcion,@FechaInicio,@FechaFin);
GO
CREATE OR ALTER PROCEDURE dbo.DetallesReparacion_Editar @DetalleID INT,@ReparacionID INT,@Descripcion NVARCHAR(1000),@FechaInicio DATE,@FechaFin DATE=NULL AS UPDATE DetallesReparacion SET ReparacionID=@ReparacionID,Descripcion=@Descripcion,FechaInicio=@FechaInicio,FechaFin=@FechaFin WHERE DetalleID=@DetalleID;
GO
CREATE OR ALTER PROCEDURE dbo.DetallesReparacion_Eliminar @DetalleID INT AS DELETE FROM DetallesReparacion WHERE DetalleID=@DetalleID;
GO
CREATE OR ALTER PROCEDURE dbo.Asignaciones_Listar AS SELECT a.AsignacionID,a.ReparacionID,a.TecnicoID,a.FechaAsignacion,t.Nombre AS NombreTecnico,r.Estado AS EstadoReparacion FROM Asignaciones a INNER JOIN Tecnicos t ON t.TecnicoID=a.TecnicoID INNER JOIN Reparaciones r ON r.ReparacionID=a.ReparacionID ORDER BY a.AsignacionID;
GO
CREATE OR ALTER PROCEDURE dbo.Asignaciones_Guardar @ReparacionID INT,@TecnicoID INT,@FechaAsignacion DATE AS INSERT INTO Asignaciones(ReparacionID,TecnicoID,FechaAsignacion) VALUES(@ReparacionID,@TecnicoID,@FechaAsignacion);
GO
CREATE OR ALTER PROCEDURE dbo.Asignaciones_Editar @AsignacionID INT,@ReparacionID INT,@TecnicoID INT,@FechaAsignacion DATE AS UPDATE Asignaciones SET ReparacionID=@ReparacionID,TecnicoID=@TecnicoID,FechaAsignacion=@FechaAsignacion WHERE AsignacionID=@AsignacionID;
GO
CREATE OR ALTER PROCEDURE dbo.Asignaciones_Eliminar @AsignacionID INT AS DELETE FROM Asignaciones WHERE AsignacionID=@AsignacionID;
GO

CREATE OR ALTER PROCEDURE dbo.Login_Validar @CorreoElectronico NVARCHAR(150), @Clave NVARCHAR(200) AS SELECT TOP 1 UsuarioID,Nombre,CorreoElectronico FROM Usuarios WHERE CorreoElectronico=@CorreoElectronico AND Clave=@Clave;
GO

-- Usuario inicial de prueba para verificar el acceso al sistema.
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE CorreoElectronico='admin@sistema.local') INSERT INTO Usuarios(Nombre,CorreoElectronico,Telefono,Clave) VALUES('Administrador','admin@sistema.local','0000000000','123456');
GO

-- El borrado respeta las claves foráneas: primero deben eliminarse los registros dependientes.

-- Consultas individuales utilizadas por las pantallas de edición.
CREATE OR ALTER PROCEDURE dbo.Usuarios_Obtener @UsuarioID INT AS SELECT UsuarioID,Nombre,CorreoElectronico,Telefono FROM Usuarios WHERE UsuarioID=@UsuarioID;
GO
CREATE OR ALTER PROCEDURE dbo.Equipos_Obtener @EquipoID INT AS SELECT EquipoID,TipoEquipo,Modelo,UsuarioID FROM Equipos WHERE EquipoID=@EquipoID;
GO
CREATE OR ALTER PROCEDURE dbo.Tecnicos_Obtener @TecnicoID INT AS SELECT TecnicoID,Nombre,Especialidad FROM Tecnicos WHERE TecnicoID=@TecnicoID;
GO
CREATE OR ALTER PROCEDURE dbo.Reparaciones_Obtener @ReparacionID INT AS SELECT ReparacionID,EquipoID,FechaSolicitud,Estado FROM Reparaciones WHERE ReparacionID=@ReparacionID;
GO
CREATE OR ALTER PROCEDURE dbo.DetallesReparacion_Obtener @DetalleID INT AS SELECT DetalleID,ReparacionID,Descripcion,FechaInicio,FechaFin FROM DetallesReparacion WHERE DetalleID=@DetalleID;
GO
CREATE OR ALTER PROCEDURE dbo.Asignaciones_Obtener @AsignacionID INT AS SELECT AsignacionID,ReparacionID,TecnicoID,FechaAsignacion FROM Asignaciones WHERE AsignacionID=@AsignacionID;
GO
