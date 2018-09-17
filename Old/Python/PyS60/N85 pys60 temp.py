

# Common routines to pys60 for my N85 -- vineel

import contacts
import inbox
import messaging
import telephone
import time
import sysinfo
import e32
def Info():
	#print 'Device Time: ' + sysinfo.active_profile()
	print 'Active Profile: '.ljust(24) + sysinfo.active_profile()
	print 'Software Version: '.ljust(24) + str(sysinfo.sw_version())
	print 'OS Version: '.ljust(24) + str(sysinfo.os_version())
	print 'Battery: '.ljust(24) + str(sysinfo.battery()) +'%'
	print 'Display Resolution: '.ljust(24) + str(sysinfo.display_pixels()[0]) +'x'+str(sysinfo.display_pixels()[1])
	print 'IMEI: '.ljust(24) + sysinfo.imei()
	#print 'RAM Drive Size: ' + str(sysinfo.max_ramdrive_size())
	print 'RAM Size(total/free): '.ljust(24) + str(sysinfo.total_ram()) + str(sysinfo.free_ram())
	print 'ROM Size: '.ljust(24) + str(sysinfo.total_rom())
	print 'Free Drive Space: '.ljust(24) + str(sysinfo.free_drivespace())
	print 'Signal Strength:'.ljust(24) + str(sysinfo.signal_bars())
	

Info()


