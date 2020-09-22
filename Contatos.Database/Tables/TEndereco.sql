CREATE TABLE [dbo].[TEndereco]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Cep] VARCHAR(50) NULL, 
    [Logradouro] VARCHAR(50) NULL, 
    [Numero] VARCHAR(50) NULL, 
    [Estado] VARCHAR(50) NULL, 
    [Complemento] VARCHAR(50) NULL, 
    [Cidade] VARCHAR(50) NULL, 
    [IdContato] BIGINT NULL, 
    CONSTRAINT [FK_TEndereco_TContato] FOREIGN KEY ([IdContato]) REFERENCES [TContato]([Id])
)
