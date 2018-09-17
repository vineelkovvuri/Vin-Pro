



def fibb(n):
	if n == 1 or n == 0:
		return n
	return fibb(n-1)+fibb(n-2)

n = int(raw_input("Enter the n = "))

for i in range(n+1):
	print fibb(i),"   ",


