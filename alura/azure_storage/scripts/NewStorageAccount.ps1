New-AzureRmStorageAccount `
    -ResourceGroupName "rgcasadocodigo" `
    -Name "sacasadocodigo" `
    -Location "east us" `
    -AccessTier "Hot" `
    -SkuName "Standard_LRS" `
    -Kind "StorageV2"