import copy

def PowerSet(n):
	if n == 0:	return [[]]
	else :
		set1 = PowerSet(n-1)
		set2 = copy.deepcopy(set1)
		for s in set1:
			s.append(n)
		set2 += set1
		return set2	

print PowerSet(4)

