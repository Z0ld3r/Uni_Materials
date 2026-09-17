#!/bin/bash 

a=3
d=4

atiz=a+(d*9)
s=0
for i in $(seq 1 7); do
    s=`expr $s + $($a+($d*$i)`
done 
echo $atiz
echo $s