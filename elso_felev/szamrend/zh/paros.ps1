param(
    [Parameter(Mandatory = $true)]
    [string]$fajl
)

if (-not (Test-Path $fajl)) {
    Write-Host "File doesn't exist"
    exit 0
}
$paros = 1
$prod = 1

ForEach ($line in Get-Content $fajl) {
    if ($paros % 2 -eq 0){
        $nums = $line -split " "
        ForEach ($num in $nums) {
            $prod = $prod * $num
        }
    }
    $paros++
}
Write-Host "Product: $prod"