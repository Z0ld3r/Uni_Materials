BEGIN {
    max1 = -1e30 
    max2 = -1e30
}

NR > 6 {
    ido[NR] = $1
    ertek[NR] = $2
    if (start_t == "") start_t = $1
    end_t = $1
}

END {
    mid_t = (start_t + end_t) / 2
    
    for (i in ido) {
        if (ido[i] < mid_t) {
            if (ertek[i] > max1) {
                max1 = ertek[i]
                t1 = ido[i]
            }
        } else {
            if (ertek[i] > max2) {
                max2 = ertek[i]
                t2 = ido[i]
            }
        }
    }
    
    period = (t2 - t1 > 0) ? (t2 - t1) : (t1 - t2)
    
    printf "Első maximum: %.2f perc\n", t1
    printf "Második maximum: %.2f perc\n", t2
    printf "Becsült periódusidő: %.2f perc\n", period
}