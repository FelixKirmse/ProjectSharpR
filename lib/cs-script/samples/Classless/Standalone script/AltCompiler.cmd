echo off
REM Make sure CS-Script is configured to use alternative compiler (%CSSCRIPT_DIR%\Lib\CSSCodeProvider.dll).
REM Run css_config.exe if required.
cscs HelloWorld.ccs
pause