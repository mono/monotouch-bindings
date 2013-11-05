BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: RouteMe.dll

RouteMe.dll: Makefile ApiDefinition.cs StructsAndEnums.cs libMapView.a
	$(MONOXBUILD) /p:Configuration=Release RouteMe.Touch.csproj
	cp bin/Release/RouteMe.dll RouteMe.dll

clean:
	-rm -rf list ios *.dll *.zip *.mdb *.sln bin/ obj/
