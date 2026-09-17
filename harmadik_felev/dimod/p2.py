szo = input("szo:")
kar = input("kar:")

def counter(szo, kar):
    mycount = 0
    for i in szo:
        if i == kar:
            mycount += 1
    print(mycount)


counter(szo,kar)