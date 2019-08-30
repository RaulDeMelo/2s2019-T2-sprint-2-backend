use M_Ekips

-- SELEÇÃO BÁSICA DE TODAS AS TABELAS SQL
	select * from Permissao
	select * from Cargo
	select * from Departamento
	select * from Funcionario

-- VIEW USUÁRIOS
	create view 

	select * from cargo where Ativo = 1

-- MÉTODO LISTAGEM ESTRITA ADMIN
	select F.Nome as NomeDoFuncionario, C.Nome as Cargo, D.Nome as Departamento 
	from Funcionario as F 
	inner join Cargo as C
	on C.IdCargo = F.IdCargo
	join Departamento as D
	on D.IdDepartamento = F.IdDepartamento