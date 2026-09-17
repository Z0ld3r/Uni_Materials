#!/bin/bash

if [[ $# -lt 1 ]]
then
 echo -e "Kapcsoló szükséges a működéshez"
 exit 1
fi

if [[ $1 == "-p" ]]
then
 pwd
fi
if [[ $1 == "-c" ]] 
then
  nev=$2
  touch $nev
fi
if [[ $1 == "-l" ]]
then 
    ls | wc -l
fi