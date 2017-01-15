(Join-Path $PSScriptRoot 'UncommonSense.PowerShell.TypeData.psd1'),
(Join-Path $PSScriptRoot 'bin/Debug/UncommonSense.PowerShell.TypeData.psd1') |
    ForEach-Object { Import-Module $_ -ErrorAction SilentlyContinue } 

Describe 'UncommonSense.Powershell.TypeData' {
	It 'Correctly renders an AliasProperty' {
		(Types {
			_Type Foo {
				AliasProperty Baz Bar
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><AliasProperty><Name>Baz</Name><ReferencedMemberName>Bar</ReferencedMemberName></AliasProperty></Members></Type></Types>'
	}

    It 'Correctly renders a CodeMethod' {
        (Types {
            _Type Foo {
                CodeMethod Baz (CodeReference Bar Qux)
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><CodeMethod><Name>Baz</Name><CodeReference><TypeName>Bar</TypeName><MethodName>Qux</MethodName></CodeReference></CodeMethod></Members></Type></Types>'
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
				MemberSet Baz {
                    PropertySet DefaultDisplayPropertySet Bar,Qux,Quux
                }
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSet><Name>Baz</Name><Members><PropertySet><Name>DefaultDisplayPropertySet</Name><ReferencedProperties><Name>Bar</Name><Name>Qux</Name><Name>Quux</Name></ReferencedProperties></PropertySet></Members></MemberSet></Members></Type></Types>'
	}
}