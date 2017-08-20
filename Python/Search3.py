
import os

#Start of Search3 Class
class Search3:
    def __init__(self):#This is the Constructor in Python it will always contains 
        return         #self as first parameter which is similar to "this" in JAVA   
    
    def search(self,path):#Every method contains the starting parameter self
        try:
            for s in os.listdir(path):
                filepath = os.path.join(path,s)
                if(os.path.isfile(filepath)):
                    print filepath
                else :
                    self.search(filepath) 
        except WindowsError:       #Exception thrown by windows method encounters 
            print "Access Denied at "+path #System Volume Information folder           
#End of Search3 Class


#Start of main method    
s = Search3()       #Creating Objects in Python
s.search('e:\\')    #Observe even though search method have 2 parameters the first
                    #parameter is not passed by us simply 'e:\\' is given to path
#End of main Method   
"""
						Non Recursive Search Method
paths=['d:\\']
temp=[]
while 1:
    for xyz in paths:
        for dir in os.listdir(xyz):
            path = xyz+"\\"+dir
            if  os.path.isdir(path):
                temp+=[path]
            else:
                print  path

    if  not temp :
        break
    paths = temp
    temp = []
"""
