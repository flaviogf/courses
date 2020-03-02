CREATE User Web WITH PASSWORD = ''
GO

EXEC sp_addrolemember 'db_datawriter', 'Web'
GO

EXEC sp_addrolemember 'db_datareader', 'Web'
GO
