set output '2_H_alfa_vonal.png'
set title "A hidrogén H-alfa vonala"
set xrange [646.27:666.27]
set yrange [*:*] 
plot 'hd21686.dat' using 1:2 w l linecolor rgb 'red' title "H-alfa vonal"