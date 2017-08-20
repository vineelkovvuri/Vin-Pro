import contacts


def Name2Num(search_name):
	search_name = search_name.lower()
	db = contacts.open()
	names = []
	name = ''
	for id in db.keys():
		name = ''
		con = db[id]    # get the contact for each key
		if len(con.find('first_name')) >= 1:		# if first name set is >= 1 then first exists	
			name = name + str(con.find('first_name')[0].value) +' '
		if len(con.find('last_name')) >= 1:		# if first name set is >= 1 then first exists	
			name = name + str(con.find('last_name')[0].value) + ' '
		if name.lower().find(search_name) > -1:	
			for mobile_num in con.find('mobile_number'):   	# get the mobile numbers in each contact
				name = name + '<' + str(mobile_num.value) + '>'	
			for mobile_num in con.find('phone_number'):   	# get the mobile numbers in each contact
				name = name + '<' + str(mobile_num.value) + '>'	
			names = names + [name]
	names.sort()
	print names


