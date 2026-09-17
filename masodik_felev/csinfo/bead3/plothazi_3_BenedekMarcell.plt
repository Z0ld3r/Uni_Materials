set output '3_egyenes_illesztes.png'
set title "Egyenes illesztése a kontinuumra"
set xrange [650:680]
f(x) = a * x + b
fit [665:680] f(x) 'hd21686.dat' using 1:2 via a, b
plot 'hd21686.dat' using 1:2 with lines title "Mért adat", \
     f(x) with lines linewidth 2 linecolor rgb 'black' title "Illesztett egyenes"