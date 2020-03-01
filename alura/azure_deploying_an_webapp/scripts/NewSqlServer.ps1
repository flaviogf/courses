New-AzureRmSqlServer `
-ResourceGroupName "ps-casadocodigo-rg" `
-Location "east us" `
-ServerName "ps-casadocodigo-sql-srv" `
-SqlAdministratorCredentials (Get-Credential)