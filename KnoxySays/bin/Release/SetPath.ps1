#Run this script to add this tool to your users ENV PATH

$path = [Environment]::GetEnvironmentVariable("Path", "User") + ";$pwd"
[Environment]::SetEnvironmentVariable("Path", $path,  "User")
Write-Host 'Updated User Enviornment Path'