dotnet .\VegetaTargetGenerator\bin\Debug\netcoreapp2.1\VegetaTargetGenerator.dll %1 %2 | C:\Tools\vegeta\vegeta.exe attack -rate=%1 -duration=%2s -format=json > results.bin
C:\Tools\vegeta\vegeta.exe plot results.bin > results.html