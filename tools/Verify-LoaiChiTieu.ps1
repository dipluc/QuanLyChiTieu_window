# Runs the real form, business rules and SQL-building code against an in-memory test adapter.
# No connection to LocalDB and no changes to the user's database.
$ErrorActionPreference = 'Stop'
$repo = Split-Path -Parent $PSScriptRoot
$testOutput = Join-Path $PSScriptRoot 'bin\LoaiChiTieuRegression'
New-Item -ItemType Directory -Force -Path $testOutput | Out-Null
$env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
$dotnet = (Get-Command dotnet).Source
$sdkVersion = & $dotnet --version
$compiler = Join-Path (Split-Path -Parent $dotnet) "sdk\$sdkVersion\Roslyn\bincore\csc.dll"
$framework = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8'
$references = @('mscorlib', 'System', 'System.Core', 'System.Data', 'System.Data.DataSetExtensions', 'System.Drawing', 'System.Windows.Forms', 'System.Xml') |
    ForEach-Object { '/reference:' + (Join-Path $framework ($_ + '.dll')) }
$sources = @(
    'tools\LoaiChiTieuRegression.cs',
    'MoHinh\LoaiChiMH.cs',
    'MoHinh\NguoiDungMH.cs',
    'NghiepVu\TienIch\PhienDangNhap.cs',
    'DuLieu\LoaiChiDL.cs',
    'NghiepVu\LoaiChiNV.cs',
    'LTWIN_N05_QLCT\Forms\DanhMuc\frmLoaiChiTieu.cs',
    'LTWIN_N05_QLCT\Forms\DanhMuc\frmLoaiChiTieu.Designer.cs'
) | ForEach-Object { Join-Path $repo $_ }
$executable = Join-Path $testOutput 'LoaiChiTieuRegression.exe'
& $dotnet exec $compiler /nologo /noconfig /nostdlib+ /target:exe /platform:x64 "/out:$executable" @references @sources
if ($LASTEXITCODE -ne 0) { throw 'Regression harness compilation failed.' }
& $executable $testOutput @args
if ($LASTEXITCODE -ne 0) { throw 'Category regression checks failed.' }
