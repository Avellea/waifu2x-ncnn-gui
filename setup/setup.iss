; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "waifu2x-ncnn-gui"
#define MyAppVersion "1.1.1"
#define MyAppPublisher "Avellea"
#define MyAppURL "https://avellea.is-a.dev/projects/waifu2x-ncnn-gui/index.html"
#define MyAppExeName "waifu2x-ncnn-gui.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{21D77E32-4CE0-456C-B78B-0962E4339210}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=E:\Projects\C#\waifu2X-ncnn-gui\setup\LICENSE.txt
InfoBeforeFile=E:\Projects\C#\waifu2X-ncnn-gui\setup\INFO.txt
; Uncomment the following line to run in non administrative install mode (install for current user only.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=commandline
OutputDir=E:\Projects\C#\waifu2X-ncnn-gui\setup
OutputBaseFilename=waifu2x-ncnn-gui-setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

; USER DEFINED
; App strings
AppCopyright=Copyright (C) 2022 Avellea
AppUpdatesURL=https://github.com/Avellea/waifu2x-ncnn-gui/releases/latest
AppSupportURL=https://github.com/Avellea/waifu2x-ncnn-gui/issues/

; App images


WizardImageAlphaFormat=defined
WizardSmallImageFile=512.bmp
DisableWelcomePage=no
WizardImageFile=banner.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\Projects\C#\waifu2X-ncnn-gui\waifu2X-ncnn-gui\bin\Release\net6.0-windows\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Projects\C#\waifu2X-ncnn-gui\waifu2X-ncnn-gui\bin\Release\waifu2x-ncnn-gui.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Projects\C#\waifu2X-ncnn-gui\waifu2X-ncnn-gui\bin\Release\waifu2x-ncnn-gui.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Projects\C#\waifu2X-ncnn-gui\waifu2X-ncnn-gui\bin\Release\waifu2x-ncnn-gui.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

