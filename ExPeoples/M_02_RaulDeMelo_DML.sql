use M_Peoples

-- INSERÇÃO DE DADOS EM FUNCIONÁRIOS
insert into Funcionario (Nome, Sobrenome) values ('Raul', 'Melo');
insert into Funcionario (Nome, Sobrenome) values ('Henrique', 'Carvalho');
insert into Funcionario (Nome, Sobrenome) values ('Jonathas', 'Brutus');


insert into Funcionario (Nome, Sobrenome) values (@Nome, @Sobrenome);