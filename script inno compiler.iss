; Script generado por el Inno Setup Script Wizard.
; Configuración básica
#define MyAppName "LEMOTIFF"
#define MyAppVersion "1.2.2"
#define MyAppPublisher "AGM Services"
#define MyAppURL "https://api.whatsapp.com/send/?phone=5493813273910&text&type=phone_number&app_absent=0"
#define MyAppExeName "PeluqueriaApp.exe"

[Setup]
AppId={{A4652C5F-C272-48A2-BC0D-0A3EEFA5BDFD}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
PrivilegesRequired=admin 
LicenseFile=C:\Users\SANTIAGO\source\repos\LEMOTIFF\LICENSE.txt

OutputDir=C:\Users\SANTIAGO\Desktop\TRABAJOS\Instaladores
OutputBaseFilename=SETUP1.2.2
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Todos tus archivos normales (ejecutable y DLLs)
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\ClosedXML.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\ClosedXML.Parser.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\CuoreUI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\DocumentFormat.OpenXml.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\DocumentFormat.OpenXml.Framework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\ExcelNumberFormat.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\PeluqueriaApp.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\PeluqueriaApp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\PeluqueriaApp.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\PeluqueriaApp.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\PeluqueriaApp.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\RBush.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\SixLabors.Fonts.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\System.Data.SqlClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\System.IO.Packaging.dll"; DestDir: "{app}"; Flags: ignoreversion
//Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\new\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\runtimes\*"; \
    DestDir: "{app}\runtimes"; Flags: recursesubdirs createallsubdirs



; Configuración especial para la base de datos
Source: "C:\Users\SANTIAGO\source\repos\LEMOTIFF\PeluqueriaApp\bin\Release\net8.0-windows\peluqueriaDB.db"; DestDir: "{app}"

[Dirs]
Name: "{app}"; Permissions: users-modify

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

//[Run]
//Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent