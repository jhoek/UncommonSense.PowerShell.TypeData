Properties {
    $ModuleName = 'UncommonSense.PowerShell.TypeData'
	$BuildOutputFolder = Join-Path -Path $PSScriptRoot -ChildPath 'bin/debug/'
    $ModuleFolder = Join-Path -Path (($env:PSModulePath -split ';')[0]) -ChildPath $ModuleName
}

Task `
	-name default `
	-depends CopyToModuleFolder

Task `
    -name CreateModuleFolder `
    -precondition { -not (Test-Path -Path $ModuleFolder) } `
    -action { New-Item -Path $ModuleFolder -ItemType Directory | Out-Null } `
    -postcondition { Test-Path -Path $ModuleFolder }

Task `
	-depends CreateModuleFolder `
	-name CopyToModuleFolder `
	-action { 
		Copy-Item `
			-Path "$BuildOutputFolder\*.*" `
			-Destination $ModuleFolder `
			-Exclude *.pdb, *.tmp, System.Management.Automation.dll `
			-Force 
		}