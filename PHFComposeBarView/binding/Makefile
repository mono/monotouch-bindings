BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.1.2
# PHFComposeBarView Version 1.1.2

all: PHFComposeBarView.dll

PHFComposeBarView.dll: Makefile libPHFComposeBarView.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libPHFComposeBarView.a
	$(MONOXBUILD) /p:Configuration=Release PHFComposeBarView.csproj
	$(MONOXBUILD) /p:Configuration=Release PHFComposeBarView-Classic.csproj
	cp bin/unified/AnyCPU/Release/PHFComposeBarView.dll PHFComposeBarView.dll
	cp bin/unified/AnyCPU/Release/PHFComposeBarView.dll PHFComposeBarView-Classic.dll
	mkdir ../lib/
	mkdir ../lib/ios
	mkdir ../lib/ios-unified
	cp bin/classic/AnyCPU/Release/PHFComposeBarView.dll ../lib/ios/
	cp bin/unified/AnyCPU/Release/PHFComposeBarView.dll ../lib/ios-unified/
	
clean:
	-rm -rf list ios bin/ obj/ *.dll *.o *.mdb 
