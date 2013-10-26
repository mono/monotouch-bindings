BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=0.8

all: MBProgressHUD.dll

MBProgressHUD.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libMBProgressHUD.a
	$(MONOXBUILD) /p:Configuration=Release MBProgressHUD.csproj
	cp bin/Release/MBProgressHUD.dll MBProgressHUD.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/
