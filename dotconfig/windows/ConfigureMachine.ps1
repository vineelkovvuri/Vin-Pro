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

[Environment]::SetEnvironmentVariable("_NT_SOURCE_PATH", "SRV*C:\Sources", [System.EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("_NT_SYMBOL_PATH", "SRV*C:\Symbols*https://symweb.azurefd.net;SRV*C:\Symbols*https://msdl.microsoft.com/download/symbols", [System.EnvironmentVariableTarget]::User)
AppendPathVariable -Path "$($env:USERPROFILE)\AppData\Local\DBG\UI"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\rg"
AppendPathVariable -Path "C:\Program Files\Git\usr\bin"
AppendPathVariable -Path "C:\Program Files\Git\cmd"
AppendPathVariable -Path "C:\Program Files\Notepad4"
AppendPathVariable -Path "C:\Program Files\Sublime Text"
AppendPathVariable -Path "C:\Program Files\eSpeak NG"
AppendPathVariable -Path "C:\Program Files (x86)\Meld\meld"
AppendPathVariable -Path "C:\msys64\ucrt64\bin"

