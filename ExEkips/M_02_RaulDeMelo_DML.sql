use M_Ekips

-- INSERÇÃO DE INERÊNCIA AUTENTICAÇÃO-AUTORIZAÇÃO - {PERMISSÕES}
insert into Permissao (Nome) values ('COMUM'), ('ADMINISTRADOR');

-- INSERÇÃO DE DADOS - {CARGOS}
insert into Cargo (Nome) values ('Advogado trabalhista'), ('Product Owner');

-- INSERÇÃO DE DADOS - {DEPARTAMENTOS}
insert into Departamento (Nome, Ativo) values ('Departamento de Tecnologia', 1), ('Departamento Jurídico', 0);

-- INSERÇÃO DE DADOS - {FUNCIONÁRIOS}
insert into Funcionario (Nome, Email, Senha, CPF, Salario, IdCargo, IdDepartamento, IdPermissao) values 
('Bob', 'bob@comum.com', '22016064', '648.346.530-05', '2.020,80', 1, 2, 1),
('Fernando', 'fernando@admin.com', '60642201', '080.392.210-80', '3.543,42', 2, 1, 2);