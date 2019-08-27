CREATE DATABASE Optus;

USE Optus;

CREATE TABLE Estilos
(
    IdEstilo    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Artistas
(
    IdArtista     INT PRIMARY KEY IDENTITY
    ,Nome		  VARCHAR(200) UNIQUE
    ,IdEstilo     INT FOREIGN KEY REFERENCES Estilos (IdEstilo)
);

SELECT * FROM Estilos;

INSERT INTO Estilos (Nome) VALUES ('Folk');
INSERT INTO Estilos (Nome) VALUES ('Rock');
INSERT INTO Estilos (Nome) VALUES ('Pop');
INSERT INTO Estilos (Nome) VALUES ('Samba');
INSERT INTO Artistas (Nome, IdEstilo) VALUES ('Stu Larsen', 1);

SELECT * FROM ARTISTAS;

SELECT A.IdArtista, A.Nome, A.IdEstilo, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN Estilos E ON A.IdEstilo = E.IdEstilo;

CREATE TABLE Usuarios 
(
	IdUsuario 	INT PRIMARY KEY IDENTITY
	,Email		VARCHAR(255) NOT NULL UNIQUE
	,Senha		VARCHAR(255) NOT NULL
	,Permissao	VARCHAR(255) NOT NULL
);

INSERT INTO Usuarios (Email, Senha, Permissao) VALUES ('admin@email.com', '123456', 'ADMINISTRADOR');
INSERT INTO Usuarios (Email, Senha, Permissao) VALUES ('comum@email.com', '123456', 'COMUM');