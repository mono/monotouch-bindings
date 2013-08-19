BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.7

all: LineaProSdk.dll

LineaProSdk.dll: Makefile libdtdev.linkwith.cs ApiDefinition.cs StructsAndEnums.cs Extas.cs LineaProSdk.csproj
	@test -s libdtdev.a || { echo "\n\nYou must download DTDevices-iOS_2013-02-28_v1.zip from \nhttp://ipcprint.com/developer/ \nunzip and place libdtdev.a in this folder in order to compile.\n\n"; exit 1; }
	$(MONOXBUILD) /p:Configuration=Release LineaProSdk.csproj
	cp bin/Release/LineaProSdk.dll LineaProSdk.dll

clean:
	-rm -rf list ios bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb Resources/