BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=0.9.0

all: KGStatusBar.dll

KGStatusBar.dll: Makefile libKGStatusBar.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libKGStatusBar.a
	$(MONOXBUILD) /p:Configuration=Release KGStatusBar.csproj
	cp bin/Release/KGStatusBar.dll KGStatusBar.dll

clean:
	-rm -rf list ios bin/ obj/ *.dll *.o *.zip *.mdb 
