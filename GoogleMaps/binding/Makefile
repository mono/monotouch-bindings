BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
VERSION=1.7.0

all: GoogleMaps.dll

GoogleMaps-iOS-$(VERSION).zip:
	curl -O https://dl.google.com/geosdk/GoogleMaps-iOS-$(VERSION).zip > $@
	unzip $@

GoogleMaps: GoogleMaps-iOS-$(VERSION).zip
	cp GoogleMaps-iOS-$(VERSION)/GoogleMaps.framework/Versions/A/GoogleMaps GoogleMaps

Resources/GoogleMaps.bundle: GoogleMaps-iOS-$(VERSION).zip GoogleMaps
	mkdir Resources
	cp -R GoogleMaps-iOS-$(VERSION)/GoogleMaps.framework/Versions/A/Resources/* Resources/GoogleMaps.bundle

GoogleMaps.dll: Makefile GoogleMaps.linkwith.cs ApiDefinition.cs StructsAndEnums.cs GoogleMaps Resources/GoogleMaps.bundle
	$(MONOXBUILD) /p:Configuration=Release GoogleMaps.csproj
	cp bin/Release/GoogleMaps.dll GoogleMaps.dll

prepare: Resources/GoogleMaps.bundle

clean:
	-rm -rf list ios Resources/ GoogleMaps-iOS-$(VERSION)/ bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb GoogleMaps
