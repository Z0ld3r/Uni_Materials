import math

def factorial(n):
    sum = 1
    for i in range(1, n+1,1):
        sum *= i
    print(sum)

factorial(int(input("Most:")))

print(math.factorial(20))