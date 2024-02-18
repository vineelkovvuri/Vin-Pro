
'script to capitalize files names
' ex:-   c:\hai AbD.txt  =>  c:\Hai abd.txt
'input: Path to the folder



Set fsobj = CreateObject("Scripting.FileSystemObject")
'Set shell = CreateObject("Shell.Application")
'Set folder = shell.BrowseForFolder(0,"Select the folder whose file names are to be capitalized",0)
Set folder = fsobj.GetFolder(InputBox("Enter the path to the folder Whose file names are to be capitalized")) 
'WScript.Echo folder.
'Traverse(obj.GetFolder(folder.Items.Item(0).Path))
Traverse(folder)

Sub Traverse(path)
    For Each file In path.Files
        WScript.Echo file.Name &" => "&Captialize(file.Name) 
        file.Move(fsobj.BuildPath(file.ParentFolder, Captialize(file.Name)))
    Next
    
    For Each dir In path.SubFolders
        WScript.Echo dir.Name &" => "&Captialize(dir.Name)
        dir.Move(fsobj.BuildPath(dir.ParentFolder, Captialize(dir.Name)))
        Traverse(dir)
    Next
End Sub

'Function which returns the capitalized form of a given sentence
Function Captialize(sen)
    a = ""
    For Each word In Split(sen," ")
         a = a & UCase(Left(word,1))&LCase(Mid(word,2))&" "
    Next
    a = Trim(a)
    Captialize = a
End Function
Function CaptializeWithPeriod(sen)
    a = ""
    BaseName = fsobj.GetBaseName(sen)
    BaseName = Replace(BaseName,"."," ")
    BaseName = Replace(BaseName,"_"," ")
    BaseName = Replace(BaseName,","," ")
    For Each word In Split(BaseName," ")
         a = a & UCase(Left(word,1))&Mid(word,2)&" "'LCase(Mid(word,2))&" "
    Next
    
    CaptializeWithPeriod = Trim(a)&"."&fsobj.GetExtensionName(sen)
End Function
