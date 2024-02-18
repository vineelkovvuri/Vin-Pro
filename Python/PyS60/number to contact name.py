

#program to find the contact name for a given mobile number -- vineel

import contacts

def Num2Name(mobile_number):
	db = contacts.open()
	name = ''
	for id in db.keys():
		con = db[id]    # get the contact for each key
		nums = []
		for mobile_field in con.find('mobile_number'):   	# get the numbers associated with this contact
			nums += [mobile_field.value]
		for mobile_field in con.find('phone_number'):   	# get the numbers associated with this contact
			nums += [mobile_field.value]
			
		for num in nums		#iterate over all the number associated with a contact number
			if str(num).endswith(mobile_number) == 1 :
				if len(con.find('first_name')) >= 1:		# if first name set is >= 1 then first exists
					name += str(con.find('first_name')[0].value) +' ' 
				if len(con.find('last_name'))  >= 1:		# if last name set is >= 1 then last exists
					name += str(con.find('last_name')[0].value) + ' '
				print str(name)


def ListContacts():
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
		for mobile_num in con.find('mobile_number'):   	# get the mobile numbers in each contact
			name = name + '<' + str(mobile_num.value) + '>'	
		for mobile_num in con.find('phone_number'):   	# get the mobile numbers in each contact
			name = name + '<' + str(mobile_num.value) + '>'	
			
		names = names + [name]
	names.sort()
	print names

			
			
			