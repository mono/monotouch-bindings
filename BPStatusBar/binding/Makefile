BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=0.9.0

all: BPStatusBar.dll

BPStatusBar.dll: Makefile libBPStatusBar.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libBPStatusBar.a
	$(MONOXBUILD) /p:Configuration=Release BPStatusBar.csproj
	cp bin/Release/BPStatusBar.dll BPStatusBar.dll

clean:
	-rm -rf list ios bin/ obj/ *.dll *.o *.zip *.mdb 
