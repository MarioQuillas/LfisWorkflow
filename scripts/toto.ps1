$solutionPath = 'C:\DEV\PRICING\LFService\Developement\'

Get-ChildItem $solutionPath -Recurse -Include '*.csproj' | Where-Object {
    $_.FullName -notmatch "obj" -and ($_.FullName -notmatch "bin") -and ($_.FullName -notmatch "packages")
} | Where-Object {
    $content = Get-Content $_.FullName
    $content -match 'log4net'
} | ForEach-Object {
    Write-Host $_.FullName
}

# ForEach-Object {
#     $fullname = $_.FullName
    
# }