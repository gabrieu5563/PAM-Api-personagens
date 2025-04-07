BEGIN TRANSACTION;
CREATE TABLE [TB_HABILIDADES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_HABILIDADES] PRIMARY KEY ([Id])
);

CREATE TABLE [TB_PERSONAGEM_HABILIDADES] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_TB_PERSONAGEM_HABILIDADES] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_TB_PERSONAGEM_HABILIDADES_TB_HABILIDADES_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [TB_HABILIDADES] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_PERSONAGEM_HABILIDADES_TB_PERSONAGEM_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [TB_PERSONAGEM] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_HABILIDADES] ON;
INSERT INTO [TB_HABILIDADES] ([Id], [Dano], [Nome])
VALUES (1, 39, N'adormecer'),
(2, 41, N'congelar'),
(3, 37, N'hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_HABILIDADES] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGEM_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_PERSONAGEM_HABILIDADES] ON;
INSERT INTO [TB_PERSONAGEM_HABILIDADES] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 1),
(2, 2),
(2, 3),
(3, 3),
(3, 4),
(1, 5),
(2, 6),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGEM_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_PERSONAGEM_HABILIDADES] OFF;

CREATE INDEX [IX_TB_PERSONAGEM_HABILIDADES_HabilidadeId] ON [TB_PERSONAGEM_HABILIDADES] ([HabilidadeId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250407114348_MigracaoMuitosParaMuitos', N'9.0.2');

COMMIT;
GO

