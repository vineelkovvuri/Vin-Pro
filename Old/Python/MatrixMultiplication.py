


#Matrix Multiplication

matA,matB,matC = [[],[]],[[],[]],[[],[]]
s=0,m=2,n=2,p=2

print "Enter the Elements for matrix(each element in each line)"

for  i in range(m):
    for j in range(n):
        matA[i]+=[int(raw_input(" "))]

print "Enter the Elements for matrix(each element in each line)"
for  i in range(n):
    for j in range(p):
        matB[i] +=[int(raw_input(" "))]

print "The Matrix Multiplication is :"
for  i in range(m):
    for j in range(p):
        for k in range(n):
            s+=matA[i][k]*matB[k][j]
        matC[i]+=[s]
        s = 0
    
print matA,"+",matB,"=",matC        

raw_input("Press any Key to Continue")
