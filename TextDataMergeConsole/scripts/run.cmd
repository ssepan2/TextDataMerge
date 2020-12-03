echo off
rem
:step1
..\TextDataMergeConsole.exe /f;m /s;"C:\Users\ssepan\Documents\test.TextDataMerge"
if %errorlevel%==0 (goto true1) else (goto false1)
:true1
echo true
goto step2
:false1
echo false
goto end
rem
:step2
..\\TextDataMergeConsole.exe /f;c /s;"C:\Users\ssepan\Documents\test.TextDataMerge"
if %errorlevel%==0 (goto true2) else (goto false2)
:true2
echo true
goto step3
:false2
echo false
goto end
rem
:step3
..\TextDataMergeConsole.exe /f;s /s;"C:\Users\ssepan\Documents\test.TextDataMerge"
if %errorlevel%==0 (goto true3) else (goto false3)
:true3
echo true
goto step4
:false3
echo false
goto end
rem
:step4
..\TextDataMergeConsole.exe /f;f /s;"C:\Users\ssepan\Documents\test.TextDataMerge"
if %errorlevel%==0 (goto true4) else (goto false4)
:true4
echo true
goto end
:false4
echo false
goto end
rem
:end
pause
echo on


