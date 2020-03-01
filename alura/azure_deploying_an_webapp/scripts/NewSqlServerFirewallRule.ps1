New-AzureRmSqlServerFirewallRule `
-ResourceGroupName "ps-casadocodigo-rg" `
-ServerName "ps-casadocodigo-sql-srv" `
-FirewallRuleName "MyMachine" `
-StartIpAddress "186.210.57.45" `
-EndIpAddress "186.210.57.45"

New-AzureRmSqlServerFirewallRule `
-ResourceGroupName "ps-casadocodigo-rg" `
-ServerName "ps-casadocodigo-sql-srv" `
-FirewallRuleName "AllowAzureServices" `
-StartIpAddress "0.0.0.0" `
-EndIpAddress "0.0.0.0"