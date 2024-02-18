// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"

#include "Calculator.h"
#include "CalculatorFactory.h"
#include <stdio.h>

// This ref count is to count the number
// of objects in memory that are created
// and based on it we will decide whether
// it is safe to unload the dll from memory
// g_ObjectsRefCount is incremented in
// every constructor and decremented
// in every destructor
// Based on this value in DllCanUnloadNow
// entry point we will return S_OK or S_FALSE
// to COM Runtime
ULONG g_ObjectsRefCount = 0;

// This is for ref counting the Lock calls
ULONG g_LocksRefCount = 0;

HMODULE g_hModule = nullptr;

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
	g_hModule = hModule;

    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
// Eventually this function will be rolled in to
// IClassFactory CreateInstance
IUnknown * CreateCalculatorInstance()
{
	Calculator *calc = new Calculator();
	IUnknown *ptr = nullptr;
	calc->QueryInterface(IID_IUnknown, (void**)&ptr);
	return ptr;
}

STDAPI DllGetClassObject(
	REFCLSID clsid,
	REFIID iid,
	void ** ppv)
{
	HRESULT result = S_OK;
	// Always One class factory is associated with
	// one class.
	// So if requested class is not what we can provide
	// return CLASS_E_CLASSNOTAVAILABLE
	if (clsid != CLSID_Calculator) {
		return CLASS_E_CLASSNOTAVAILABLE;
	}

	// Ref count == 1
	CalculatorFactory *CalcFact = new CalculatorFactory();
	// iid will be IClassFactory from CoGetClassObject COM API
	result = CalcFact->QueryInterface(iid, ppv); //Ref Count == 2
	CalcFact->Release(); //Ref Count == 1

	return result;
}

STDAPI DllCanUnloadNow()
{
	// We need to make sure both number of objects and
	// and locks are zero before let the dll to be unloaded
	if (g_ObjectsRefCount == 0 && g_LocksRefCount == 0) {
		return S_OK;
	}
	return S_FALSE;
}

//
// Server registration
//
STDAPI DllRegisterServer()
{
	HKEY ProgIdKey, ClsidKey, ClsidGuidKey, InprocServer32Key;
	LONG Result = 0;
	LPOLESTR ClsidString;
	WCHAR ModulePath[260] = { 0 };

	//
	// Create Progid directly under HKCU\<progid>
	//		Create CLSID directly under HKCU\<progid>\
	//		Set Default value to <CLSID of the component>
	//
	// Create <CLSID> under HKCU\CLSID
	//		Create InprocServer32 under HKCU\CLSID\<CLSID>\
	//		Set Default value to <file path to the component>
	//

	Result = RegCreateKeyEx(
		HKEY_CLASSES_ROOT,
		L"Calculator.Vineel",
		0,
		0,
		REG_OPTION_NON_VOLATILE,
		KEY_ALL_ACCESS,
		NULL,
		&ProgIdKey,
		NULL);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to create progid sub key in registry err = %d", GetLastError());
		return -1;
	}

	Result = RegCreateKeyEx(
		ProgIdKey,
		L"CLSID",
		0,
		0,
		REG_OPTION_NON_VOLATILE,
		KEY_ALL_ACCESS,
		NULL,
		&ClsidKey,
		NULL);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to create progid sub key in registry err = %d", GetLastError());
		return -1;
	}

	StringFromCLSID(CLSID_Calculator, &ClsidString); // This will mostly succceed
	//MessageBox(NULL, ClsidString, L"", MB_OK);
	RegSetValueEx(
		ClsidKey,
		L"", // Default key
		0,
		REG_SZ,
		(BYTE *)ClsidString,
		(DWORD)((wcslen(ClsidString) + 1) * sizeof(wchar_t)));

	CoTaskMemFree(ClsidString);
	RegCloseKey(ClsidKey);
	RegCloseKey(ProgIdKey);

	Result = RegOpenKeyEx(
		HKEY_CLASSES_ROOT,
		L"CLSID",
		0,
		KEY_ALL_ACCESS,
		&ClsidKey);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to open Clsid sub key in registry err = %d", GetLastError());
		return -1;
	}

	Result = RegCreateKeyEx(
		ClsidKey,
		ClsidString,
		0,
		0,
		REG_OPTION_NON_VOLATILE,
		KEY_ALL_ACCESS,
		NULL,
		&ClsidGuidKey,
		NULL);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to create Clsid guid sub key in registry err = %d", GetLastError());
		return -1;
	}
	Result = RegCreateKeyEx(
		ClsidGuidKey,
		L"InprocServer32",
		0,
		0,
		REG_OPTION_NON_VOLATILE,
		KEY_ALL_ACCESS,
		NULL,
		&InprocServer32Key,
		NULL);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to create InprocServer32 sub key in registry err = %d", GetLastError());
		return -1;
	}

	GetModuleFileName(g_hModule, ModulePath, 260);
	RegSetValueEx(
		InprocServer32Key,
		L"", // Default key
		0,
		REG_SZ,
		(BYTE *)ModulePath,
		(DWORD)((wcslen(ModulePath) + 1) * sizeof(wchar_t)));

	RegCloseKey(ClsidKey);
	RegCloseKey(ClsidGuidKey);
	RegCloseKey(InprocServer32Key);

	return S_OK;
}

//
// Server unregistration
//
STDAPI DllUnregisterServer()
{
	HKEY ClsidKey;
	LONG Result = 0;
	LPOLESTR ClsidString;

	//
	// Remove above keys
	//

	RegDeleteTree(HKEY_CLASSES_ROOT, L"Calculator.Vineel");

	Result = RegOpenKeyEx(
		HKEY_CLASSES_ROOT,
		L"CLSID",
		0,
		KEY_ALL_ACCESS,
		&ClsidKey);
	if (Result != ERROR_SUCCESS) {
		printf("Unable to open Clsid sub key in registry err = %d", GetLastError());
		return -1;
	}
	StringFromCLSID(CLSID_Calculator, &ClsidString); // This will mostly succceed
	RegDeleteTree(ClsidKey, ClsidString);
	CoTaskMemFree(ClsidString);
	RegCloseKey(ClsidKey);
	return S_OK;
}
