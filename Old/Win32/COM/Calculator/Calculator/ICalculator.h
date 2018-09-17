#pragma once
#include <objbase.h>

interface ICalculator : IUnknown
{
	virtual int STDMETHODCALLTYPE Add(int First, int Second) = 0;
	virtual int STDMETHODCALLTYPE Sub(int First, int Second) = 0;
	virtual int STDMETHODCALLTYPE Mul(int First, int Second) = 0;
	virtual int STDMETHODCALLTYPE Div(int First, int Second) = 0;
};

// {D587071B-7A3E-4AB8-AECC-69D8E6E57050}
static const GUID IID_ICalculator =
{ 0xd587071b, 0x7a3e, 0x4ab8,{ 0xae, 0xcc, 0x69, 0xd8, 0xe6, 0xe5, 0x70, 0x50 } };

// {12A609A8-330A-42F7-B811-4B1B1686D0D9}
static const GUID CLSID_Calculator =
{ 0x12a609a8, 0x330a, 0x42f7,{ 0xb8, 0x11, 0x4b, 0x1b, 0x16, 0x86, 0xd0, 0xd9 } };
