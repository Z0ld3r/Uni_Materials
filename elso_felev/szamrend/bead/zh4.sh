#!/bin/bash

mini=100
maxi=0

while read p; do
    if [[ $p -lt $mini ]]
    then 
        mini=$p
    fi
    if [[ $p -gt $maxi ]]
    then
        maxi=$p
    fi
done < minta.txt

echo "$mini"
echo "$maxi"