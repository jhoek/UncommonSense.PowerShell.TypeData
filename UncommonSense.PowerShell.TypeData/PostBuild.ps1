$ModulesFolder = ($env:PSModulePath -split ';')[0]

$FromFolder = Join-Path -Path $PSScriptRoot -ChildPath 'bin/debug'
$ToFolder = Join-Path -Path $ModulesFolder -ChildPath 'UncommonSense.PowerShell.TypeData/'

if (-not (Test-Path -Path $ToFolder))
{
    New-Item -Path $ToFolder -ItemType Directory -ErrorAction SilentlyContinue
}

Copy-Item `
    -Path $FromFolder\UncommonSense.PowerShell.TypeData.* `
    -Exclude *.pdb `
    -Destination $ToFolder `
	-Force