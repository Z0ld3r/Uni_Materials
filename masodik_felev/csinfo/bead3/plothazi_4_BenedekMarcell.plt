set output '4_gauss_illesztes.png'
set title "Gauss-görbe illesztése a H-alfa vonalra"
set xrange [651.27:661.27]
G(x) = b * exp(-((x - mu)**2) / (2 * sigma**2)) + C
mu = 656.27
sigma = 1.0
C = 85000
b = 43000
fit [651.27:661.27] G(x) 'hd21686.dat' using 1:2 via b, mu, sigma, C
plot 'hd21686.dat' using 1:2 with lines title "Mért adat", \
     G(x) with lines linewidth 2 linecolor rgb 'green' title "Illesztett Gauss-görbe"