$i = 2
$c = 0
$n = 2
while($c -lt 10){
    $prim = "true"
        $i=2
        while ($i -le ($n / 2)) {
                if ($n % $i -eq 0) {
                $prim = "false"
            }
            $i += 1
        }
    if ($prim -eq "true") {
        Write-Host "$n"
        $c +=1
    }
    $n += 1
}