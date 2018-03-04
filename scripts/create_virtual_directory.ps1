if (!(Test-Path 'IIS:\Sites\Default Web Site\Order'))
{
    New-Item IIS:\Sites\Default Web Site\Order `
        -PhysicalPath C:\inetpub\orderapp -ItemType VirtualDirectory
    
}