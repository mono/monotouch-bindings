BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
#Google Play GameServices 
VERSIONGPG=1.0
#Google Plus
VERSIONGP=1.3.0

all: Google.Plus.dll

google-plus-ios-sdk-$(VERSIONGP).zip:
	curl -O https://developers.google.com/+/mobile/ios/sdk/google-plus-ios-sdk-$(VERSIONGP).zip > $@
	unzip $@

GooglePlus: google-plus-ios-sdk-$(VERSIONGP).zip
	cp google-plus-ios-sdk-$(VERSIONGP)/GooglePlus.framework/Versions/A/GooglePlus GooglePlus
	cp google-plus-ios-sdk-$(VERSIONGP)/GoogleOpenSource.framework/Versions/A/GoogleOpenSource GoogleOpenSource

Resources/GooglePlus.bundle: google-plus-ios-sdk-$(VERSIONGP).zip GooglePlus
	mkdir Resources
	cp -R google-plus-ios-sdk-$(VERSIONGP)/GooglePlus.bundle Resources/GooglePlus.bundle

PlayGameServices.v$(VERSIONGPG).zip:
	curl -O https://developers.google.com/games/services/downloads/PlayGameServices.v$(VERSIONGPG).zip > $@
	unzip $@

PlayGameServices: PlayGameServices.v$(VERSIONGPG).zip
	cp PlayGameServices.framework/Versions/A/PlayGameServices PlayGameServices

Resources/PlayGameServices.bundle: PlayGameServices.v$(VERSIONGPG).zip PlayGameServices
	cp -R PlayGameServices.bundle Resources/PlayGameServices.bundle

libarclite.a:
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a
	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.linkwith.cs > libarclite.linkwith.cs

Google.Plus.dll: Makefile libarclite.a GoogleOpenSource.linkwith.cs GooglePlus.linkwith.cs PlayGameServices.linkwith.cs ApiDefinition.cs StructsAndEnums.cs Extras.cs Resources/GooglePlus.bundle Resources/PlayGameServices.bundle
	$(MONOXBUILD) /p:Configuration=Release Google.Plus.csproj
	cp bin/Release/Google.Plus.dll Google.Plus.dll

prepare: Resources/GooglePlus.bundle Resources/PlayGameServices.bundle

clean:
	-rm -rf README list ios Resources/ PlayGameServices.framework/ google-plus-ios-sdk-$(VERSIONGP)/ bin/ obj/ *.bundle *.dll *.o *.zip *.mdb GooglePlus GoogleOpenSource PlayGameServices libarclite.linkwith.cs libarclite.a

cleanproject:
	-rm -rf list ios bin/ obj/ *.dll