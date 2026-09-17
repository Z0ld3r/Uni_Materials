param (
    [string]$fajl
)

if (-not(Test-Path $fajl)) {
    Write-Host "Invalid parameter"
    exit 0
}

$par = "paros.txt"
$plan = "paratlan.txt"

if (Test-Path $par) {
    Remove-Item $par
}
if (Test-Path $plan) {
    Remove-Item $plan
}

$sorok = Get-Content $fajl
for ($i=0; $i -lt $sorok.Count; $i++) {
    if (($i+1) % 2 -eq 0) {
        $sorok[$i] | Out-File -FilePath $par -Append
    }
    else {
        $sorok[$i] | Out-File -FilePath $plan -Append
    }
}

Write-Host "Odd: $plan"
Write-Host "Even: $par"