On Error Resume Next 

Set fso = CreateObject("Scripting.filesystemobject")


For Each drive In fso.Drives
		ProcessPenDrive fso.GetFolder(drive.path&"\")
Next 


Sub ProcessPenDrive(path)
	'Files 
	If fso.FileExists path.Name & ".exe" Then
		wscript.echo "Deleted File :" & file.path  
		file.Delete True 
	End If
		
	'Folders
	for each folder in path.SubFolders
'			wscript.echo folder.path
			ProcessPenDrive fso.GetFolder(folder.path)
	next
end sub 

