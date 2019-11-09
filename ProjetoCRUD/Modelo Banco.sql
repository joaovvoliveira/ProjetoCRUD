create database db_ProjetoCRUD
go

use db_ProjetoCRUD
go

create table tb_LoginUsuarios
(
	IdUsuario int Primary key identity,
	Usuario varchar (20),
	Senha varchar (20)
)

create table tb_Pessoas
(
	IdCliente int Primary key identity,
	Nome varchar (50),
	CPF varchar (11),
	DataNascimento varchar (10),
	Email varchar (70),
	Telefone varchar(11),
	Fk_Enderecos_IdEndereco int,
	Fk_LoginUsuarios_IdUsuario int,
	Ativo bit
)
go

create table tb_Enderecos
(
	IdEndereco int primary key identity,
	Rua varchar (50),
	Numero varchar (5),
	Bairro varchar (50),
	Cidade varchar (50),
	Cep varchar (9)
)
go

alter table tb_Pessoas
	add constraint Fk_Enderecos_Pessoas foreign key (Fk_Enderecos_IdEndereco)
	references tb_Enderecos(IdEndereco)

alter table tb_Pessoas
	add constraint Fk_LoginUsuarios_Pessoas foreign key (Fk_LoginUsuarios_IdUsuario)
	references tb_LoginUsuarios(IdUsuario)

select Fk_Enderecos_IdEndereco from pessoas

declare @FkEndereco int
update Pessoas
Set Nome = 'teste1', CPF = 'teste1', DataNascimento = '1993-02-05', Email = 'teste1', Telefone = 'teste1', @FkEndereco = (select Fk_Enderecos_IdEndereco from Pessoas where IdCliente = 7)
where IdCliente = 2

update Enderecos
set Rua = 'teste1', Numero = 'te', Bairro = 'teste1', Cidade = 'teste1', Cep = 'teste1'
where IdEndereco = @FkEndereco

select * from tb_Pessoas
select * from Enderecos

insert into tb_LoginUsuarios (Usuario, Senha)
values ('Admin', 'Admin')

insert into Pessoas (Nome, CPF, DataNascimento, Email, Telefone, Fk_Enderecos_IdEndereco)
values ('Limpa', 'Limpa', '1993-02-05', 'Limpa', 'Limpa', 4)

update tb_Pessoas
set Ativo = 0
where IdCliente = 1