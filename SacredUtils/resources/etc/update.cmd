timeout /T 1
setlocal
cd %~dp0
del %~dp0\WPFSharp.Globalizer.dll /Q
start %~dp0\SacredUtils.exe