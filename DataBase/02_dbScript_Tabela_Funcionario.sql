CREATE DATABASE dbFinanceiro
go
use dbFinanceiro
go

Create table AGENCIA (
Codigo int identity(1,1) primary key,
Nome varchar(100),
Cidade varchar(100),
EstadoUF varchar(100)
)
go


Create table FUNCIONARIO(
Codigo identity(1,1) primary key,
Nome varchar(100),
DataNascimento datetime,
Cidade varchar(50),
EstadoUF varchar(20),
CPF varchar(20),
Telefone varchar(20)
)