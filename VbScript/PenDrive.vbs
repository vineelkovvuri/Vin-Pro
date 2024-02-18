

Set fso = CreateObject("Scripting.filesystemobject")

Dim susfolder

if not fso.FolderExists ("c:\suspicious") then fso.CreateFolder( "c:\suspicious" )    'create a folder to copy suspicious files

set susfolder = fso.GetFolder( "c:\suspicious" )





For Each drive In fso.Drives
	If drive.drivetype = 1 then 'removeable drive
'		if not fso.FolderExists (drive.path&"\suspicious") then
'			susfolder = fso.CreateFolder( drive.path&"\suspicious" )    'create a folder to copy suspicious files
'		else 
'			susfolder = fso.GetFolder( drive.path&"\suspicious" )
'		end if
		ProcessPenDrive fso.GetFolder(drive.path&"\")
	end if 
Next 


Sub ProcessPenDrive(path)
	'Files 
	for each file in path.files
		if (file.Attributes and (2 or 4)) = (2 or 4) then  'check for hidden and system
			file.Attributes = file.Attributes And (Not ( 1 Or 2 Or 4 ))    'clear system and hidden attribute
			wscript.echo file.path
			file.move fso.buildpath(susfolder.path,file.name)
		end if
	next
	
	'Folders
	for each folder in path.SubFolders
		if (folder.Attributes and (2 or 4)) = (2 or 4) then  'check for hidden and system
			folder.Attributes = folder.Attributes And (Not ( 1 Or 2 Or 4 ))    'clear system and hidden attribute
			wscript.echo folder.path
			folder.move fso.buildpath(susfolder.path,folder.name)
			wscript.echo fso.buildpath(susfolder.path,folder.name)
			ProcessPenDrive fso.GetFolder(folder.path)
		end if
	next
end sub 

