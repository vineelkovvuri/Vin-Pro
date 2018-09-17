import inbox

id=0
def newsms_callback(msg_id):
	global id
	id = msg_id

i=inbox.Inbox()
i.bind(newsms_callback)
i.content(id)
i.address(id)
i.set_unread(id,0)
	



'''
Normal way of reading inbox messages......
i=inbox.Inbox()
m=i.sms_messages()
i.content(m[0])
i.set_unread(m[0],0)
i.address(m[0])


'''
