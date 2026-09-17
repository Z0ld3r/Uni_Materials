import random
def mockingSpongeBob(string):
    szo = ""
    for i in string:
        if (random.randint(0,1) == 0):
            szo += i.lower()
        else:
            szo+=i.upper()
    return szo

print(mockingSpongeBob("Szia en vagyok spongyabob"))