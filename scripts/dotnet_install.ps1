$url = ""

$output = "C:\temp\dotnet.exe"

Invoke-WebRequest -Uri $url -OutFile $output

& "$output" /passive /norestart

#C:\Windows\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -i ----- if before IIS8

