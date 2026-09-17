import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
def leibniz(n):
    if n%2==0:
        return 1/((n*2)+1)
    else:
        return -1/((n*2)+1)

print("begin")
inp = input()
sum = 1
pi = 4
n=1
nek = []
sums = []
pis = []
while n <= 50:
    nek.append(n)
    sums.append(sum)
    pis.append(pi)
    sum += leibniz(n)
    pi = sum*4
    n += 1
    print("Sum:", sum)
    print("Pi:",pi)
    print("N:",n)

data = {
    'nek': nek,
    'sums': sums,
    'pis': pis
}

plt.plot(nek,pis,marker='o',linestyle='-',color='b')
plt.plot(nek,sums,marker='o',linestyle='--',color='r')
plt.title('Pi approximation /n')
plt.xlabel('N')
plt.grid(True)
plt.show()

print("End")