
Set fso = CreateObject("scripting.filesystemobject")
Set outfile = fso.CreateTextFile("c:\sysinfo.txt")

Set wmi = GetObject("winmgmts:\\.\root\cimv2")

PrintOsInfo()

PrintUsersInfo()
PrintHardwareInfo()
'PrintSoftwareInfo()
PrintProcessesInfo()
PrintServiceInfo()

outfile.Close


'-----------------------------------------------------------------------------------------------------------------------------------------
'prints users name
Sub PrintUsersInfo()
Set rows = wmi.ExecQuery("select username from Win32_ComputerSystem",,48)
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " Logged User Name: "&row.username 
Next 


Set rows = wmi.ExecQuery("Select * from Win32_UserAccount where status='OK'",,48)
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " User Name: "&row.Caption 
Next 

outfile.writeline "==============================================================================="
End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'prints Hardware Info
Sub PrintHardwareInfo()

'Get Processor info
Set rows = wmi.ExecQuery("select * from Win32_Processor",,48)
Outfile.WriteLine " Processor Information "
For Each row In rows
	outfile.WriteLine"		Name: "&row.Name _
			 &vbCrLf&"        Caption: "&row.Caption _ 
			 &vbCrLf&"        Manufacturer: "&row.Manufacturer 
	If row.architecture = 0 Then	outfile.WriteLine "	    Architecture: x86"
	If row.architecture = 6 Then	outfile.WriteLine "	    Architecture: Itanium"
	If row.architecture = 9 Then	outfile.WriteLine "	    Architecture: x64"
Next 

'Get RAM Info
Set rows = wmi.ExecQuery("select freephysicalmemory,totalvisiblememorysize from win32_operatingsystem",,48)
Outfile.WriteLine " RAM Information "
'Enumerate over all drives
For Each row In rows
	outfile.writeline 	 "		Total RAM : "&Round(row.totalvisiblememorysize/(1024),2)&" MB" _
					&vbCrLf&"        Free RAM : "&Round(row.freephysicalmemory/(1024),2)&" MB" 
Next 

'Get Video Configuration Info
Set rows = wmi.ExecQuery("Select * from Win32_VideoController",,48)
Outfile.WriteLine " Video Configuration Info Information "
'Enumerate over all drives
For Each row In rows
	outfile.writeline 	 "		Name : "&row.Name _
					&vbCrLf&"        Graphic Card RAM : "&Round(row.AdapterRAM/(1024*1024),2)&" MB" _
					&vbCrLf&"        Video Mode : "&row.VideoModeDescription
Next 

'Print Drive Information
Set rows = wmi.ExecQuery("select name,volumename,filesystem, freespace,size  from win32_logicaldisk where drivetype=3",,48)
Outfile.WriteLine " Fixed(Harddisc) Drive Information "
'Enumerate over all drives
freespace=0:totalsize=0
For Each row In rows
	outfile.WriteLine 	 "        Drive Path: "&row.name _
						&" File System: "&RPad(row.filesystem,5) _
						&" Free Space: "&RPad(Round(row.freespace /(1024*1024*1024),2),6)&" GB" _
						&" Total Space: "&RPad(Round(row.size /(1024*1024*1024),2),6)&" GB" 
	freespace = freespace + Round(row.freespace /(1024*1024*1024),2)
	totalsize = totalsize + Round(row.size /(1024*1024*1024),2)					
Next 
outfile.writeline "        ==============================================================================="
outfile.WriteLine "                                           Free Space: "&RPad(freespace,6)&" GB Total Size: "&RPad(totalsize,6)&" GB" 

'Get CD-DVD info
Set rows = wmi.ExecQuery("select * from Win32_CDROMDrive",,48)
Outfile.WriteLine " Removable Drive Information "
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " 		Name: "&row.Name _
						&", Drive Path: "&row.drive&"\" _
						&", Status: "&row.status 
Next 

outfile.writeline "==============================================================================="
End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'prints Software Info
Sub PrintSoftwareInfo()

'Get Software info
Set rows = wmi.ExecQuery("select * from Win32_Product",,48)
Outfile.WriteLine " Installed Software Information "
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " 		Name: "&row.Caption _
						 &", Version: "&row.Version _
						 &", Path: "&row.InstallLocation _
						 &", Vendor: "&row.Vendor
Next 

End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'prints services that are running currently
Sub PrintServiceInfo()
Set rows = wmi.ExecQuery("select Name,DisplayName,Description,pathname from win32_service where started=true",,48)
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " Start Name: "&row.Name _
						&vbCrLf&" Display Name: "&row.DisplayName _
						&vbCrLf&" Description: "&row.Description _					
						&vbCrLf&" Path Name: "&row.pathname 	
	outfile.WriteLine "---------------------------------------------------------------"					
Next 
outfile.writeline "==============================================================================="
End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'Prints some basic information about the operating system
Sub PrintOsInfo()
Set rows = wmi.ExecQuery("select Caption,CSDVersion,version,systemdirectory,freephysicalmemory,totalvisiblememorysize,lastbootuptime from win32_operatingsystem",,48)
'Enumerate over all drives
For Each row In rows
	outfile.writeline 	 " OS Name : "&row.Caption _
					&vbCrLf&" Service Pack : "&row.CSDVersion _
					&vbCrLf&" Version : "&row.Version _
					&vbCrLf&" System Directory : "&row.systemdirectory _
					&vbCrLf&" Total RAM : "&Round(row.totalvisiblememorysize/(1024),2)&" MB" _
					&vbCrLf&" Free RAM : "&Round(row.freephysicalmemory/(1024),2)&" MB" _
					&vbCrLf&" Last Boot Time : "&WMIDateStringToDate(row.lastbootuptime)
Next 
outfile.writeline "==============================================================================="
End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'Prints information about the running processes
Sub PrintProcessesInfo()
Set rows = wmi.ExecQuery("select processid,parentprocessid,caption,commandline,executablepath,threadcount,privatepagecount,priority,creationdate from win32_process",,48)
'Enumerate over all drives
For Each row In rows
	outfile.WriteLine 	 " PID: "&row.processid _
					&vbCrLf&" PPID: "&row.parentprocessid _
					&vbCrLf&" Caption: "&row.caption _
					&vbCrLf&" Commandline: "&row.commandline _
					&vbCrLf&" Executable Path: "&row.executablepath _
					&vbCrLf&" Thread Count: "&row.threadcount _
					&vbCrLf&" Private Page Count: "&Round(row.privatepagecount/(1024*1024),2)&" MB" _
					&vbCrLf&" Priority: "&row.priority _
					&vbCrLf&" Creation Date: "&WMIDateStringToDate(row.creationdate) 
	outfile.WriteLine "---------------------------------------------------------------"			
Next 
outfile.writeline "==============================================================================="
End Sub
'-----------------------------------------------------------------------------------------------------------------------------------------
'									Helper Functions
Function RPad(str,n)
	s=str
	If Len(str) < n Then
		Do 
			s = " "&s
		Loop Until Len(s) = n 
	End If
	RPad = s
End Function
'-----------------------------------------------------------------------------------------------------------------------------------------
Function WMIDateStringToDate(dtmBootup)
    WMIDateStringToDate =  _
        CDate(Mid(dtmBootup, 5, 2) & "/" & _
        Mid(dtmBootup, 7, 2) & "/" & Left(dtmBootup, 4) _
        & " " & Mid (dtmBootup, 9, 2) & ":" & _
        Mid(dtmBootup, 11, 2) & ":" & Mid(dtmBootup, _
        13, 2))
End Function
