$line=1
$even=0
$odd=0
ForEach($curline in Get-Content .\test2.txt) {
    $words=$curline -split " "
    ForEach($word in $words){
        if ($line % 2 -eq 0){
            if ($word % 2 -eq 0){
                $even=$even+$word
            }
        }
        else {
            if ($word % 2 -eq 1){
                $odd=$odd+$word
            }
        }
    }
    $line+=1
}
Write-Host "Even: $even"
Write-Host "Odd: $odd"