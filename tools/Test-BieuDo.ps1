$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$output = Join-Path $projectRoot 'LTWIN_N05_QLCT\bin\Debug'
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
$probe = Join-Path $output 'BieuDoProbe.exe'
$refs = @('LTWIN_N05_QLCT.exe', 'DuLieu.dll', 'MoHinh.dll', 'NghiepVu.dll', 'ClosedXML.dll', 'PdfSharp-gdi.dll') |
    ForEach-Object { '/reference:' + (Join-Path $output $_) }
& $compiler /nologo /platform:x64 /target:exe "/out:$probe" /reference:System.Data.dll /reference:System.Drawing.dll /reference:System.Windows.Forms.dll /reference:System.Windows.Forms.DataVisualization.dll /reference:netstandard.dll $refs (Join-Path $PSScriptRoot 'BieuDoProbe.cs')
if ($LASTEXITCODE -ne 0) { throw 'Build GUI.csproj first; probe compile failed.' }
Copy-Item -LiteralPath (Join-Path $output 'LTWIN_N05_QLCT.exe.config') -Destination ($probe + '.config')
& $probe
if ($LASTEXITCODE -ne 0) { throw 'Chart/export checks failed.' }
