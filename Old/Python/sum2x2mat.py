

mat = []

row = []

for i in range(2):
	row.append(int(raw_input("Enter element")))

mat.append(row)
row = []
for i in range(2):
	row.append(int(raw_input("Enter element")))
mat.append(row)

sum=0
for row in mat:
	for col in row:
		sum+=col

print mat,sum



