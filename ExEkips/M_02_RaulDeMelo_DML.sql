use M_Ekips

-- INSERÇÃO DE INERÊNCIA AUTENTICAÇÃO-AUTORIZAÇÃO - {PERMISSÕES}
insert into Permissao (Nome) values ('COMUM'), ('ADMINISTRADOR');

-- INSERÇÃO DE DADOS - {CARGOS}
insert into Cargo (Nome, Ativo) values ('Advogado trabalhista', 0), ('Product Owner', 1);

-- INSERÇÃO DE DADOS - {DEPARTAMENTOS}
insert into Departamento (Nome) values ('Departamento de Tecnologia'), ('Departamento Jurídico');

-- INSERÇÃO DE DADOS - {FUNCIONÁRIOS}
insert into Funcionario (Nome, Email, Senha, CPF, Salario, IdCargo, IdDepartamento, IdPermissao) values 
('Bob', 'bob@comum.com', '22016064', '648.346.530-05', '2.020,80', 1, 2, 1),
('Fernando', 'fernando@admin.com', '60642201', '080.392.210-80', '3.543,42', 2, 1, 2);