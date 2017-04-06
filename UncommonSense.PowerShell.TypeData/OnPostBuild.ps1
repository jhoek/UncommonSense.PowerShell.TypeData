Import-Module psake -ErrorAction Stop

Invoke-psake -buildFile (Join-Path -Path $PSScriptRoot -ChildPath ./Build.Psake.ps1)