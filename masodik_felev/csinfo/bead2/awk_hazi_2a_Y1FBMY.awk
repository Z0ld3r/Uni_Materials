BEGIN {
    FS = ","
    const = 2.5 / log(10)
    print "# ra,dec,mag,mag_error"
}

NR == 1 { next }

{
    ra = $1
    dec = $2
    mag = $3
    flux = $4
    flux_err = $5

    if (flux > 0) {
        mag_err = const * (flux_err / flux)
        printf "%.6f,%.6f,%.4f,%.6f\n", ra, dec, mag, mag_err
    }
}