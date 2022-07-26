#ifndef SHARED_LIB_H
#define SHARED_LIB_H

#include <iostream>
#include <Windows.h>
#include <vector>
#include <map>
#include <string>
#include <cstringt.h>
#include "DpiHelper.h"

using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

#ifdef BUILD_MY_DLL
#define SHARED_LIB __declspec(dllexport)
#else
#define SHARED_LIB __declspec(dllimport)
#endif

	int SHARED_LIB GetRecommendedDPIScaling();
	void SHARED_LIB SetDpiScaling(int percentScaleToSet);
	bool SHARED_LIB DPIFound(int val);

#ifdef __cplusplus
}
#endif

#endif