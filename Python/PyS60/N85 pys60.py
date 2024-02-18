

# Common routines to pys60 for my N85 -- vineel

import contacts
import inbox
import messaging
import telephone
import time

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
	'''
	i=0
	for name in names:
		print name[0:30] +'\t',
		i += 1
		if i%2 == 0: print 
	'''
	print '------------------------'

	
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
		for num in nums:		#iterate over all the number associated with a contact number
			if str(num).endswith(mobile_number) == 1 :
				if len(con.find('first_name')) >= 1:		# if first name set is >= 1 then first exists
					name += str(con.find('first_name')[0].value) +' ' 
				if len(con.find('last_name'))  >= 1:		# if last name set is >= 1 then last exists
					name += str(con.find('last_name')[0].value) + ' '
				print str(name) + '<' + mobile_number + '>' 
				print '------------------------'



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
	print '------------------------'


def contactName2Number(contact):
	if len(contact) > 0 and contact[-1].isalpha() : # if given contact is name we need to convert it to number 
		contact = contact.lower().strip()
		db = contacts.open()
		num = ''
		for id in db.keys():
			name = '' 
			con = db[id]    # get the contact for each key
			if len(con.find('first_name')) >= 1:		# if first name set is >= 1 then first exists	
				name = str(con.find('first_name')[0].value) +' '
			if len(con.find('last_name')) >= 1:		# if first name set is >= 1 then first exists	
				name = name + str(con.find('last_name')[0].value) 
			if name.strip().lower() == contact :	
				for mobile_num in con.find('mobile_number'):   	# get the mobile numbers in each contact
					num = str(mobile_num.value)
				for mobile_num in con.find('phone_number'):   	# get the mobile numbers in each contact
					num = str(mobile_num.value)
		contact	= num 
	return contact.lstrip('+')[-10:]     # strip + sign and country code etc

def SendSMS(contact='',content=''):
	contact_name = contact
	contact = contactName2Number(contact)
	if contact == '':
		contact = str(raw_input('Please enter the number: '))
	if content == '':
		content = str(raw_input('Please enter msg content: '))
	if contact != '':	
		messaging.sms_send(contact.strip(),content)		
		print 'Message sent to '+ str(contact_name + ' <' + contact + '>')		
		print '------------------------'
	



def ReadMessages(folder_type=inbox.EInbox, readCount=1):
	i=inbox.Inbox(folder_type)
	for msgid in i.sms_messages():
		print i.address(msgid) + ' ['+ time.strftime('%a %b %d %H:%M:%S %Y',time.localtime(i.time(msgid))) + ']'
		print i.content(msgid)
		i.set_unread(msgid,0)
		print '------------------------'
		if readCount == -1: #dont limit if user asked us to read all the msgs by passing -1
			pass
		else:				#limit msg reading 
			readCount -= 1
			if readCount == 0 : break		
	
def Messaging():
	choice = ''
	while choice != 'x':
		print ' Messaging \n-----------'
		print '  1.New Message'
		print '  2.Inbox'
		print '  3.Sent'
		print '  4.Drafts'
		print '  5.Outgoing'
		print '  x.Go back'
		choice = str(raw_input('Enter your choice: '))
		if choice == '1':
			contact = str(raw_input('Enter the contact:'))	
			SendSMS(contact)
		elif choice == '2':
			ReadMessages(inbox.EInbox)
		elif choice == '3':
			ReadMessages(inbox.ESent)
		elif choice == '4':
			ReadMessages(inbox.EDraft)
		elif choice == '5':
			ReadMessages(inbox.EOutbox)
		elif choice == 'x':
			break

def Contacts():
	choice = ''
	while choice != 'x':
		print ' Contacts \n----------'
		print '  1.Num2Name'
		print '  2.Name2Num'
		print '  3.List All Contacts'
		print '  x.Go back'
		choice = str(raw_input('Enter your choice: '))
		if choice == '1' :
			num = str(raw_input('Enter a number:'))
			Num2Name(num)
		elif choice == '2':
			name = str(raw_input('Enter a name:'))
			Name2Num(name)
		elif choice == '3':
			ListContacts()
		elif choice == 'x':
			break

def Dial(contact=''):
	contact_name = contact
	contact = contactName2Number(contact)
	if contact == '':
		contact = str(raw_input('Please enter the number: '))
	if contact != '':	
		print 'Dialing to '+ str(contact_name + ' <' + contact + '>')		
		telephone.dial(contact.strip())		
		print '------------------------'
			
def Call():
	choice = ''
	while choice != 'x':
		print ' Call \n----------'
		print '  1.Dial a number'
		print '  2. '
		print '  3. '
		print '  x.Go back'
		choice = str(raw_input('Enter your choice: '))
		if choice == '1' :
			contact = str(raw_input('Enter the contact:'))	
			Dial(contact)
		elif choice == 'x':
			break

	
def Main():
	choice = ''
	while choice != 'x':
		print '1.Messaging'
		print '2.Contacts'
		print '3.Call'
		print 'x.Exit'
		choice = str(raw_input('Enter your choice: '))
		if choice == '1' :
			Messaging()
		elif choice == '2':
			Contacts()
		elif choice == '3':
			Call()
		elif choice == 'x':
			break


#Start the program
Main()


