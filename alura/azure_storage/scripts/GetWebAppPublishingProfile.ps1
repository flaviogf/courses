$file = [xml](Get-AzureRmWebAppPublishingProfile `
                -ResourceGroupName rgcasadocodigo `
                -Name webappcasadocodigo)

$file.Save("casadocodigo.publishsettings")