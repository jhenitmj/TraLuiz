create database oil
use oil

create table usuario
(
	cod int primary key,
	email varchar(50),
	senha varchar(50)
);

create table oleo
(
	codOleo int primary key,
	nome varchar(50),
	categoria varchar(50),
	tipo varchar(50),
	fabricante varchar(50),
	valor decimal(5,2)
);

create table cliente
(
	codCli int primary key,
	nome varchar(50),
	veiculo varchar(50),
	placa varchar(50),
	email varchar(50)
);

create table troca
(
	cod int primary key,
	data datetime,
	codCli int foreign key references cliente,
	codOleo int foreign key references oleo,
	litros int
);

BULK INSERT usuario
FROM '‪C:\Users\Particular\Desktop\usuarios.txt'

BULK INSERT oleo
FROM 'C:\Users\Particular\Downloads\Oleos.txt'


BULK INSERT cliente
FROM '‪C:\Users\Particular\Downloads\Clientes.txt'



