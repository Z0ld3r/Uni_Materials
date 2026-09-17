param(
    [Parameter(Mandatory=$True)]
    [int[]]$szamok
)

$osszeg = 0

foreach($szam in $szamok) {
    $osszeg+=$szam
}

Write-Host "$osszeg"