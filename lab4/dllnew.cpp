
#include"pch.h"

#define DLL2_API __declspec(dllexport)

extern "C"
{
	DLL2_API int _stdcall FindMax(int a[], int m)
	{
		int max_a = a[0];
		
			for (int j = 0; j < m; j++)
			{
				if (max_a < a[j])
				{
					max_a = a[j];
				}
			}
		
		return max_a;
	}

	DLL2_API float _cdecl Aver(int a[], int m)
	{
		float sum = 0;

			for (int j = 0; j < m; j++)
			{
				sum += a[j];
			}
		
		return sum / m;
	}
}