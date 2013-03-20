BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: GoogleMaps.dll

GoogleMaps-iOS-1.1.1.zip:
	curl -O https://dl.google.com/geosdk/GoogleMaps-iOS-1.1.1.zip > $@
	unzip $@

GoogleMaps: GoogleMaps-iOS-1.1.1.zip
	cp GoogleMaps-iOS-1.1.1/GoogleMaps.framework/Versions/A/GoogleMaps GoogleMaps

Resources/GoogleMaps.bundle: GoogleMaps-iOS-1.1.1.zip GoogleMaps
	mkdir Resources
	cp -R GoogleMaps-iOS-1.1.1/GoogleMaps.framework/Versions/A/Resources/* Resources/GoogleMaps.bundle

GoogleMaps.dll: Makefile GoogleMaps.linkwith.cs ApiDefinition.cs StructsAndEnums.cs extras.cs GoogleMaps Resources/GoogleMaps.bundle
	$(MONOXBUILD) /p:Configuration=Release GoogleMaps.csproj
	cp bin/Release/GoogleMaps.dll GoogleMaps.dll

prepare: Resources/GoogleMaps.bundle

clean:
	-rm -rf list ios Resources/ GoogleMaps-iOS-1.1.1/ bin/ obj/ *.dll *.o *.zip *.mdb GoogleMaps 
