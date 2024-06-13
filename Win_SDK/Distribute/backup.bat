@echo off
setlocal

rem ����汾�ű���
set "version=1.3.1"
set "cid1=emclient-linux-commit-id=1081245a2"
set "cid2=emclient-unity-commit-id=ee34d391b"

rem ��������ԣ�����ʾÿ������
@echo on

rem ���ñ���Ŀ¼
set "dest_dir=D:\workspace\UnitySDKWin\backup\win_proj_backup\%version%"

rem �жϱ���Ŀ¼�Ƿ���ڣ�����������Ƴ���
if exist "%dest_dir%" (
    echo Removing existing dest directory: %dest_dir%
    rmdir /s /q "%dest_dir%"
)

rem ��������Ŀ¼
mkdir "%dest_dir%"

rem ����commit-id����ļ�
set "output_file=%dest_dir%\commit-ids.txt"

rem д��commit-id
echo %cid1% >> "%output_file%"
echo %cid2% >> "%output_file%"


rem ����projԴĿ¼��proj����Ŀ¼��·��
set "source_dir_proj=D:\workspace\UnitySDKWin\emclient\emclient-unity\AgoraChatSDK\CWrapper\Wrapper\Wrapper_Common\build_win\proj"
set "dest_dir_proj=D:\workspace\UnitySDKWin\backup\win_proj_backup\%version%\proj"

rem ����proj����Ŀ¼
mkdir "%dest_dir_proj%"

rem ���� .vcproj �ļ�
for %%f in ("%source_dir_proj%\*.vcproj") do (
    echo Copying file: %%~nxf
    copy "%%f" "%dest_dir_proj%"
)

rem ���� .vcxproj �ļ�
for %%f in ("%source_dir_proj%\*.vcxproj") do (
    echo Copying file: %%~nxf
    copy "%%f" "%dest_dir_proj%"
)

rem ���� .vcxproj.filters �ļ�
for %%f in ("%source_dir_proj%\*.vcxproj.filters") do (
    echo Copying file: %%~nxf
    copy "%%f" "%dest_dir_proj%"
)

rem ���� .vcxproj.user �ļ�
for %%f in ("%source_dir_proj%\*.vcxproj.user") do (
    echo Copying file: %%~nxf
    copy "%%f" "%dest_dir_proj%"
)

rem ���� .sln �ļ�
for %%f in ("%source_dir_proj%\*.sln") do (
    echo Copying file: %%~nxf
    copy "%%f" "%dest_dir_proj%"
)

rem ����dllԴĿ¼��dll����Ŀ¼��·��
set "source_dir_dll=D:\workspace\UnitySDKWin\emclient\emclient-unity\AgoraChatSDK\CWrapper\Wrapper\Wrapper_Common\build_win\proj\Release"
set "dest_dir_dll=D:\workspace\UnitySDKWin\backup\win_proj_backup\%version%\dll-pdb"

rem ����proj����Ŀ¼
mkdir "%dest_dir_dll%"

rem ����dll��pdb�ļ�
xcopy /Y "%source_dir_dll%\SdkWrapper.dll" "%dest_dir_dll%"
xcopy /Y "%source_dir_dll%\SdkWrapper.pdb" "%dest_dir_dll%"

xcopy /Y "%source_dir_dll%\CommonWrapper.dll" "%dest_dir_dll%"
xcopy /Y "%source_dir_dll%\CommonWrapper.pdb" "%dest_dir_dll%"

xcopy /Y "%source_dir_dll%\ChatCWrapper.dll" "%dest_dir_dll%"
xcopy /Y "%source_dir_dll%\ChatCWrapper.pdb" "%dest_dir_dll%"

xcopy /Y "%source_dir_dll%\easemob.pdb" "%dest_dir_dll%"
xcopy /Y "%source_dir_dll%\easemob.lib" "%dest_dir_dll%"

endlocal