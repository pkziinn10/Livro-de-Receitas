CREATE TABLE [Livro de Receitas].dbo.[User] (
	id bigint IDENTITY(1,1) NOT NULL,
	CreatedOn datetime NOT NULL,
	Active tinyint NOT NULL,
	Name varchar(45) IDENTITY(1,1) NOT NULL,
	Email varchar(45) IDENTITY(1,1) NOT NULL,
	Password varchar(45) IDENTITY(1,1) NOT NULL,
	CONSTRAINT User_PK PRIMARY KEY (id)
);
EXEC [Livro de Receitas].sys.sp_addextendedproperty 'MS_Description', N'1', 'schema', N'dbo', 'table', N'User', 'column', N'Active';
