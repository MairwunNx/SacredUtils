Stop-Process -Name "SacredUtils"
$invocation = (Get-Variable MyInvocation).Value
$directorypath = Split-Path $invocation.MyCommand.Path
$settingspath = $directorypath + "\WPFSharp.Globalizer.dll";
$filepath = $directorypath + "\psinfo.su";
$runfile = Get-Content $filepath
Remove-Item $settingspath

Start-Process $runfile