BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.1.0
# PHFComposeBarView Version 1.1.0

all: PHFComposeBarView.dll

PHFComposeBarView.dll: Makefile libPHFComposeBarView.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libPHFComposeBarView.a
	$(MONOXBUILD) /p:Configuration=Release PHFComposeBarView.csproj
	cp bin/Release/PHFComposeBarView.dll PHFComposeBarView.dll

clean:
	-rm -rf list ios bin/ obj/ *.dll *.o *.mdb 
