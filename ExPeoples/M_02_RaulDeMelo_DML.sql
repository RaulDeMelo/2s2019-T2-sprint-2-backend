use M_Peoples

-- INSER��O DE DADOS EM FUNCION�RIOS
insert into Funcionario (Nome, Sobrenome) values ('Raul', 'Melo');
insert into Funcionario (Nome, Sobrenome) values ('Henrique', 'Carvalho');
insert into Funcionario (Nome, Sobrenome) values ('Jonathas', 'Brutus');


insert into Funcionario (Nome, Sobrenome) values (@Nome, @Sobrenome);