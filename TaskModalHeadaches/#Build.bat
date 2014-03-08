@echo off

set framework=v4.0.30319

"%SystemDrive%\Windows\Microsoft.NET\Framework\%framework%\MSBuild.exe" TaskModalDialogs.sln

echo(
echo Build done. I hope everything went well :-)
echo(

pause
