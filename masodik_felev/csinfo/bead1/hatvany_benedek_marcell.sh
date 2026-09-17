if [[ $# -lt 2 ]]
then
 echo -e "Két kapcsoló szükséges a működéshez"
 exit 1
fi

echo $(($1 ** $2))