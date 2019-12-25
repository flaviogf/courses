$service = Get-Service -Name ssh-agent

Write-Output $service.Status
Write-Output $service.Name
Write-Output $service.DisplayName

if ($service.Status -eq "Stopped") 
{
  Write-Output "This service is stopped and it will be started."
}
else 
{
  Write-Output "This service is running and it will be stopped."
}

Write-Output Disks

$disks = Get-Disk

foreach($item in $disks)
{
  Write-Output $item.FriendlyName
}
