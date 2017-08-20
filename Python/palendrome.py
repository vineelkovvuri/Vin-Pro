



n = int(raw_input("Enter a Number:"))
s = 0
temp = n

while n!=0:
	s = s*10+n%10
	n/=10
if temp == s:
	print temp," Is Palendrome"
else :
	print temp," Not a Palendrome"




