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
[Environment]::SetEnvironmentVariable("_NT_SYMBOL_PATH", "SRV*C:\Symbols*http://symweb;SRV*C:\Symbols*https://msdl.microsoft.com/download/symbols", [System.EnvironmentVariableTarget]::User)
AppendPathVariable -Path "$($env:USERPROFILE)\AppData\Local\DBG\UI"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\npp"
AppendPathVariable -Path "$($env:USERPROFILE)\OneDrive\Softs\Tools\rg"
AppendPathVariable -Path "C:\Program Files\Git\usr\bin"
AppendPathVariable -Path "C:\Program Files\Git\cmd"
AppendPathVariable -Path "C:\Program Files\Notepad2"
AppendPathVariable -Path "C:\Program Files\Sublime Text"

