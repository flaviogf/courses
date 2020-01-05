CREATE TABLE [dbo].[ApplicationUser]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [UserName] VARCHAR(256) NULL,
    [NormalizedUserName] VARCHAR(256) NULL,
    [Email] VARCHAR(256) NULL,
    [NormalizedEmail] VARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL DEFAULT 0,
    [PasswordHash] VARCHAR(MAX) NULL,
    [PhoneNumber] VARCHAR(MAX) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL DEFAULT 0,
    [TwoFactorEnabled] BIT NOT NULL DEFAULT 0
);

GO
