// CalculatorClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <ICalculator.h>
#include <Windows.h>

// Since DllRegisterServer and ClassFactory is implemented
// in the server we don't have manually load the dll by ourselfs
// COM Runtime CoCreateInstance will do it for us.
// So commenting it out now.
#if 0
// This path will be populated by Server's DllRegisterServer entry point
// in registry.
wchar_t ComponentPath[1024] = L"C:\\Users\\vineelko\\source\\repos\\Calculator\\x64\\Debug\\Calculator.dll";

// This function will be replaced with CoCreateInstance
// Below is the job of CoCreateInstance
IUnknown * CreateCalculatorInstanceByDynamicLoad()
{
	HMODULE hModule = nullptr;
	typedef IUnknown* (*CreateCall)();
	CreateCall fp = nullptr;

	hModule = LoadLibrary(ComponentPath);
	if (hModule == nullptr) {
		printf("The module cannot be loaded err = %d", GetLastError());
		return nullptr;
	}

	fp = (CreateCall)GetProcAddress(hModule, "CreateCalculatorInstance");
	if (fp == nullptr) {
		printf("The address of the function could not be found err = %d", GetLastError());
		return nullptr;
	}

	// we are intensionally not unloading the libary because
	// we will be using it.
	return fp();
}
#endif

int main()
{
	IUnknown * iun = nullptr;
	ICalculator * ical;
	HRESULT result = S_OK;

    // Below code is commented and replaced by COM Runtime
	// iun = CreateCalculatorInstanceByDynamicLoad();
	// if (iun == nullptr) {
	// 	printf("Unable to get to IUnknown interface pointer err = %d", GetLastError());
	// 	return -1;
	// }

    CoInitialize(NULL);
    result = CoCreateInstance(
        CLSID_Calculator,
        NULL,
        CLSCTX_INPROC_SERVER,
        IID_IUnknown,
        (void **)&iun);
    if (FAILED(result)) {
        printf("Unable to create IUnknown from CoCreateInstance. err = %d", GetLastError());
        return -1;
    }

	result = iun->QueryInterface(IID_ICalculator, (void **)&ical);
	if (FAILED(result)) {
		printf("Unable to query for ICalculator interface pointer err = %d", GetLastError());
		return -1;
	}

	printf("\n%d", ical->Add(10, 20));
	ical->Release();
	iun->Release();
    CoUninitialize();
    return 0;
}

