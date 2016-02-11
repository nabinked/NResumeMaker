 Param(
    [Parameter(Mandatory = $true)]
    [string]$sourceDir,
    [string]$branch = "master"
    )
    
 # bootstrap DNVM into this session.
&{$branch;iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}

# load up the global.json so we can find the DNX version
$globalJson = Get-Content -Path $PSScriptRoot\global.json -Raw -ErrorAction Ignore | ConvertFrom-Json -ErrorAction Ignore

if($globalJson)
{
    $dnxVersion = $globalJson.sdk.version
}
else
{
    Write-Warning "Unable to locate global.json to determine using 'latest'"
    $dnxVersion = "latest"
}

# install DNX
# only installs the default (x86, clr) runtime of the framework.
# If you need additional architectures or runtimes you should add additional calls
# ex: & $env:USERPROFILE\.dnx\bin\dnvm install $dnxVersion -r coreclr
& $env:USERPROFILE\.dnx\bin\dnvm install $dnxVersion -Persistent

 # run DNU restore on all project.json files in the src folder including 2>1 to redirect stderr to stdout for badly behaved tools
Write-Host "===== RESTORE ====="
Get-ChildItem -Path $PSScriptRoot\src -Filter project.json -Recurse | ForEach-Object { & dnu restore $_.FullName 2>1 }

 # run DNU build on all project.json files in the src folder including 2>1 to redirect stderr to stdout for badly behaved tools
#Write-Host "===== BUILD ====="
#Get-ChildItem -Path $PSScriptRoot\src -Filter project.json -Recurse | ForEach-Object { & dnu build $_.FullName 2>1 }
 
 # run DNU publish on all project.json files in the src folder including 2>1 to redirect stderr to stdout for badly behaved tools
Write-Host "===== PUBLISH ====="
Get-ChildItem -Path $PSScriptRoot\src -Filter project.json -Recurse | ForEach-Object { & dnu publish $_.FullName 2>1 -o "./pub" }
