
#ImageSource("L:\FareWell\farewell\FARWELL-PHOTOS\DSC00%d.JPG",526, 678,29.97)

#a = 
DirectShowSource("D:\vin-pro\AVS\a.AVI")
reverse
#b = DirectShowSource("D:\Vin-pro\AVS\unix.mpg")


#addborders(10,10,10,10,$ff1212)
#invert()
#Greyscale()
#b = DirectShowSource("D:\vin-pro\AVS\UNIX.mpg")
#StackVertical(a,b)
#ConvertToYUY2(c) 
#Subtitle ("Clip height is " + String (Framecount()) )
#ShowFrameNumber(a,scroll=true, offset=9, text_color=$ff0000)
#return a
#Trim(10,150)

#return a

