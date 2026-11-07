# Compile the real income form and DataService with an in-memory SQL read adapter.
# Does not connect to LocalDB or change application data.
$ErrorActionPreference = 'Stop'
$repo = Split-Path -Parent $PSScriptRoot
$testOutput = Join-Path $PSScriptRoot 'bin\ThuNhapRegression'
New-Item -ItemType Directory -Force -Path $testOutput | Out-Null
$env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
$dotnet = (Get-Command dotnet).Source
$sdkVersion = & $dotnet --version
$compiler = Join-Path (Split-Path -Parent $dotnet) "sdk\$sdkVersion\Roslyn\bincore\csc.dll"
$framework = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8'
$references = @('mscorlib', 'System', 'System.Core', 'System.Data', 'System.Data.DataSetExtensions', 'System.Drawing', 'System.Windows.Forms', 'System.Xml') |
    ForEach-Object { '/reference:' + (Join-Path $framework ($_ + '.dll')) }
$sources = @(
    'tools\ThuNhapRegression.cs',
    'MoHinh\NguoiDungMH.cs',
    'NghiepVu\TienIch\PhienDangNhap.cs',
    'LTWIN_N05_QLCT\Models\Models.cs',
    'LTWIN_N05_QLCT\Services\DataService.cs',
    'LTWIN_N05_QLCT\Forms\IDongBoThang.cs',
    'LTWIN_N05_QLCT\Forms\NghiepVu\frmQuanLyThuNhap.cs',
    'LTWIN_N05_QLCT\Forms\NghiepVu\frmQuanLyThuNhap.Designer.cs'
) | ForEach-Object { Join-Path $repo $_ }
$executable = Join-Path $testOutput 'ThuNhapRegression.exe'
& $dotnet exec $compiler /nologo /noconfig /nostdlib+ /target:exe /platform:x64 "/out:$executable" @references @sources
if ($LASTEXITCODE -ne 0) { throw 'Regression harness compilation failed.' }
& $executable $testOutput
if ($LASTEXITCODE -ne 0) { throw 'Income regression checks failed.' }
