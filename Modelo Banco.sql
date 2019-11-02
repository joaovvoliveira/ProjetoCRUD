create database ProjetoCRUD
go

use ProjetoCRUD
go

create table Clientes
(
	IdCLiente int Primary key identity,
	Nome varchar (50),
	CPF varchar (11),
	DataNascimento Date,
	Email varchar (70),
	Telefone varchar(11)
)
go

create table Enderecos
(
	IdEndereco int primary key identity,
	Rua varchar (50),
	Numero varchar (5),
	Bairro varchar (50),
	Cidade varchar (50),
	Estado varchar (50),
	Cep varchar (9),
	Fk_Clientes_IdCliente int
)
go

alter table Enderecos
	add constraint Fk_Clientes_Enderecos foreign key (Fk_Clientes_IdCliente)
	references Clientes(IdCliente)

select * from Clientes
inner join Enderecos
on Enderecos.Fk_Clientes_IdCliente = Clientes.IdCLiente
select * from Enderecos

select * from Clientes