Import-Module WebAdministration
$insidePath = 'C:\inetpub\inside'
$insideName = 'inside'
$insideDomain = 'inside.toto.com'
$insideSource = 'C:\temp\insideWebFiles'

cd IIS:\Sites\

if (!(Test-Path IIS:\Sites\$insideName)) 
{
    New-Item IIS:\Sites\$insideName `
        -Bindings @{protocol="http"; bindingInformation="*:80:$insideDomain"} `        -PhysicalPath $insidePath -Verbose
}

Remove-Item -Path $insidePath\* -Recurse

Copy-Item -Path $insideSource\* `
    -Destination $insidePath `    -RecurseInvoke-Command -ScriptBlock {iisreset}if (!(Test-Path IIS:\AppPools\$insideName))
{
    $appPool = New-Item $insideName
    $appPool | Set-ItemProperty -Name "managedRuntimeVersion" -Value 'v4.0'
    $appPool | Set-ItemProperty -Name "enable32BitAppOnWin64" -Value $True
    #Get-Item IIS:\AppPools\DefaultAppPool | Select-Object *
}

Set-ItemProperty IIS:\Sites\$insideName -Name applicationpool -Value $insideName