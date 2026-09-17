for cucc in info_mappa/*; do
    if [ -d "$cucc" ]; then
        var="${cucc}_folder"
    else
        var="${cucc}_file"
    fi
    mv $cucc $var
done