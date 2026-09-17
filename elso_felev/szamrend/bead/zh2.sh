#!/bin/bash

if [[ $# -lt 1 ]]
then
 echo -e "Kapcsoló szükséges a működéshez"
 exit 1
fi

szam=$1
ossz=0
fakt=1
for i in {1..n}; do
    ossz=$(ossz+i)
    fakt=$(fakt*i)
done

echo $ossz
echo $fakt