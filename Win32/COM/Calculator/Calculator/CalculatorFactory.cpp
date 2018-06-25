
#include "stdafx.h"
#include "CalculatorFactory.h"
#include "Calculator.h"
#include "dllmain.h"
CalculatorFactory::CalculatorFactory() : m_refCount(1)
{
	g_ObjectsRefCount++;
}

CalculatorFactory::~CalculatorFactory()
{
	g_ObjectsRefCount--;
}

HRESULT CalculatorFactory::CreateInstance(IUnknown * pUnknownOuter, REFIID iid, void ** ppv)
{
	HRESULT result = S_OK;

	// This classfactory does not have any
	// aggregation right now
	if (pUnknownOuter != nullptr) {
		return CLASS_E_NOAGGREGATION;
	}

	// The reason we only create this Class is
	// Each Class Factory is supposed to create
	// only object of one class
	// This relationship between a class and its
	// class factory is hardcoded in DllGetClassObject
	// entry function.
	// We only return class factory of class in
	// DllGetClassObject
	Calculator *Calc = new Calculator();  // Ref count == 1
	result = Calc->QueryInterface(iid, ppv);
	Calc->Release();

	return result;
}

//
// I dont know the reason, yet to find.
// But out of proc servers cannot account for the
// number of class factory objects used in memory
// Which will result in unloading the dll from memory
// even when the client is using the class factory object
// To prevent this, client can explicitly ask to Lock
// on the server while he is using it.
// Technically we can use the same refcount that we are
// using to ref count the total objects in this function
// but according to Dale Rogerson Inside COM book it is
// recomended to use different variables for this.
// Hence we use g_LocksRefCount
HRESULT CalculatorFactory::LockServer(BOOL bLock)
{
	if (bLock) {
		g_LocksRefCount++;
	}
	else {
		g_LocksRefCount--;
	}
	return S_OK;
}

HRESULT CalculatorFactory::QueryInterface(REFIID iid, void ** ppvObj)
{
	if (iid == IID_IUnknown || iid == IID_IClassFactory) {
		*ppvObj = static_cast<IClassFactory *>(this);
		static_cast<IClassFactory *>(this)->AddRef();
		return S_OK;
	}

	*ppvObj = nullptr;
	return E_NOINTERFACE;
}

ULONG CalculatorFactory::AddRef()
{
	return ++m_refCount;
}

ULONG CalculatorFactory::Release()
{
	--m_refCount;
	if (m_refCount == 0) {
		delete this;
		return 0;
	}
	return m_refCount;
}
