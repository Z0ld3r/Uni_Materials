def dupl(L):
    list = []
    for i in L:
        if i not in list:
            list.append(i)
    print("".join(list))


dupl("sususususupaldsapo")