Get-WindowsFeature -Name web-*

Import-Module ServerManager

Add-WindowsFeature Web-Common-Http, `
    Web-Default-Doc, `    Web-Dir-Browsing, `    Web-Static-Content, `    Web-Stat-Compression, `    Web-CertProvider, `    Web-ASP, `    Web-Asp-Net45, `    Web-Scripting-Tools, `
    Web-Mgmt-Console #for iis manager
Import-Module WebAdministration#Remove-Item C:\inetpub\wwwroot\* -Recurse#Copy-Item -Path C:\temp\webfiles\* `#    -Destination C:\inetpub\wwwroot `#    -Recurse#Backup-WebConfiguration -Name IISConfigBackup -----> Windir\System32\inetsrv\backup