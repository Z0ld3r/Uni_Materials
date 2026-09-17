BEGIN {
    FS = ","
    print "ra,dec,mag,pmra,pmdec,parallax" 
    talalat_db = 0
}


NR == 1 { next }

{
    ra = $1; dec = $2; mag = $3; pmra = $7; pmdec = $8; plx = $9
    
    if (plx > 5.0 && plx < 7.0 && pmra > -40 && pmra < -30 && pmdec > -15 && pmdec < -10) {
        adatok[talalat_db] = ra "," dec "," mag "," pmra "," pmdec "," plx
        talalat_db++
    }
}

END {
    if (talalat_db > 0) {
        sorting_cmd = "sort -t',' -k3,3n | head -n 20"
        
        for (i = 0; i < talalat_db; i++) {
            print adatok[i] | sorting_cmd
        }
        close(sorting_cmd)
    }
}