Import-Module (Join-Path $PSScriptRoot 'bin\debug\UncommonSense.PowerShell.TypeData.psd1')

Types {
    _Type Foo {
        NoteProperty Oink Boink
        ScriptProperty Foo 'Get-Content Foo'
        MemberSet {
            NoteProperty Boo Bah
        }
    }
}
