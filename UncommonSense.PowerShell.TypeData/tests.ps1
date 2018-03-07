Import-Module (Join-Path -Path $PSScriptRoot -ChildPath UncommonSense.PowerShell.TypeData.psd1) -Force

Describe 'UncommonSense.Powershell.TypeData' {
	It 'Correctly renders an AliasProperty' {
		(Types {
			_Type Foo {
				AliasProperty Baz Bar
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><AliasProperty><Name>Baz</Name><ReferencedMemberName>Bar</ReferencedMemberName></AliasProperty></Members></Type></Types>'

		(Types {
			_Type Foo {
				AliasProperty Baz Bar -TypeName Qux
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><AliasProperty><Name>Baz</Name><ReferencedMemberName>Bar</ReferencedMemberName><TypeName>Qux</TypeName></AliasProperty></Members></Type></Types>'

		(Types {
			_Type Foo {
				AliasProperty Baz Bar -IsHidden
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><AliasPropertyIsHidden="true"><Name>Baz</Name><ReferencedMemberName>Bar</ReferencedMemberName></AliasProperty></Members></Type></Types>'
	}

    It 'Correctly renders a CodeMethod' {
        (Types {
            _Type Foo {
                CodeMethod Baz (CodeReference Bar Qux)
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><CodeMethod><Name>Baz</Name><CodeReference><TypeName>Bar</TypeName><MethodName>Qux</MethodName></CodeReference></CodeMethod></Members></Type></Types>'
    }

    It 'Correctly renders a CodeProperty' {
        (Types {
            _Type Foo {
                CodeProperty Baz (CodeReference Bar Qux) (CodeReference Quux Quuux)
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><CodeProperty><Name>Baz</Name><GetCodeReference><TypeName>Bar</TypeName><MethodName>Qux</MethodName></GetCodeReference><SetCodeReference><TypeName>Quux</TypeName><MethodName>Quuux</MethodName></SetCodeReference></CodeProperty></Members></Type></Types>'

        (Types {
            _Type Foo {
                CodeProperty Baz (CodeReference Bar Qux) (CodeReference Quux Quuux) -IsHidden
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><CodePropertyIsHidden="true"><Name>Baz</Name><GetCodeReference><TypeName>Bar</TypeName><MethodName>Qux</MethodName></GetCodeReference><SetCodeReference><TypeName>Quux</TypeName><MethodName>Quuux</MethodName></SetCodeReference></CodeProperty></Members></Type></Types>'
    }

	It 'Correctly renders a MemberSet without -InheritMembers' {
		(Types {
			_Type Foo {
				MemberSet Baz {
                    PropertySet DefaultDisplayPropertySet Bar,Qux,Quux
                }
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSet><Name>Baz</Name><Members><PropertySet><Name>DefaultDisplayPropertySet</Name><ReferencedProperties><Name>Bar</Name><Name>Qux</Name><Name>Quux</Name></ReferencedProperties></PropertySet></Members></MemberSet></Members></Type></Types>'

		(Types {
			_Type Foo {
				MemberSet Baz -IsHidden {
                    PropertySet DefaultDisplayPropertySet Bar,Qux,Quux
                }
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSetIsHidden="true"><Name>Baz</Name><Members><PropertySet><Name>DefaultDisplayPropertySet</Name><ReferencedProperties><Name>Bar</Name><Name>Qux</Name><Name>Quux</Name></ReferencedProperties></PropertySet></Members></MemberSet></Members></Type></Types>'
	}

    It 'Correctly renders -DoNotInheritMembers on a MemberSet' {
        (Types {
            _Type Foo {
                MemberSet Baz -DoNotInheritMembers
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSet><Name>Baz</Name><InheritMembers>False</InheritMembers><Members/></MemberSet></Members></Type></Types>'

        (Types {
            _Type Foo {
                MemberSet Baz -IsHidden -DoNotInheritMembers
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><MemberSetIsHidden="true"><Name>Baz</Name><InheritMembers>False</InheritMembers><Members/></MemberSet></Members></Type></Types>'
    }

	It 'Correctly renders a NoteProperty' {
		(Types {
			_Type Foo {
				NoteProperty Baz Bar
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><NoteProperty><Name>Baz</Name><Value>Bar</Value></NoteProperty></Members></Type></Types>'

		(Types {
			_Type Foo {
				NoteProperty Baz Bar -TypeName Qux
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><NoteProperty><Name>Baz</Name><Value>Bar</Value><TypeName>Qux</TypeName></NoteProperty></Members></Type></Types>'

		(Types {
			_Type Foo {
				NoteProperty Baz Bar -IsHidden
			}
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><NotePropertyIsHidden="true"><Name>Baz</Name><Value>Bar</Value></NoteProperty></Members></Type></Types>'
	}

    It 'Correctly renders a PropertySet' {
        (Types {
            _Type Foo {
                PropertySet Baz Bar,Qux,Quux
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><PropertySet><Name>Baz</Name><ReferencedProperties><Name>Bar</Name><Name>Qux</Name><Name>Quux</Name></ReferencedProperties></PropertySet></Members></Type></Types>'

        (Types {
            _Type Foo {
                PropertySet Baz Bar,Qux,Quux -IsHidden
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><PropertySetIsHidden="true"><Name>Baz</Name><ReferencedProperties><Name>Bar</Name><Name>Qux</Name><Name>Quux</Name></ReferencedProperties></PropertySet></Members></Type></Types>'
    }

    It 'Correctly renders a ScriptMethod' {
        (Types {
            _Type Foo {
                ScriptMethod Baz 'Get-Process'
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><ScriptMethod><Name>Baz</Name><Script>Get-Process</Script></ScriptMethod></Members></Type></Types>'
    }

    It 'Correctly renders a ScriptProperty' {
        (Types {
            _Type Foo {
                ScriptProperty Baz 'Get-Bar' 'Set-Bar'
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><ScriptProperty><Name>Baz</Name><GetScriptBlock>Get-Bar</GetScriptBlock><SetScriptBlock>Set-Bar</SetScriptBlock></ScriptProperty></Members></Type></Types>'

        (Types {
            _Type Foo {
                ScriptProperty Baz 'Get-Bar' 'Set-Bar' -IsHidden
            }
        }) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members><ScriptPropertyIsHidden="true"><Name>Baz</Name><GetScriptBlock>Get-Bar</GetScriptBlock><SetScriptBlock>Set-Bar</SetScriptBlock></ScriptProperty></Members></Type></Types>'
    }

	It 'Correctly renders a type converter from a string' {
		(Types {
			_Type Foo -TypeConverter 'Baz'
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members/><TypeConverter><TypeName>Baz</TypeName></TypeConverter></Type></Types>'
	}

	It 'Correctly renders a type converter from a type converter instance' {
		(Types {
			_Type Foo -TypeConverter (TypeConverter Baz)
		}) -replace '\s', '' | Should Be '<Types><Type><Name>Foo</Name><Members/><TypeConverter><TypeName>Baz</TypeName></TypeConverter></Type></Types>'
	}
}