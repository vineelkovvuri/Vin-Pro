#pragma once
#include "stdafx.h"
#include "ICalculatorFactory.h"

class CalculatorFactory : public ICalculatorFactory
{
	// This is per object ref count
	// Based on it we will delete the
	// object
	ULONG m_refCount;
public:
	CalculatorFactory();
	~CalculatorFactory();

	//
	// Method of ICalculatorFactory
	//

	virtual HRESULT STDMETHODCALLTYPE CreateInstance(
		IUnknown * pUnknownOuter,
		REFIID iid,
		void ** ppv);
	virtual HRESULT STDMETHODCALLTYPE LockServer(BOOL bLock);

	//
	// Method of IUnknown
	//

	virtual HRESULT STDMETHODCALLTYPE QueryInterface(REFIID iid, void **ppvObj);
	virtual ULONG STDMETHODCALLTYPE AddRef();
	virtual ULONG STDMETHODCALLTYPE Release();
};