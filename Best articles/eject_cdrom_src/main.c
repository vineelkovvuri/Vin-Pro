#include <windows.h>
#include <mmsystem.h>

BOOL fHelp = FALSE;

char HelpText[] = 
"CDROM - CD/DVD open/close utility for MS Windows - © 2005 by eraser (eraser@senior.cz)\n\n"
"Syntax: CDROM open | close letter\n\n"
" \t<none>\t- display this message\n"
"\topen\t- open drive\n"
"\tclose\t- close drive\n"
"\tletter\t- drive letter\n\n"
"Examples:\n"
"\tcdrom.exe open E\t- open drive E\n"
"\tcdrom.exe close E\t- close drive E";


void CDRomOpen(BOOL bOpenDrive, char *drive);
int ProcessCommandLine(LPSTR lpCmdLine, BOOL *cmd, char *drive);

int	WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow)
{
	BOOL open;
	char drive[8];

	ProcessCommandLine(szCmdLine, &open, drive);

	if (fHelp)
	{
		MessageBox(NULL, HelpText, "CD/DVD-Drive utility", MB_OK);

		return 0;
	}

	CDRomOpen(open, drive);

	return 0;
}

void CDRomOpen(BOOL bOpenDrive, char *drive)
{ 
	MCI_OPEN_PARMS open;
	DWORD flags;

	ZeroMemory(&open, sizeof(MCI_OPEN_PARMS));

	open.lpstrDeviceType = (LPCSTR) MCI_DEVTYPE_CD_AUDIO;
	open.lpstrElementName = drive;

	//flags = MCI_OPEN_TYPE | MCI_OPEN_TYPE_ID | MCI_OPEN_SHAREABLE;
	flags = MCI_OPEN_TYPE | MCI_OPEN_TYPE_ID;

	if (!mciSendCommand(0, MCI_OPEN, flags, (DWORD) &open)) 
	{
		mciSendCommand(open.wDeviceID, MCI_SET, (bOpenDrive) ? MCI_SET_DOOR_OPEN : MCI_SET_DOOR_CLOSED, 0);
		mciSendCommand(open.wDeviceID, MCI_CLOSE, MCI_WAIT, 0);
	}
}

int ProcessCommandLine(LPSTR lpCmdLine, BOOL *cmd, char *drive)
{
	int argc = 1;
	int i;
	char **argv;
	static char seps[] = " ";
	char *token;

	if (*lpCmdLine == '\0')
	{
		fHelp = TRUE;

		return 0;
	}

	strlwr(lpCmdLine);

	token = lpCmdLine;

	// Find out the number of tokens in the string
	if (*token == ' ')
	{
		while (*token++ == ' ')		// Trim left
			;
	}

	if (*token != '\0')
	{
		i = lstrlen(lpCmdLine);

		while (lpCmdLine[--i] == ' ')	// Trim right
		{
			lpCmdLine[i] = '\0';
		}
	}

	while (*token != '\0')
	{
		if (*token == ' ')
		{
			argc++;
		}

		while (*token++ == ' ')
			;
	}

	argc++;

	if ((argv = (char **) malloc((argc + 1) * sizeof(char *))) == NULL)
	{
		return 1;
	}

	argv[0] = "cdrom";
	argv[1] = strtok(lpCmdLine, seps);
	
	for (i = 2; i < argc; i++)
	{
		argv[i] = strtok(NULL, seps);
	}

	argv[argc] = '\0';

	if (argc >= 3)
	{
		if (!lstrcmp(argv[1], "open"))
			*cmd = TRUE;
		else if (!lstrcmp(argv[1], "close"))
			*cmd = FALSE;
		else
		{
			fHelp = TRUE;

			return 0;
		}

		wsprintf(drive, "%c:", argv[2][0]);
	}
	else
	{
		fHelp = TRUE;

		return 0;
	}

	return 0;
}
