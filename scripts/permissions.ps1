$Right = "ReadAndExecute"
$Principal = "IIS_IUSRS"
$StartingDir = "C:\inetpub\wwwroot"

foreach ($file in $(Get-ChildItem $StartingDir -recurse)) {
    $rule = New-Object System.Security.AccessControl.FileSystemAccessRule($Principal, $Right, "Allow")

    $acl = Get-Acl $file.FullName

    Write-Output $file.FullName

    $acl.GetAccessRules($rule)

    Set-Acl $File.FullName $acl
}