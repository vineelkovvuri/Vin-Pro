#include<windows.h>
#include<tchar.h>

#define IDI_ICON1 0

TCHAR className[] = _T("Window1");
HINSTANCE hInst;
LRESULT CALLBACK MyProc(HWND hwnd,UINT msg,WPARAM wParam,LPARAM lParam)
{
	switch(msg)
	{	
		case WM_LBUTTONDOWN:
			{
				TCHAR buf[100];
				HDC dc = GetDC(hwnd);
				wsprintf(buf,_T("%#x"),(int)hInst);
				TextOut(dc,10,20,buf,_tcslen(buf));

				ReleaseDC(hwnd,dc);

			}
			break;	
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		default:
			return DefWindowProc(hwnd,msg,wParam,lParam);
	}
	return 0;
}

int __stdcall WinMain(HINSTANCE hInst,HINSTANCE hPrevInst,LPSTR lpCmdLine,int nShowCmd)
{
	WNDCLASS wcl;
 	::hInst = hInst;
	//	InitCommonControls();
	//	wcl.cbSize = sizeof(WNDCLASSEX);
	wcl.style = 0;
	wcl.cbClsExtra = 0;
	wcl.cbWndExtra = 0;
	wcl.hbrBackground = (HBRUSH)GetStockObject(GRAY_BRUSH);
	wcl.hCursor = LoadCursor(NULL,IDC_ARROW);
	wcl.hIcon = LoadIcon(hInst,"IDI_ICON1");//LoadIcon(NULL,IDI_APPLICATION);
	wcl.hInstance = hInst;
	wcl.lpszClassName = className;
	wcl.lpfnWndProc = MyProc;
	wcl.lpszMenuName = 0;
	//	wcl.hIconSm = 0 ;

	//	MessageBox(NULL,"asdfaSD","asfas",MB_OK);
	if(!RegisterClass(&wcl))return 0;
	HWND hwnd;
	hwnd = CreateWindow(className,_T("If u open cmd i ll close it he he he.....!!!!"),WS_OVERLAPPEDWINDOW ,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,
			NULL,NULL,hInst,NULL);

	ShowWindow(hwnd,nShowCmd);
	UpdateWindow(hwnd);

	//	SetTimer(hwnd,1,2000,NULL);
	MSG msg;
	while(GetMessage(&msg,NULL,0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	//	KillTimer(hwnd,1);
	return msg.wParam;
}


