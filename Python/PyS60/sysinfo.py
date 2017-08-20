import sysinfo


str =  "Active Profile: "+ sysinfo.active_profile()
str += "\nBattery Info: "+ sysinfo.battery()    #battery information in symbian 
str += "\nDisplay Info: "+ sysinfo.display_pixels()
str += "\nFree Space: "   + sysinfo.free_drivespace()
str += "\nRAM(F/T): " + str(sysinfo.free_ram()/(1024.0*1024.0)) +"/"+ str(sysinfo.total_ram()/(1024.0*1024.0))
str += "\nIMEI: "+ sysinfo.imei()

