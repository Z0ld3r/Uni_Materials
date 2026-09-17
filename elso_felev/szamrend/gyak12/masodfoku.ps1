param (
    [Parameter(Mandatory=$True)]
    [double]$a,
    [double]$b,
    [double]$c
)

$d = [math]::Pow($b,2) - 4*$a*$c


if ($d -lt 0) {
    Write-Host "Buzi vagy"
    exit 0
}

$x1 = (-$b + [math]::Sqrt[$d])/(2*$a)
$x2 = (-$b - [math]::Sqrt[$d])/(2*$a)

Write-Host "x1: $x1"
Write-Host "x2: $x2"