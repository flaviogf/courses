CREATE USER web WITH PASSWORD = '';
EXEC sp_addrolemember 'DB_DATAREADER', 'web';
EXEC sp_addrolemember 'DB_DATAWRITER', 'web';