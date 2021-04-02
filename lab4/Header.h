#pragma once

#ifdef DLL2_EXPORTS
#define DLL2_API __declspec(dllexport)
#else
#define DLL2_API __declspec(dllimport)
#endif

extern "C"
{
	DLL2_API float __cdecl Aver(int a[], int m);
	DLL2_API int __stdcall FindMax(int a[], int m);
}