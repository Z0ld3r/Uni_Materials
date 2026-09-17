param(
    [Parameter(Mandatory = $true)]
    [int[]]$szamok
)

$min = 2147483647
for ($i = 0; $i -lt $szamok.Count; $i++) {
    if($szamok[$i] -lt $min) {
        $min = $szamok[$i]
    }
    if($szamok[$i] -gt $max) {
        $max = $szamok[$i]
    }
}

$hany = $max / $min

Write-Host "Min: $min"
Write-Host "Max: $max"
Write-Host "Max/Min: $hany"