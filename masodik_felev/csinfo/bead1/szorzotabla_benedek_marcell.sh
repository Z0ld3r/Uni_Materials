for i in {1..10}; do
    for j in {1..10}; do
        echo -n "$(($i*$j)) "
    done
    echo ""
done