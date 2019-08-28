use M_Ekips

-- INSER��O DE INER�NCIA AUTENTICA��O-AUTORIZA��O - {PERMISS�ES}
insert into Permissao (Nome) values ('COMUM'), ('ADMINISTRADOR');

-- INSER��O DE DADOS - {CARGOS}
insert into Cargo (Nome) values ('Advogado trabalhista'), ('Product Owner');

-- INSER��O DE DADOS - {DEPARTAMENTOS}
insert into Departamento (Nome, Ativo) values ('Departamento de Tecnologia', 1), ('Departamento Jur�dico', 0);

-- INSER��O DE DADOS - {FUNCION�RIOS}
insert into Funcionario (Nome, Email, Senha, CPF, Salario, IdCargo, IdDepartamento, IdPermissao) values 
('Bob', 'bob@comum.com', '22016064', '648.346.530-05', '2.020,80', 1, 2, 1),
('Fernando', 'fernando@admin.com', '60642201', '080.392.210-80', '3.543,42', 2, 1, 2);