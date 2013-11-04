BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: opentok.dll

opentok.dll: Makefile ApiDefinition.cs StructsAndEnums.cs Opentok
	$(MONOXBUILD) /p:Configuration=Release opentok.csproj
	cp bin/Release/opentok.dll opentok.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/
