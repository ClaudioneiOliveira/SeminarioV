SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Editoras]    Script Date: 16/04/2018 21:43:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Editoras]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Editoras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [char](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
))
END
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/04/2018 21:43:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [char](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
))
END
GO

/****** Object:  Table [dbo].[Livros]    Script Date: 16/04/2018 21:43:48 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Livros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Livros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [char](255) NOT NULL,
	[isbn] [char](255) NOT NULL,
	[editora] [int] NOT NULL,
	[paginas] [int] NOT NULL,
	[ano] [int] NOT NULL,
	[codBarras] [char](20) NULL,
	[resenha] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
))
END
GO

/****** Object:  Table [dbo].[Emprestimos]    Script Date: 16/04/2018 21:43:48 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Emprestimos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Emprestimos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idLivro] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[dataRetirada] [datetime] NOT NULL,
	[dataPrevistaDevolucao] [datetime] NULL,
	[dataRealDevolucao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
))
END
GO

/****** Object:  Table [dbo].[ControleEmprestimos]    Script Date: 16/04/2018 21:43:48 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControleEmprestimos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ControleEmprestimos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmprestimo] [int] NOT NULL,
	[dataRetirada] [datetime] NOT NULL,
	[dataPrevistaDevolucao] [datetime] NULL,
	[dataRealDevolucao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
))
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Livros_Editoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Livros]'))
ALTER TABLE [dbo].[Livros]  WITH CHECK ADD  CONSTRAINT [FK_Livros_Editoras] FOREIGN KEY([editora])
REFERENCES [dbo].[Editoras] ([id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Livros_Editoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Livros]'))
ALTER TABLE [dbo].[Livros] CHECK CONSTRAINT [FK_Livros_Editoras]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Emprestimos_Livros]') AND parent_object_id = OBJECT_ID(N'[dbo].[Emprestimos]'))
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimos_Livros] FOREIGN KEY([idLivro])
REFERENCES [dbo].[Livros] ([id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Emprestimos_Livros]') AND parent_object_id = OBJECT_ID(N'[dbo].[Emprestimos]'))
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_Emprestimos_Livros]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Emprestimos_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Emprestimos]'))
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimos_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Emprestimos_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Emprestimos]'))
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_Emprestimos_Usuarios]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ControleEmprestimos_Emprestimos]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControleEmprestimos]'))
ALTER TABLE [dbo].[ControleEmprestimos]  WITH CHECK ADD  CONSTRAINT [FK_ControleEmprestimos_Emprestimos] FOREIGN KEY([idEmprestimo])
REFERENCES [dbo].[Emprestimos] ([id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ControleEmprestimos_Emprestimos]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControleEmprestimos]'))
ALTER TABLE [dbo].[ControleEmprestimos] CHECK CONSTRAINT [FK_ControleEmprestimos_Emprestimos]
GO
