BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.0

all: SMCalloutView.dll

SMCalloutView.dll: Makefile libSMCalloutView.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libSMCalloutView.a
	$(MONOXBUILD) /p:Configuration=Release SMCalloutView.csproj
	cp bin/Release/SMCalloutView.dll SMCalloutView.dll

clean:
	-rm -rf list ios Resources/ bin/ obj/ *.dll *.o *.zip *.mdb 
