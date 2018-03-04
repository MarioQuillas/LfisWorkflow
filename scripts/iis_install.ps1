﻿Get-WindowsFeature -Name web-*

Import-Module ServerManager

Add-WindowsFeature Web-Common-Http, `
    Web-Default-Doc, `
    Web-Mgmt-Console #for iis manager
