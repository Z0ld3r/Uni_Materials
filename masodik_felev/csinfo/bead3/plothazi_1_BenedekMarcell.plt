set terminal pngcairo size 800,600
set output '1_teljes_spektrum.png'
set title "HD21686 csillag spektruma"
set xlabel "Hullámhossz (nm)"
set ylabel "Fluxus (Jy)"
plot 'hd21686.dat' using 1:2 w l linecolor rgb 'blue' title "Mért spektrum"