create database M_Peoples

use M_Peoples

-- CRIAÇÃO TABELA DE FUNCIONÁRIOS
create table Funcionario(
	IdFuncionario int primary key identity
	,Nome varchar (255) not null
	,Sobrenome varchar (255) not null
)