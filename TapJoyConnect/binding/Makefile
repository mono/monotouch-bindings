BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: TapJoyConnect.dll

TapJoyConnect.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libTapJoyConnect.a
	$(MONOXBUILD) /p:Configuration=Release TapJoyConnect.csproj
	cp bin/Release/TapJoyConnect.dll TapJoyConnect.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/
