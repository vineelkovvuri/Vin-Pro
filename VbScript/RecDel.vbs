'Script to Clear the recents folder 

Set fsobj = CreateObject("scripting.filesystemobject")
Set shell = CreateObject("Wscript.Shell")
Set recFold = fsobj.GetFolder(shell.SpecialFolders("Recent"))  

For Each File In recFold.Files
	file.Delete
	'WScript.Echo file.Path
Next 
	
