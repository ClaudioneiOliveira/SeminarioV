-- =====================================================
-- Create External Table Template for Azure SQL Database
-- =====================================================

IF OBJECT_ID('dbo.Livros', 'U') IS NOT NULL
    DROP TABLE dbo.Livros
GO

CREATE TABLE dbo.Livros
(
    id int identity(1,1) not null primary key,
    nome char(255) NOT NULL,
	isbn char(255) NOT NULL,
	editora int NOT NULL,
	paginas int NOT NULL,
	ano int NOT NULL,
	codBarras char(20),
	resenha varchar(1000) NOT NULL
)


IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
    DROP TABLE dbo.Usuarios
GO

CREATE TABLE dbo.Usuarios
(
    id int identity(1,1) not null primary key,
    nome char(255) NOT NULL
)
GO

IF OBJECT_ID('dbo.Editoras', 'U') IS NOT NULL
    DROP TABLE dbo.Editoras
GO

CREATE TABLE dbo.Editoras
(
    id int identity(1,1) not null primary key,
    nome char(255) NOT NULL
)
GO

IF OBJECT_ID('dbo.Emprestimos', 'U') IS NOT NULL
    DROP TABLE dbo.Emprestimos
GO

CREATE TABLE dbo.Emprestimos
(
    id int identity(1,1) not null primary key,
    idLivro int not null,
	idUsuario int not null,
	dataRetirada datetime not null,
	dataPrevistaDevolucao datetime,
	dataRealDevolucao datetime, 
)
GO

IF OBJECT_ID('dbo.ControleEmprestimos', 'U') IS NOT NULL
    DROP TABLE dbo.ControleEmprestimos
GO

CREATE TABLE dbo.ControleEmprestimos
(
    id int identity(1,1) not null primary key,
    idEmprestimo int not null,
	dataRetirada datetime not null,
	dataPrevistaDevolucao datetime,
	dataRealDevolucao datetime, 
)
GO

IF OBJECT_ID('dbo.MultaEmprestimos', 'U') IS NOT NULL
    DROP TABLE dbo.MultaEmprestimos
GO

CREATE TABLE dbo.MultaEmprestimos
(
    id int identity(1,1) not null primary key,
    idEmprestimo int not null,
	valor decimal(12,2),
	data datetime
)
GO