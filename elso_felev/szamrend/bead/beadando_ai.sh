#!/bin/bash

file="${1:-/dev/stdin}"

awk '
{
    sum_even=0
    sum_odd=0
    for(i=1; i<=NF; i++) {
        if(NR % 2 == 0 && $i % 2 == 0)
            sum_even += $i
        if(NR % 2 == 1 && $i % 2 == 1)
            sum_odd += $i
    }
    total_even += sum_even
    total_odd += sum_odd
}
END {
    print "Páratlan sorok páratlan számainak összege:", total_odd
    print "Páros sorok páros számainak összege:", total_even
}' "$file"
