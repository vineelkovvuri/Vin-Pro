

#Matrix addition in Python

matA,matB,matC = [[],[]],[[],[]],[[],[]]

#Input Matrix A
for  i in range(2):
    for j in range(2):
        matA[i] +=[int(raw_input(" "))]

#Input Matrix B
for  i in range(2):
    for j in range(2):
        matB[i] +=[int(raw_input(" "))]

#Find A+B
for  i in range(2):
    for j in range(2):
        matC[i] +=[matA[i][j]+matB[i][j]]

#Result
print "The Matrix Addition is :"
print matA,"+",matB,"=",matC        


raw_input("Press any Key to Continue....!")
