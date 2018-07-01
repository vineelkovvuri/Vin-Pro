# Setup Environment Variables

Set-ExecutionPolicy Unrestricted;

Function AppendPathVariable
{
    param($Path = $null)

    $UserPath = [Environment]::GetEnvironmentVariable("Path", [System.EnvironmentVariableTarget]::User);
    $SystemPath = [Environment]::GetEnvironmentVariable("Path", [System.EnvironmentVariableTarget]::Machine);

    if (!$UserPath.Contains($Path.ToLower()) -and !$SystemPath.Contains($Path.ToLower()))
    {
        [Environment]::SetEnvironmentVariable("Path", $UserPath + ";$($Path)", [System.EnvironmentVariableTarget]::User)
    }
}

[Environment]::SetEnvironmentVariable("WINDBG_INVOKE_EDITOR", "subl.exe %f:%l", [System.EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("_NT_SOURCE_PATH", "SRV*C:\Sources", [System.EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("_NT_SYMBOL_PATH", "SRV*C:\Symbols*http://symweb;SRV*C:\Symbols*https://msdl.microsoft.com/download/symbols", [System.EnvironmentVariableTarget]::User)
AppendPathVariable -Path "$($env:LOCALAPPDATA)\Programs\Python\Python36\"
AppendPathVariable -Path "$($env:LOCALAPPDATA)\Programs\Python\Python36\Scripts"
AppendPathVariable -Path "$($env:USERPROFILE)\AppData\Local\DBG\UI"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\FSCapture86"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\SysinternalsSuite"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\SublimeText"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\npp"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\meld\meld"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\rg"
AppendPathVariable -Path "C:\Program Files\Debugging Tools for Windows (x64)"
AppendPathVariable -Path "C:\Program Files\Git\usr\bin"
AppendPathVariable -Path "C:\Program Files\Git\cmd"


#$RegKey = "HKLM:\Software\Microsoft\Windows NT\CurrentVersion\Winlogon";
#Set-ItemProperty -path "$RegKey" -name ForceAutoLogon -value 0;

#$RegKey = "HKLM:\Software\Microsoft\SecurityManager";
#Set-ItemProperty -path $RegKey -Name InternalDevUnlock -Value 1;

#$RegKey = "HKLM:\Software\Microsoft\Windows NT\CurrentVersion\Winlogon";
#Set-ItemProperty -path "$RegKey" -name DisableLockWorkStation -value 1;

# Turn off the frequent "make your PC more secure" modal dialog that results from having auto lock disabled.
#$RegKey = "HKLM:\Software\Microsoft\ActiveSync";
#Set-ItemProperty -path "$RegKey" -name AutoConfigureAADAllowed -value 0;

# "Enabling powershell remoting.";
#Enable-PSRemoting -Force | Out-Null;
#sc.exe config winrm start= auto | Out-Null;

# "Enabling file sharing and remote desktop firewall rules.";
& netsh advfirewall firewall set rule group="File and Printer Sharing" new enable=Yes | Out-Null;
& netsh advfirewall firewall set rule group="remote desktop" new enable=Yes | Out-Null;

& reg import .\registryhacks.reg

# Install Pygments for Latex
#& "$($env:LOCALAPPDATA)\Programs\Python\Python36\Scripts\pip.exe" install pygments

