BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=2.0

all: GoogleCast.dll

GoogleCastFramework-$(VERSION)-Release.zip:
	curl -O https://developers.google.com/cast/downloads/GoogleCastFramework-$(VERSION)-Release.zip
	unzip $@

GoogleCast: GoogleCastFramework-$(VERSION)-Release.zip
	cp GoogleCastFramework-$(VERSION)-Release/GoogleCast.framework/Versions/A/GoogleCast GoogleCast

GoogleCast.dll: Makefile GoogleCast.linkwith.cs ApiDefinition.cs StructsAndEnums.cs GoogleCast
	$(MONOXBUILD) /p:Configuration=Release GoogleCast.csproj
	cp bin/Release/GoogleCast.dll GoogleCast.dll

prepare: Resources

clean:
	-rm -rf list ios Resources/ GoogleCastFramework-$(VERSION)-Release/ Cast_Icons/ bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb GoogleCast Resources/ __MACOSX/
