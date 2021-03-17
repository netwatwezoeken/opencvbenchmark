// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc.hpp>

using namespace cv;

extern "C" {
    __declspec(dllexport) int match(char* a, char* b) {
        Mat image = imread(a);
        Mat templateImage = imread(b);
        Mat matchedImage;

        double minVal; double maxVal; Point minLoc; Point maxLoc;
        Point matchLoc;
        matchTemplate(image, templateImage, matchedImage, TM_CCORR_NORMED);
        minMaxLoc(matchedImage, &minVal, &maxVal, &minLoc, &maxLoc);
        return maxLoc.x;
    }
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
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