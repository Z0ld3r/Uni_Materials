NR <= 5 {
    print $0
}

NR == 6 {
    print "#time mag min max"
}

NR > 6 {
    time = $1
    fnu = $2
    

    log10fnu = log(fnu) / log(10)
    
    mag = (log10fnu / -0.4) + 0.120 - 48.598
    min = mag-((mag/100)*2)
    max = mag+((mag/100)*2)
    printf "%.6f %.6f %.6f  %.6f\n", time, mag, min, max
}