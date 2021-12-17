IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Quizz] (
    [Guid] bigint NOT NULL IDENTITY,
    CONSTRAINT [PK_Quizz] PRIMARY KEY ([Guid])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211108154937_Quizz', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Quizz];
GO

CREATE TABLE [Quiz] (
    [id] uniqueidentifier NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Quiz] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Question] (
    [id] uniqueidentifier NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [type] int NOT NULL,
    [quizid] uniqueidentifier NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Question_Quiz_quizid] FOREIGN KEY ([quizid]) REFERENCES [Quiz] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Answer] (
    [id] uniqueidentifier NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [IsCorrect] bit NOT NULL,
    [questionid] uniqueidentifier NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Answer_Question_questionid] FOREIGN KEY ([questionid]) REFERENCES [Question] ([id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Answer_questionid] ON [Answer] ([questionid]);
GO

CREATE INDEX [IX_Question_quizid] ON [Question] ([quizid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202150928_Quiz-v2', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Answer] DROP CONSTRAINT [FK_Answer_Question_questionid];
GO

ALTER TABLE [Question] DROP CONSTRAINT [FK_Question_Quiz_quizid];
GO

EXEC sp_rename N'[Question].[quizid]', N'QuizId', N'COLUMN';
GO

EXEC sp_rename N'[Question].[IX_Question_quizid]', N'IX_Question_QuizId', N'INDEX';
GO

EXEC sp_rename N'[Answer].[questionid]', N'QuestionId', N'COLUMN';
GO

EXEC sp_rename N'[Answer].[IX_Answer_questionid]', N'IX_Answer_QuestionId', N'INDEX';
GO

DROP INDEX [IX_Question_QuizId] ON [Question];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Question]') AND [c].[name] = N'QuizId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Question] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Question] ALTER COLUMN [QuizId] uniqueidentifier NOT NULL;
ALTER TABLE [Question] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [QuizId];
CREATE INDEX [IX_Question_QuizId] ON [Question] ([QuizId]);
GO

DROP INDEX [IX_Answer_QuestionId] ON [Answer];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Answer]') AND [c].[name] = N'QuestionId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Answer] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Answer] ALTER COLUMN [QuestionId] uniqueidentifier NOT NULL;
ALTER TABLE [Answer] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [QuestionId];
CREATE INDEX [IX_Answer_QuestionId] ON [Answer] ([QuestionId]);
GO

ALTER TABLE [Answer] ADD CONSTRAINT [FK_Answer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Question] ([id]) ON DELETE CASCADE;
GO

ALTER TABLE [Question] ADD CONSTRAINT [FK_Question_Quiz_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quiz] ([id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202155211_Quiz-v3', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202171423_Quiz-v4', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Quiz] ADD [Password] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202175105_Quiz-v5-mdp', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Quiz].[id]', N'Id', N'COLUMN';
GO

EXEC sp_rename N'[Question].[type]', N'Type', N'COLUMN';
GO

EXEC sp_rename N'[Question].[id]', N'Id', N'COLUMN';
GO

EXEC sp_rename N'[Answer].[id]', N'Id', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211203133945_Quiz-v6', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Quiz] ADD [Status] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211206103743_Quiz-v7', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Quiz]') AND [c].[name] = N'Password');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Quiz] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Quiz] ALTER COLUMN [Password] nvarchar(max) NULL;
GO

CREATE TABLE [ScoreModel] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [Score] int NOT NULL,
    [QuizId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ScoreModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ScoreModel_Quiz_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quiz] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ScoreModel_QuizId] ON [ScoreModel] ([QuizId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211206151724_Quiz-v9', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Quiz] ADD [Rate] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211213143205_Quiz-V10', N'5.0.0');
GO

COMMIT;
GO

