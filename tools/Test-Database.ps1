param(
    [switch]$RestartLocalDb
)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$outputDirectory = Join-Path $projectRoot 'LTWIN_N05_QLCT\bin\Debug'
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'

& dotnet build (Join-Path $projectRoot 'QuanLyChiTieu.slnx') --configuration Debug --nologo
if ($LASTEXITCODE -ne 0) { throw 'Build failed.' }

$probe = Join-Path $outputDirectory 'DatabaseProbe-x64.exe'
& $compiler /nologo /platform:x64 /target:exe "/out:$probe" "/reference:$(Join-Path $outputDirectory 'DuLieu.dll')" /reference:System.Data.dll (Join-Path $PSScriptRoot 'DatabaseProbe.cs')
if ($LASTEXITCODE -ne 0) { throw 'Could not compile the .NET Framework database check.' }

if ($RestartLocalDb) {
    $localDbTool = (Get-Command SqlLocalDB.exe -ErrorAction Stop).Source
    & $probe --restart-localdb $localDbTool
} else {
    & $probe
}
if ($LASTEXITCODE -ne 0) { throw 'Database check failed.' }

$start = [Diagnostics.ProcessStartInfo]::new(
    (Join-Path $outputDirectory 'LTWIN_N05_QLCT.exe'), '--check-database')
$start.UseShellExecute = $false
$start.WorkingDirectory = $projectRoot
$application = [Diagnostics.Process]::Start($start)
try {
    if (-not $application.WaitForExit(60000)) { throw 'WinForms database check timed out.' }
    if ($application.ExitCode -ne 0) { throw 'WinForms database check failed; see database-check.log.' }
} finally {
    $application.Dispose()
}
Get-Content (Join-Path $outputDirectory 'database-check.log')
