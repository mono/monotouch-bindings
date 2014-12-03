BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: TSMiniWebBrowser.dll TSMiniWebBrowser-Classic.dll

TSMiniWebBrowser.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libTSMiniWebBrowser.a
	$(MONOXBUILD) /p:Configuration=Release TSMiniWebBrowser-Classic.csproj
	$(MONOXBUILD) /p:Configuration=Release TSMiniWebBrowser.csproj
	cp bin/classic/AnyCPU/Release/TSMiniWebBrowser.dll TSMiniWebBrowser-Classic.dll
	cp bin/unified/AnyCPU/Release/TSMiniWebBrowser.dll TSMiniWebBrowser.dll

clean:
	-rm -rf list ios bin/ obj/ *.userprefs *.dll *.o *.zip *.mdb
