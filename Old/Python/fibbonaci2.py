
n = int(raw_input("Enter the n = "))

x,y=1,1

while n>0:
	print str(x)+" ",
	x,y = y,x+y
	n-=1



