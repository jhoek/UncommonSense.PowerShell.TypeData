Import-Module (Join-Path $PSScriptRoot 'bin\debug\UncommonSense.PowerShell.TypeData.psd1')

$Types = Types {
    TypeInfo Foo {
        NoteProperty Oink Boink
        AliasProperty Oink BOoin
        ScriptProperty Foo 'Get-Process'
    }
} 

$Types.ToString()
