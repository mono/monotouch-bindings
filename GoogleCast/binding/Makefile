BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=2.0

all: GoogleCast.dll

GoogleCastFramework-$(VERSION)-Release.zip:
	curl -O https://developers.google.com/cast/downloads/GoogleCastFramework-$(VERSION)-Release.zip
	unzip $@

Cast_Icons.zip:
	curl -O https://developers.google.com/cast/downloads/Cast_Icons.zip
	unzip $@

GoogleCast: GoogleCastFramework-$(VERSION)-Release.zip
	cp GoogleCastFramework-$(VERSION)-Release/GoogleCast.framework/Versions/A/GoogleCast GoogleCast

Resources: GoogleCastFramework-$(VERSION)-Release.zip Cast_Icons.zip GoogleCast
	mkdir Resources
	cp -R Cast_Icons/iOS/* Resources/

GoogleCast.dll: Makefile GoogleCast.linkwith.cs ApiDefinition.cs StructsAndEnums.cs GoogleCast Resources
	$(MONOXBUILD) /p:Configuration=Release GoogleCast.csproj
	cp bin/Release/GoogleCast.dll GoogleCast.dll

prepare: Resources

clean:
	-rm -rf list ios Resources/ GoogleCastFramework-$(VERSION)-Release/ Cast_Icons/ bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb GoogleCast Resources/ __MACOSX/
