Import-Module (Join-Path $PSScriptRoot 'bin\debug\UncommonSense.PowerShell.TypeData.psd1')

Describe 'UncommonSense.Powershell.TypeData' {
	It 'Correctly renders a NoteProperty' {
		Types { Type Foo { NoteProperty Baz Bar } } 
	}
}