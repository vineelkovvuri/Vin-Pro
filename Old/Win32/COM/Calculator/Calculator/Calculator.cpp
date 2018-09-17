// Calculator.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Calculator.h"
#include "dllmain.h"

Calculator::Calculator() : m_refCount(1)
{
	g_ObjectsRefCount++;
}

Calculator::~Calculator()
{
	g_ObjectsRefCount--;
}

int Calculator::Add(int First, int Second)
{
	return First + Second;
}

int Calculator::Sub(int First, int Second)
{
	return First - Second;
}

int Calculator::Mul(int First, int Second)
{
	return First * Second;
}

int Calculator::Div(int First, int Second)
{
	return First / Second;
}

HRESULT Calculator::QueryInterface(REFIID iid, void ** ppvObj)
{
	if (iid == IID_IUnknown) {
		// This cast is mandatory to make sure we return the right interface offset
		// Because ppvObj of type void we need this explicit cast
		*ppvObj = static_cast<IUnknown *>(this);
		static_cast<IUnknown *>(this)->AddRef();
		return S_OK;
	}
	else if (iid == IID_ICalculator) {
		*ppvObj = static_cast<ICalculator *>(this);
		static_cast<ICalculator *>(this)->AddRef();
		return S_OK;
	}

	return E_NOINTERFACE;
}

ULONG Calculator::AddRef()
{
	return m_refCount++;
}

ULONG Calculator::Release()
{
	m_refCount--;
	if (m_refCount == 0) {
		delete this;
		return 0;
	}
	return m_refCount;
}

