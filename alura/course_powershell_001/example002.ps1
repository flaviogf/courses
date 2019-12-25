foreach($item in $env:path.Split(';'))
{
    Write-Output $item
}
