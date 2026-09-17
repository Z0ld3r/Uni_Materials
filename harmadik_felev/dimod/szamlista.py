def szamjegyek_listaja(n):
    list = []
    for i in str(n):
        list.append(int(i))
    print(list)


szamjegyek_listaja(int(input()))

def leghosszabb_szo(szavak):
    maxl = 0
    max = 0
    for i in szavak:
        if len(i) > maxl:
            maxl = len(i)
            max = i
    print(max)

leghosszabb_szo(["alma", "kutya", "hus"])