MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: PinterestSDK.dll

PinItSDKiOS.zip:
	curl -O https://pinterest-ota-builds.s3.amazonaws.com/PinItSDKiOS.zip > $@
	unzip $@

Pinterest: PinItSDKiOS.zip
	cp PinItSDKiOS/Pinterest.embeddedframework/Pinterest.framework/Versions/A/Pinterest Pinterest

Resources/PinterestSDKResources.bundle: PinItSDKiOS.zip Pinterest
	mkdir Resources
	cp -R PinItSDKiOS/Pinterest.embeddedframework/Pinterest.framework/Versions/A/Resources/* Resources/

PinterestSDK.dll: Makefile Pinterest.linkwith.cs ApiDefinition.cs StructsAndEnums.cs Pinterest Extras.cs Resources/PinterestSDKResources.bundle
	$(MONOXBUILD) /p:Configuration=Release PinterestSDK.csproj
	cp bin/Release/PinterestSDK.dll PinterestSDK.dll

prepare: Resources/GoogleMaps.bundle

clean:
	-rm -rf list ios Resources/ PinItSDKiOS/ bin/ obj/ *.sln *.userprefs *.dll *.o *.zip *.mdb Pinterest __MACOSX
