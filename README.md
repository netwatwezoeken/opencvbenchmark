# Benchmarking OpenCvSharp vs OpenCV

Benchmarking to compare OpenCvSharp vs custom OpenCv wrapping.

## Background
OpenCvSharp is basically the same as having a custom wrapper around OpenCV. At least it should be, right?

The question was real and provided the perfect opportunity to play around with OpenCV do some C++ and try out BenchmarkDotNet.

## Build Instructions

- Visual Studio 2019 or later
  - VC++ features are required.
- Run `download_opencv.ps1` to download OpenCV libs and headers from https://github.com/opencv/opencv/.
```
.\download_opencv.ps1
```
- Build opencvbenchmark
  - Open `opencvbenchmark.sln` and build

## Run

### Visual Studio
- Run "opencvBenchmark" to run a benchmark. Use Ctrl+F5 to run without debugger attached
- Run "visual opencvBenchmark" to get visual feedback on the logic that is benchmarked

### Commandline
- Run "opencvBenchmark" to run a benchmark.
```
opencvBenchmark\bin\Release\net472\opencvBenchmark
```
- Run "opencvBenchmark" to run a benchmark. Use Ctrl+F5 to run without debugger
```
opencvBenchmark\bin\Release\net472\opencvBenchmark show
```

### Results
Results can be found n the console and as html report in `opencvBenchmark\bin\Release\net472\BenchmarkDotNet.Artifacts\results`

## Remarks
* The benchmark prints a line in case the results of the C++ and C# implementions differ. This could be an indication that not the same logic is being compared.
* To better compare the actual image processing it could be better to pass the images by means of a byte array or memorystream so that loading the image from disk is not benchmarked.

## License
Apache 2 License, see `LICENSE` file