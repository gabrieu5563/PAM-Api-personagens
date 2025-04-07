BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGEM] ADD [Derrotas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGEM] ADD [Disputas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGEM] ADD [Vitorias] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_ARMAS] ADD [PersonagemId] int NOT NULL DEFAULT 0;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([Id], [Dano], [Nome], [PersonagemId])
VALUES (1, 35, N'arco', 1),
(2, 35, N'arco', 2),
(3, 35, N'arco', 3),
(4, 35, N'arco', 4),
(5, 35, N'arco', 5),
(6, 35, N'arco', 6),
(7, 35, N'arco', 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGEM] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


CREATE UNIQUE INDEX [IX_TB_ARMAS_PersonagemId] ON [TB_ARMAS] ([PersonagemId]);

ALTER TABLE [TB_ARMAS] ADD CONSTRAINT [FK_TB_ARMAS_TB_PERSONAGEM_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [TB_PERSONAGEM] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250407112923_MigracaoUmParaUm', N'9.0.2');

COMMIT;
GO

