param(
    [Parameter(Mandatory=$True)]
    [int]$n
)


$fakt=1

for ($i = 1; $i -le $n; $i++){
    $fakt = $fakt*$i
}

Write-Host "Az $n paraméter faktoriálisa: $fakt"