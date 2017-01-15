# UncommonSense.PowerShell.TypeData
*PowerShell module to help build PowerShell type extension files*

## Installation
1. Build the project 
1. From the build output folder (depends on your build configuration; typically `bin/Debug` or  `bin/Release`), copy the following items to a folder called `UncommonSense.PowerShell.TypeData` anywhere in your PowerShell module path. To find your module path, type `$env:PSModulePath -split ';'` in a PowerShell console.
  - System.Management.Automation.dll
  - UncommonSense.PowerShell.TypeData.dll
  - UncommonSense.PowerShell.TypeData.psd1
  - UncommonSense.PowerShell.TypeData.psm1
  
## Usage
