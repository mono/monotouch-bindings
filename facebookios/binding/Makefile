MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
DATE=20150810
VERSION=4.5.0

all: Facebook-Unified.dll

FBSDKCoreKit.a:
	curl -O https://developers.facebook.com/resources/FacebookSDKs-iOS-$(DATE).zip > FacebookSDKs-iOS-$(DATE).zip
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'Bolts.framework/Bolts' > Bolts.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKCoreKit.framework/FBSDKCoreKit' > FBSDKCoreKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKLoginKit.framework/FBSDKLoginKit' > FBSDKLoginKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKMessengerShareKit.framework/FBSDKMessengerShareKit' > FBSDKMessengerShareKit.a
	unzip -p FacebookSDKs-iOS-$(DATE).zip 'FBSDKShareKit.framework/FBSDKShareKit' > FBSDKShareKit.a

Facebook-Unified.dll: Makefile ApiDefinition.cs StructsAndEnums.cs FBSDKCoreKit.a
	$(MONOXBUILD) /t:Clean Facebook.csproj
	$(MONOXBUILD) /p:Configuration=Release Facebook.csproj
	mkdir -p build/unified/
	mkdir -p ../../../facebookios/build/unified/
	cp bin/unified/Release/Facebook.dll build/unified/Facebook.dll
	cp bin/unified/Release/Facebook.dll ../../../facebookios/build/unified/

prepare: FBSDKCoreKit.a

clean:
	-rm -rf list ios Resources/ FacebookSDKs-iOS-$(DATE)/ bin/ obj/ build/ ../../../facebookios/build/ *.sln *.userprefs *.dll *.o *.zip *.pkg *.mdb *.a
