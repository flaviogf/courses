CREATE TABLE [dbo].[ApplicationUserRoles]
(
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY ([UserId], [RoleId]),
    FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser]([Id]),
    FOREIGN KEY ([RoleId]) REFERENCES [ApplicationRole]([Id])
)

GO
