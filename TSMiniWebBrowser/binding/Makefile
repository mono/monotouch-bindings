BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: TSMiniWebBrowser.dll

TSMiniWebBrowser.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libTSMiniWebBrowser.a
	$(MONOXBUILD) /p:Configuration=Release TSMiniWebBrowser.csproj
	cp bin/Release/TSMiniWebBrowser.dll TSMiniWebBrowser.dll

clean:
	-rm -rf list ios bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb
