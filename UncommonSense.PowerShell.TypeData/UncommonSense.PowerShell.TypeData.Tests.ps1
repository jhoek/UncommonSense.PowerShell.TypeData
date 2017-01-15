Import-Module (Join-Path $PSScriptRoot 'UncommonSense.PowerShell.TypeData.psd1')

Describe 'UncommonSense.Powershell.TypeData' {
	It 'Correctly renders an AliasProperty' {
		(Types {
			_Type Foo {
				AliasProperty Baz Bar
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><AliasProperty><Name>Baz</Name><ReferencedMemberName>Bar</ReferencedMemberName></AliasProperty></Members></Type></Types>'
	}

	It 'Correctly renders a NoteProperty' {
		(Types { 
			_Type Foo { 
				NoteProperty Baz Bar
			} 
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><NoteProperty><Name>Baz</Name><Value>Bar</Value></NoteProperty></Members></Type></Types>'
	}

	It 'Correctly renders a MemberSet' {
		(Types { 
			_Type Foo {
				MemberSet Baz
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSet><Name>Baz</Name><Members/></MemberSet></Members></Type></Types>'
	}
}