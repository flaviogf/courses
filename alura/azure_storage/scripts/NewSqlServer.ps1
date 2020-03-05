New-AzureRmSqlServer `
-ResourceGroupName rgcasadocodigo `
-Location "east us" `
-ServerName "sscasadocodigo" `
-SqlAdministratorCredentials (Get-Credential)