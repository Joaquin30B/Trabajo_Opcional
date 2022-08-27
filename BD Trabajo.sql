CREATE DATABASE TRABAJOS
GO
USE TRABAJOS
GO

CREATE TABLE Especialidad(
ID INT Identity(1,1) Constraint PKEspecialidad Primary Key,
Nombre_Esp VARCHAR(20) NOT NULL,
)
GO

CREATE TABLE Sueldo(
ID INT Identity(1,1) Constraint PKSueldo Primary Key,
Monto VARCHAR(20) NOT NULL,
)
GO

CREATE TABLE Trabajador(
ID INT Identity(1,1) Constraint PKTrabajador Primary Key,
Nombres VARCHAR(40) NOT NULL,
Apellidos VARCHAR(40) NOT NULL,
Direccion VARCHAR(80) NOT NULL,
Telefono CHAR(16)NOT NULL,
IdEspecialidad INT Constraint FKTrabajadorEspecialidad Foreign Key References Especialidad(ID),
IdSueldo INT Constraint FKTrabajadorSueldo Foreign Key References Sueldo(ID),
)
GO



/*Especialida */
SELECT * FROM Especialidad;

INSERT INTO Especialidad  VALUES('COMPUTACION')
INSERT INTO Especialidad  VALUES('CONTADOR')
INSERT INTO Especialidad  VALUES('LIMPIEZA')
INSERT INTO Especialidad  VALUES('VENTAS')

 /*Sueldo */
SELECT * FROM Sueldo;

INSERT INTO Sueldo  VALUES(700.50)
INSERT INTO Sueldo  VALUES(1000)
INSERT INTO Sueldo  VALUES(400)
INSERT INTO Sueldo  VALUES(150.90)


/*SELECT*/
	 SELECT T.ID,T.Nombres +  ' ' + Apellidos AS Nombre_Trabajador,T.Direccion,E.Nombre_Esp
     FROM Trabajador T
	 INNER JOIN Especialidad E ON T.IdEspecialidad =E.ID;


