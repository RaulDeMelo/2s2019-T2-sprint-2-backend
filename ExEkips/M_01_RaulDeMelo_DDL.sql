-- CRIAÇÃO DATABASE
create database M_Ekips

use M_Ekips

-- TABELA DE PERMISSÕES
create table Permissao(
	IdPermissao int primary key identity
	,Nome varchar (255) not null
)

-- TABELA DE CARGOS
create table Cargo(
	IdCargo int primary key identity
	,Nome varchar (255) not null
)

-- TABELA DE DEPARTAMENTOS
create table Departamento(
	IdDepartamento int primary key identity
	,Nome varchar (255) not null
	,Ativo bit default(0)
)

-- TABELA DE FUNCIONÁRIOS
create table Funcionario(
	IdFuncionario int primary key identity
	,Nome varchar (255) not null
	,Email varchar (255) not null unique
	,Senha varchar (255) not null
	,CPF varchar (255) not null unique
	,Salario money not null
	,IdCargo int foreign key references Cargo (IdCargo)
	,IdDepartamento int foreign key references Departamento (IdDepartamento)
	,IdPermissao int foreign key references Permissao (IdPermissao)
)