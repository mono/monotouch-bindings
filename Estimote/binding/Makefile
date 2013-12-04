BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: Estimote.iOS.dll

Estimote.iOS.dll: Makefile libEstimoteSDK7.linkwith.cs ApiDefinition.cs StructsAndEnums.cs libEstimoteSDK7.a
	$(MONOXBUILD) /p:Configuration=Release Estimote.iOS.csproj
	cp bin/Release/Estimote.iOS.dll Estimote.iOS.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb bin/ obj/
