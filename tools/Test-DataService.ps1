param([string]$OutputDirectory)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$output = if ($OutputDirectory) { $OutputDirectory } else { Join-Path $projectRoot 'LTWIN_N05_QLCT\bin\Debug' }
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
$probe = Join-Path $output 'DataServiceProbe.exe'
& $compiler /nologo /platform:x64 /target:exe "/out:$probe" /reference:System.Data.dll /reference:System.Data.DataSetExtensions.dll "/reference:$(Join-Path $output 'LTWIN_N05_QLCT.exe')" "/reference:$(Join-Path $output 'DuLieu.dll')" "/reference:$(Join-Path $output 'MoHinh.dll')" "/reference:$(Join-Path $output 'NghiepVu.dll')" (Join-Path $PSScriptRoot 'DataServiceProbe.cs')
if ($LASTEXITCODE -ne 0) { throw 'Compile failed. Build GUI.csproj first.' }
& $probe
if ($LASTEXITCODE -ne 0) { throw 'Database service checks failed.' }
