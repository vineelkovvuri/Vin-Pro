
#include "stdafx.h"
#include "ICalculator.h"

class Calculator : public ICalculator
{
	// This is per object ref count
	// Based on it we will delete the
	// object
	ULONG m_refCount;
public :
	Calculator();
	~Calculator();

	//
	// Method of ICalculator
	//

	virtual int STDMETHODCALLTYPE Add(int First, int Second);
	virtual int STDMETHODCALLTYPE Sub(int First, int Second);
	virtual int STDMETHODCALLTYPE Mul(int First, int Second);
	virtual int STDMETHODCALLTYPE Div(int First, int Second);

	//
	// Method of IUnknown
	//

	virtual HRESULT STDMETHODCALLTYPE QueryInterface(REFIID iid, void **ppvObj);
	virtual ULONG STDMETHODCALLTYPE AddRef();
	virtual ULONG STDMETHODCALLTYPE Release();


};
