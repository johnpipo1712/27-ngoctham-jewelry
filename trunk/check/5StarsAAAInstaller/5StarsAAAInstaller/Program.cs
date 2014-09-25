using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _StarsAAAInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCmdText;
            strCmdText = @"@echo off
                        SetLocal EnableDelayedExpansion
                        set IdWebSite=670926

                        cscript //h:cscript //s

                        cscript %SYSTEMDRIVE%\inetpub\adminscripts\adsutil.vbs SET W3SVC/AppPools/Enable32bitAppOnWin64 1
                        %SYSTEMDRIVE%\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe -i
                        START %SYSTEMDRIVE%\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_compiler.exe
                        START %SYSTEMDRIVE%\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regbrowsers.exe
                        %SYSTEMDRIVE%\windows\System32\iisext /EnExt ASP
                        %SYSTEMDRIVE%\windows\System32\iisext /EnExt ASP
                        %SYSTEMDRIVE%\windows\System32\iisext /EnExt HTTPODBC
                        %SYSTEMDRIVE%\windows\System32\iisext /EnExt SSINC
                        %SYSTEMDRIVE%\windows\System32\iisext /EnExt WEBDAV" +
                        @"
                          " +
                        "%SYSTEMDRIVE%\\windows\\System32\\iisext /EnExt \"ASP.NET v2.0.50727\"" +
                        @"
                          " +
                        "%SYSTEMDRIVE%\\windows\\System32\\iisext /EnExt \"ASP.NET v2.0.50727 (32-bit)\"" +
                        @"
                          " +
                        @" %SYSTEMDRIVE%\windows\System32\IIsCnfg.vbs /import /f config.xml /sp /lm/w3svc/%IdWebSite% /dp /lm/w3svc/%IdWebSite% /children /inherited
                         %SYSTEMDRIVE%\windows\System32\iisweb /start AMS
                         %SYSTEMDRIVE%\windows\System32\iisreset" +

                        @"
                          " +
                         " FOR /F \"tokens=1,2 delims==\" %%G IN (setting.txt) DO (" +
                            @"if %%G EQU IpAddress (
                                   set ipAddress=%%H
                            )
                            if %%G EQU Port (
                                   set port=%%H
                            )
                        	
                            if %%G EQU LocalPathApplication (
                                   set localPath=%%H
                            )
                        )" +

                        " " +
                        @"
                         " +
                        " if not exist \"%localPath%\" (mkdir \"%localPath%\")" +
                        @" 
                             xcopy /s/e /y AMS %localPath%

                        ::cscript %SYSTEMDRIVE%\inetpub\adminscripts\iischangeip.vbs 111.222.3.25 %ipAddress%" +
                         @"
                          " +
                        "cscript %SYSTEMDRIVE%\\inetpub\\adminscripts\\adsutil.vbs set /w3svc/%IdWebSite%/ServerBindings \"%ipAddress%:%port%:\"" +
                        @"
                          " +
                        "cscript %SYSTEMDRIVE%\\inetpub\\adminscripts\\adsutil.vbs set /W3SVC/%IdWebSite%/Root/path \"%localPath%\""
                        +

                        @"
                        %SYSTEMDRIVE%\windows\System32\iisweb /start AMS
                        %SYSTEMDRIVE%\windows\System32\iisreset
                        %SYSTEMDRIVE%\windows\System32\iisreset" +
                        @"
                          " +
                        "START \"%SYSTEMDRIVE%\\Program Files\\Internet Explorer\\IEXPLORE.EXE\" \"http://%ipAddress%:%port%\"";


            string command = Environment.GetEnvironmentVariable("SYSTEMDRIVE");
            command += @"\inetpub\adminscripts\SetupIIS.bat";
            Console.WriteLine("5Stars' AAA System Installation\nPlease wait...");
            string J5sTxtLog = Environment.GetEnvironmentVariable("SYSTEMDRIVE") + @"\inetpub\adminscripts\log.txt";
            // 1: Write single line to new file
            using (StreamWriter writer = new StreamWriter(command, true))
            {
                writer.WriteLine(strCmdText);
            }
            System.Diagnostics.Process J5sP = new System.Diagnostics.Process();
            J5sP.StartInfo.UseShellExecute = false;
            J5sP.StartInfo.RedirectStandardOutput = true;
            J5sP.StartInfo.FileName = command;
            J5sP.Start();
            string output = J5sP.StandardOutput.ReadToEnd();
            using (StreamWriter writer = new StreamWriter(J5sTxtLog, true))
            {
                writer.WriteLine(output);
            }
            J5sP.WaitForExit();
            J5sP.Close();
            File.Delete(command);
        }
    }
}

