

# program ot find the e^x value

x  = int(raw_input("ENter x = "))
s = 1.0
i=1.0
term =1.0
while i<10:			#10 terms
	term*=(x/i)
	s+=term
	i+=1
print "S = ",s



