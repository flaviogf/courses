New-AzureRmSqlServerFirewallRule `
-ResourceGroupName rgcasadocodigo `
-ServerName sscasadocodigo `
-FirewallRuleName mymachine `
-StartIpAddress 189.112.203.1 `
-EndIpAddress 189.112.203.1

New-AzureRmSqlServerFirewallRule `
-ResourceGroupName rgcasadocodigo `
-ServerName sscasadocodigo `
-FirewallRuleName AllowAzureServices `
-StartIpAddress 0.0.0.0 `
-EndIpAddress 0.0.0.0