
# function to generate list of primes below a given number exluding 1 -- copied from net :)
def primes(n): 
	if n==2: return [2]
	elif n < 2: return []
	s=range(3,n+1,2)
	mroot = n ** 0.5
	half=(n+1)/2-1
	i=0
	m=3
	while m <= mroot:
		if s[i]:
			j=(m*m-3)/2
			s[j]=0
			while j<half:
				s[j]=0
				j+=m
		i=i+1
		m=2*i+3
	return [2]+[x for x in s if x]

count = 0
def decompose(n,idx):
	global count
	if n == 0: 
		count = count + 1
		return 
	if n == 1: return	
	while(idx < len(lst) and lst[idx] <= n):
		decompose(n - lst[idx],idx)
		idx = idx + 1

num = 100	
lst = primes(num)				

for el in range(num):			
	count = 0
	decompose(el,0)			
	print el,count    # element and its combinations 

# 71 is the least number to have 5007 combinations
