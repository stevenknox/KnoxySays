### WORK IN PROGRESS

@echo off
powershell $rootPath = (get-item %* ).parent.FullName
powershell Add-Type -Assembly "System.IO.Compression.FileSystem" ;
powershell [System.IO.Compression.ZipFile]::CreateFromDirectory(%*, $rootPath\$url.zip") 