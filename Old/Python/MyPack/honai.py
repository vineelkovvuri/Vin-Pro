
"""
a) Move n - 1 disks from peg a to peg b, using peg c as temporary holding area.
b) Move the last disk (the largest) from peg a to peg c.
c) Move the n - 1 disks from peg b to peg c, using peg a as  temporary holding area.
"""
#---------------------------------------------
def honai(n,x,y,z):
	if n==0:
 		return
	honai(n-1,x,z,y)
	print "Move ",n," From ",x," To ",z
	honai(n-1,y,x,z)
#---------------------------------------------



