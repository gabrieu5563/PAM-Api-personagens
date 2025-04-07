BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGEM] ADD [FotoPersonagem] varbinary(max) NULL;

ALTER TABLE [TB_PERSONAGEM] ADD [UsuarioId] int NULL;

CREATE TABLE [TB_ARMAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([Id])
);

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NOT NULL,
    [Perfil] nvarchar(max) NULL DEFAULT N'Jogador',
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);

UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [FotoPersonagem] = NULL, [UsuarioId] = 1
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


CREATE INDEX [IX_TB_PERSONAGEM_UsuarioId] ON [TB_PERSONAGEM] ([UsuarioId]);

ALTER TABLE [TB_PERSONAGEM] ADD CONSTRAINT [FK_TB_PERSONAGEM_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250407110819_MigracaoUsuario', N'9.0.2');

COMMIT;
GO

