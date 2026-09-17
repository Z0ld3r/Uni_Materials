NR <= 5 {
    print $0
}

NR == 6 {
    print "#time mag"
}

NR > 6 {
    time = $1
    fnu = $2
    

    log10fnu = log(fnu) / log(10)
    
    mag = (log10fnu / -0.4) + 0.120 - 48.598
    

    printf "%.6f %.6f\n", time, mag
}