create database ComprasDb
go

use ComprasDb

create table productos
(
	Id int primary key identity,
	Descripcion varchar(30),
	Existencia int,
	Costo decimal,
	ValorInventario decimal,




);
create table valorInventario(
	
	valorTotalInventario decimal
);