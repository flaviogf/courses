Param(
    [Parameter(Mandatory = $true)]
    [String]
    $Path,
    [Parameter(Mandatory = $true)]
    [String]
    $ConvertType,
    [Parameter(Mandatory = $true)]
    [String]
    $Destination
)

$NameExpression = @{
    Name       = 'Name';
    Expression = 'Name'
}

$LengthExpression = @{
    Name       = 'Length';
    Expression = { '{0:N2} KB' -f ($_.Length / 1KB) }
}

$Items = Get-ChildItem $Path | Select-Object $NameExpression, $LengthExpression 

switch ($ConvertType) {
    'HTML' {
        $Items | ConvertTo-Html -Head "<style>$(Get-Content '.\style.css')</style>" | Out-File $Destination
    }
    'JSON' { 
        $Items | ConvertTo-Json | Out-File $Destination
    }
    'CSV' {
        $Items | ConvertTo-Csv -NoTypeInformation | Out-File $Destination
    }
    Default {
        throw 'The parameter ConvertType only accept the values (HTML, JSON or CSV)'
    }
}
